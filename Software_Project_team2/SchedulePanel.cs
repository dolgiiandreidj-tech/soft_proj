using Everytime.Api;
using Everytime.Models;
using Everytime.Sessions;
using EvertimeScraper.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Project_team2
{
    public partial class SchedulePanel : UserControl
    {
        private bool _searching;
        private int _detailRequest;
        private List<LectureInfo> _byProf = new();
        private List<LectureInfo> _byClass = new();
        private List<ReviewInfo> _lastReviews = new();

        // API client — initialised lazily on first search
        private EverytimeClient? _client;
        private HttpClient? _httpClient;
        private List<Subject> _cachedSubjects = new();
        private const int CampusId = 11;

        private static (int year, string semester) CurrentSemester()
        {
            var now = DateTime.Now;
            return now.Month >= 9 ? (now.Year, "2") : (now.Year, "1");
        }

        public SchedulePanel()
        {
            InitializeComponent();
            btnGo.Click += async (_, _) => await RunSearchAsync();
            txtSearch.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    await RunSearchAsync();
                }
            };
            lstByProf.SelectedIndexChanged += async (_, _) => await OnSelectionChanged(lstByProf, _byProf);
            lstByClass.SelectedIndexChanged += async (_, _) => await OnSelectionChanged(lstByClass, _byClass);
        }

        private async Task RunSearchAsync()
        {
            if (_searching) return;
            var keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                lblStatus.Text = "키워드를 입력하세요";
                return;
            }

            _searching = true;
            SetControlsEnabled(false);
            lblStatus.Text = "검색 중...";
            lstByProf.Items.Clear();
            lstByClass.Items.Clear();
            ClearDetail();

            try
            {
                if (!await EnsureClientAsync()) return;

                // Fetch subjects once per session; reuse cache on subsequent searches
                if (_cachedSubjects.Count == 0)
                {
                    lblStatus.Text = "강의 목록 불러오는 중...";
                    var (year, sem) = CurrentSemester();
                    _cachedSubjects = await _client!.GetAllSubjectsAsync(CampusId, year, sem);
                }

                _byClass = _cachedSubjects
                    .Where(s => s.Name?.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false)
                    .Select(s => new LectureInfo(s.Name ?? "", s.Professor ?? "", "", int.TryParse(s.LectureId, out var id) ? id : 0, s.Code ?? ""))
                    .ToList();

                _byProf = _cachedSubjects
                    .Where(s => s.Professor?.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false)
                    .Select(s => new LectureInfo(s.Name ?? "", s.Professor ?? "", "", int.TryParse(s.LectureId, out var id) ? id : 0, s.Code ?? ""))
                    .ToList();

                foreach (var l in _byProf)
                    lstByProf.Items.Add($"{l.Professor} — {l.Name}");
                foreach (var l in _byClass)
                    lstByClass.Items.Add($"{l.Name} — {l.Professor}");

                lblStatus.Text = $"강의명 {_byClass.Count}건 / 교수명 {_byProf.Count}건";
            }
            catch (SessionExpiredException)
            {
                ResetSession();
                lblStatus.Text = "세션 만료 — 쿠키를 다시 입력하세요";
                using var dlg = new LoginForm();
                if (dlg.ShowDialog() == DialogResult.OK)
                    await RunSearchAsync();
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"오류: {ex.Message}";
            }
            finally
            {
                SetControlsEnabled(true);
                _searching = false;
            }
        }

        private void ResetSession()
        {
            _client = null;
            _httpClient?.Dispose();
            _httpClient = null;
            _cachedSubjects.Clear();
        }

        private async Task<bool> EnsureClientAsync()
        {
            if (_client != null) return true;

            var sessionPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "everytime.session.json");
            var store = new SessionStore(sessionPath);
            var session = await store.LoadAsync();
            if (session == null)
            {
                using var loginForm = new LoginForm();
                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    lblStatus.Text = "세션 없음";
                    return false;
                }
                session = await store.LoadAsync();
                if (session == null) return false;
            }

            _httpClient = HttpClientFactory.FromSession(session);
            _httpClient.DefaultRequestHeaders.Add("Referer", "https://everytime.kr/");
            _httpClient.DefaultRequestHeaders.Add("Origin", "https://everytime.kr");
            _client = new EverytimeClient(_httpClient);
            return true;
        }

        private void SetControlsEnabled(bool enabled)
        {
            btnGo.Enabled = enabled;
            txtSearch.Enabled = enabled;
            rbProf.Enabled = enabled;
            rbClass.Enabled = enabled;
        }

        private async Task OnSelectionChanged(ListBox list, List<LectureInfo> source)
        {
            var idx = list.SelectedIndex;
            if (idx < 0 || idx >= source.Count) return;
            await LoadDetailAsync(source[idx]);
        }

        private async Task LoadDetailAsync(LectureInfo info)
        {
            int myRequest = Interlocked.Increment(ref _detailRequest);

            lblDetailName.Text = info.Name;
            lblDetailProfessor.Text = $"교수: {(string.IsNullOrEmpty(info.Professor) ? "-" : info.Professor)}";
            lblDetailCode.Text = $"학수번호: {(string.IsNullOrEmpty(info.Code) ? "-" : info.Code)}";
            lblDetailRating.Text = "★ -";
            lblDetailReviews.Text = "강의평 -";
            lblDetailStatus.Text = "불러오는 중...";

            try
            {
                if (info.LectureId == 0)
                {
                    lblDetailStatus.Text = "강의평 없음";
                    return;
                }

                var apiReviews = await _client!.GetAllReviewsAsync(info.LectureId);

                if (myRequest != Volatile.Read(ref _detailRequest)) return;

                var reviews = apiReviews
                    .Select(r => new ReviewInfo(r.Rate, $"{r.Year}년 {r.Semester}학기", r.Text ?? ""))
                    .ToList();

                double avgRating = reviews.Count > 0 ? Math.Round(reviews.Average(r => r.Rating), 1) : 0;

                lblDetailRating.Text = reviews.Count > 0 ? $"★ {avgRating:F1}" : "★ -";
                lblDetailReviews.Text = $"강의평 {reviews.Count}개";
                lblDetailStatus.Text = "";

                _lastReviews = reviews;
                ShowReviews(reviews);
            }
            catch (SessionExpiredException)
            {
                if (myRequest != Volatile.Read(ref _detailRequest)) return;
                ResetSession();
                lblDetailStatus.Text = "세션 만료 — 쿠키를 다시 입력하세요";
                using var dlg = new LoginForm();
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                if (myRequest != Volatile.Read(ref _detailRequest)) return;
                lblDetailStatus.Text = $"오류: {ex.Message}";
            }
        }

        private void ShowReviews(List<ReviewInfo> reviews)
        {
            var recent = reviews.Where(r => IsRecent(r.Semester)).ToList();

            flowReviews.SuspendLayout();
            flowReviews.Controls.Clear();

            int cardWidth = flowReviews.ClientSize.Width - 4;

            foreach (var r in recent)
            {
                var card = new Panel
                {
                    BackColor = Color.FromArgb(38, 41, 52),
                    Padding = new Padding(12),
                    Margin = new Padding(0, 0, 0, 8),
                    Width = cardWidth
                };

                var lblMeta = new Label
                {
                    AutoSize = true,
                    BackColor = Color.Transparent,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(255, 200, 90),
                    Location = new Point(12, 10),
                    Text = $"{r.Semester}   ★ {r.Rating:F1}"
                };

                var lblText = new Label
                {
                    AutoSize = true,
                    BackColor = Color.Transparent,
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.FromArgb(220, 222, 230),
                    Location = new Point(12, 34),
                    MaximumSize = new Size(cardWidth - 24, 0),
                    Text = r.Text
                };

                card.Controls.Add(lblMeta);
                card.Controls.Add(lblText);
                card.Height = lblText.Bottom + 12;

                flowReviews.Controls.Add(card);
            }

            flowReviews.ResumeLayout();

            lblReviewsHeader.Text = recent.Count > 0
                ? $"최근 강의평 ({recent.Count}개, 최근 2년)"
                : "최근 강의평 — 최근 2년 내 강의평 없음";
        }

        private static bool IsRecent(string semester)
        {
            int currentYear = DateTime.Now.Year;
            var match = Regex.Match(semester, @"(\d{4})년");
            if (!match.Success) return false;
            int reviewYear = int.Parse(match.Groups[1].Value);
            return reviewYear >= currentYear - 1;
        }

        private void ClearDetail()
        {
            Interlocked.Increment(ref _detailRequest);
            lblDetailName.Text = "";
            lblDetailProfessor.Text = "";
            lblDetailCode.Text = "";
            lblDetailRating.Text = "";
            lblDetailReviews.Text = "";
            lblDetailStatus.Text = "";
            flowReviews.Controls.Clear();
            lblReviewsHeader.Text = "최근 강의평";
            _lastReviews.Clear();
        }
    }
}
