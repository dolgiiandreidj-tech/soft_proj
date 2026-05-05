using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvertimeScraper.Models;
using EvertimeScraper.Scrappers;
using EvertimeScraper.Scrapers;
using Software_Project_team2.Services;

namespace Software_Project_team2
{
    public partial class SchedulePanel : UserControl
    {
        private bool _searching;
        private int _detailRequest;
        private List<LectureInfo> _byProf = new();
        private List<LectureInfo> _byClass = new();

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
                if (BrowserService.Instance == null)
                {
                    lblStatus.Text = "브라우저가 준비되지 않았습니다";
                    return;
                }

                var page = await BrowserService.Instance.NewPageAsync();
                try
                {
                    var scraper = new SearchScraper(page);
                    _byClass = await scraper.SearchAsync(keyword, "name");
                    _byProf = await scraper.SearchAsync(keyword, "professor");
                }
                finally
                {
                    await page.CloseAsync();
                }

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
                if (BrowserService.Instance == null)
                {
                    lblDetailStatus.Text = "브라우저가 준비되지 않았습니다";
                    return;
                }

                var page = await BrowserService.Instance.NewPageAsync();
                List<ReviewInfo> reviews;
                try
                {
                    reviews = await new ReviewScraper(page).GetReviewsAsync(info.Url);
                }
                finally
                {
                    await page.CloseAsync();
                }

                int reviewCount = reviews.Count;
                double avgRating = reviewCount > 0
                    ? Math.Round(reviews.Average(r => r.Rating), 1)
                    : 0.0;

                // discard if a newer click superseded this one
                if (myRequest != Volatile.Read(ref _detailRequest)) return;

                lblDetailName.Text = info.Name;
                lblDetailProfessor.Text = $"교수: {(string.IsNullOrEmpty(info.Professor) ? "-" : info.Professor)}";
                lblDetailCode.Text = "학수번호: -";
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
