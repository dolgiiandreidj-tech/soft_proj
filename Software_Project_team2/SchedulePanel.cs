using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvertimeScraper.Models;
using EvertimeScraper.Scrappers;
using EvertimeScraper.Scrapers;
using Microsoft.Playwright;

namespace Software_Project_team2
{
    public partial class SchedulePanel : UserControl
    {
        private bool _searching;
        private int _detailRequest;
        private List<LectureInfo> _byProf = new();
        private List<LectureInfo> _byClass = new();
        private List<TimetableCourse>? _timetableCache;

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
                using var playwright = await Playwright.CreateAsync();
                await using var browser = await playwright.Chromium.LaunchAsync(new()
                {
                    Headless = true,
                    Args = new[] { "--disable-blink-features=AutomationControlled" }
                });
                var sessionManager = new SessionManager(browser);
                await using var context = await sessionManager.LoadSessionAsync();
                var page = await context.NewPageAsync();
                var scraper = new SearchScraper(page);

                _byClass = await scraper.SearchAsync(keyword, "name");
                _byProf = await scraper.SearchAsync(keyword, "professor");

                foreach (var l in _byProf)
                    lstByProf.Items.Add(string.IsNullOrEmpty(l.Professor) ? l.Name : $"{l.Professor} — {l.Name}");
                foreach (var l in _byClass)
                    lstByClass.Items.Add(string.IsNullOrEmpty(l.Professor) ? l.Name : $"{l.Name} — {l.Professor}");

                lblStatus.Text = $"강의명 {_byClass.Count}건 / 교수명 {_byProf.Count}건";
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
            // tag this request so any later click cancels stale result binding
            int myRequest = Interlocked.Increment(ref _detailRequest);

            // optimistic: bind the bits we already know
            lblDetailName.Text = info.Name;
            lblDetailProfessor.Text = $"교수: {(string.IsNullOrEmpty(info.Professor) ? "-" : info.Professor)}";
            lblDetailCode.Text = "학수번호: -";
            lblDetailRating.Text = "★ -";
            lblDetailReviews.Text = "강의평 -";
            lblDetailStatus.Text = "불러오는 중...";

            try
            {
                using var playwright = await Playwright.CreateAsync();
                await using var browser = await playwright.Chromium.LaunchAsync(new()
                {
                    Headless = true,
                    Args = new[] { "--disable-blink-features=AutomationControlled" }
                });
                var sessionManager = new SessionManager(browser);
                await using var context = await sessionManager.LoadSessionAsync();
                var page = await context.NewPageAsync();

                // pull all reviews — count and average rating both come from this list
                var reviews = await new ReviewScraper(page).GetReviewsAsync(info.Url);
                int reviewCount = reviews.Count;
                double avgRating = reviewCount > 0
                    ? Math.Round(reviews.Average(r => r.Rating), 1)
                    : 0.0;

                // course code: cache the timetable subject list once, then match by name + professor
                if (_timetableCache == null)
                {
                    try
                    {
                        var ttPage = await context.NewPageAsync();
                        _timetableCache = await new TimetableScraper(ttPage).GetCourseListAsync();
                        await ttPage.CloseAsync();
                    }
                    catch
                    {
                        _timetableCache = new List<TimetableCourse>();
                    }
                }
                var matchedCode = LookupCourseCode(info.Name, info.Professor, _timetableCache);

                // discard if a newer click superseded this one
                if (myRequest != Volatile.Read(ref _detailRequest)) return;

                lblDetailName.Text = info.Name;
                lblDetailProfessor.Text = $"교수: {(string.IsNullOrEmpty(info.Professor) ? "-" : info.Professor)}";
                lblDetailCode.Text = $"학수번호: {(string.IsNullOrEmpty(matchedCode) ? "-" : matchedCode)}";
                lblDetailRating.Text = reviewCount > 0 ? $"★ {avgRating:F1}" : "★ -";
                lblDetailReviews.Text = $"강의평 {reviewCount}개";
                lblDetailStatus.Text = "";
            }
            catch (Exception ex)
            {
                if (myRequest != Volatile.Read(ref _detailRequest)) return;
                lblDetailStatus.Text = $"오류: {ex.Message}";
            }
        }

        private static string LookupCourseCode(string name, string professor, List<TimetableCourse> courses)
        {
            if (courses.Count == 0) return "";
            var n = (name ?? "").Trim();
            var p = (professor ?? "").Trim();

            // exact name + professor first
            var hit = courses.Find(c => c.CourseName.Trim() == n && c.Professor.Trim() == p);
            if (hit != null) return hit.CourseCode;

            // fall back to name-only match (timetable may show a different prof for the same course)
            hit = courses.Find(c => c.CourseName.Trim() == n);
            return hit?.CourseCode ?? "";
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
        }
    }
}
