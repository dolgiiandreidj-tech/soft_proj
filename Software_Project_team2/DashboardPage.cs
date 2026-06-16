using Everytime.Sessions;
using Software_Project_team2.Models;
using Software_Project_team2.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Project_team2
{
    public partial class DashboardPage : Form
    {
        private KlasService klasService;
        private readonly Services.NoticeService _noticeService = new();
        private List<RecommendedCourse> _recommendations = new();

        private const int TotalRequiredCredits = 133;

        public DashboardPage(KlasService klas)
        {
            InitializeComponent();

            // Hide placeholder card panels (flowLayoutPanel1 covers them, but remove from tab order)
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;

            // Show loading state immediately
            flowLayoutPanel1.Controls.Add(new Label
            {
                Text = "추천 강의 로딩 중...",
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.Gray,
                AutoSize = true,
                Margin = new Padding(20, 20, 0, 0)
            });

            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.Sizable;
            Text = "대시보드";
            FormClosed += (_, _) => Application.Exit();

            klasService = klas;

            buttonTimeTable.Click += (_, _) => new Timetable(klasService).Show();
            buttonLectureManagement.Click += (_, _) => new SchedulePanel().Show();
            btnMore.Click += (_, _) => new NoticeForm().Show();
            buttonGrades.Click += (_, _) => new Grade(klasService).Show();
            buttonAssignment.Click += (_, _) => new Assignment(klasService).Show();
            buttonMoreClaass.Click += (_, _) => new RecommendedCoursesForm(_recommendations).Show();
            buttonLogOut.Click += OnLogOut;
        }

        private void OnLogOut(object? sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "KLAS와 에브리타임에서 로그아웃하시겠습니까?",
                "로그아웃",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes) return;

            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            DeleteFile(Path.Combine(appData, "klas.session.json"));
            DeleteFile(Path.Combine(appData, "everytime.session.json"));

            Application.Restart();
        }

        private static void DeleteFile(string path)
        {
            try { if (File.Exists(path)) File.Delete(path); } catch { }
        }

        private async Task LoadNoticesAsync()
        {
            try
            {
                var notices = await _noticeService.FetchAsync();
                var sb = new System.Text.StringBuilder();

                foreach (var n in notices.Take(5))
                {
                    sb.AppendLine($"• {n.Category} {n.Title}");
                    sb.AppendLine($"  {n.Date} · {n.Author}");
                    sb.AppendLine();
                }

                string text = sb.Length > 0 ? sb.ToString() : "공지사항을 불러올 수 없습니다.";

                void update() => richNotice.Text = text;
                if (InvokeRequired) Invoke(update);
                else update();
            }
            catch
            {
                void setErr() => richNotice.Text = "공지사항을 불러올 수 없습니다.";
                if (InvokeRequired) Invoke(setErr);
                else setErr();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            UpdateDateTime();

            timer1.Tick -= timer1_Tick;
            timer1.Tick += timer1_Tick;
            timer1.Start();

            _ = LoadNoticesAsync();
            _ = LoadProgressionDataAsync();
            _ = LoadRecommendationsAsync();
        }

        private async Task LoadProgressionDataAsync()
        {
            try
            {
                var credits = await klasService.GetProgressionCreditsAsync();

                int totalAcquiredCredits = credits.Major + credits.General + credits.Other;

                string gpa = await klasService.GetGpaAsync();

                string userName = string.Empty;
                try
                {
                    userName = await klasService.GetUserNameAsync();
                }
                catch { }

                string currentDate = DateTime.Now.ToString("yyyy.MM.dd HH:mm");

                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        UpdateUI(totalAcquiredCredits, gpa);

                        if (!string.IsNullOrWhiteSpace(userName))
                            labelUserName.Text = $"{userName}님 환영합니다";

                        labelCurrentData.Text = currentDate;
                    }));
                }
                else
                {
                    UpdateUI(totalAcquiredCredits, gpa);

                    if (!string.IsNullOrWhiteSpace(userName))
                        labelUserName.Text = $"{userName}님 환영합니다";

                    labelCurrentData.Text = currentDate;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Progression] load failed: {ex.Message}");
                try
                {
                    if (!IsDisposed)
                        Invoke(new Action(() =>
                        {
                            label10.Text = "ERR";
                            label7.Text = "0.0%";
                            panel2.Width = 0;
                            label3.Text = "ERR";
                        }));
                }
                catch (ObjectDisposedException) { }
            }
        }

        private async Task LoadRecommendationsAsync()
        {
            try
            {
                var etSession = await LoadEverytimeSessionAsync();
                if (etSession == null) return;

                var service = new CourseRecommendationService(klasService, etSession);
                _recommendations = await service.GetRecommendationsAsync();

                var top4 = _recommendations.Take(4).ToList();

                void updateUI() => ShowCourseCards(top4);
                if (InvokeRequired) Invoke(updateUI);
                else updateUI();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Recommendations] Failed: {ex.Message}");
            }
        }

        private static async Task<Session?> LoadEverytimeSessionAsync()
        {
            try
            {
                var path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "everytime.session.json");
                return await new SessionStore(path).LoadAsync();
            }
            catch { return null; }
        }

        private void ShowCourseCards(List<RecommendedCourse> courses)
        {
            flowLayoutPanel1.Controls.Clear();

            if (courses.Count == 0)
            {
                flowLayoutPanel1.Controls.Add(new Label
                {
                    Text = "추천 강의를 불러올 수 없습니다.",
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(20, 20, 0, 0)
                });
                return;
            }

            int cardWidth = Math.Max(200, flowLayoutPanel1.Width - 20);
            foreach (var course in courses)
                flowLayoutPanel1.Controls.Add(RecommendedCoursesForm.CreateCourseCard(course, cardWidth));
        }

        private void UpdateUI(int totalAcquiredCredits, string gpa)
        {
            label3.Text = string.IsNullOrWhiteSpace(gpa) ? "0.0" : gpa;
            label10.Text = totalAcquiredCredits.ToString();
            label9.Left = label10.Right + 3;

            double percentage = Math.Min(100.0, ((double)totalAcquiredCredits / TotalRequiredCredits) * 100);
            label7.Text = $"{percentage:F1}%";
            int maxProgressBarWidth = panel3.Width;
            panel2.Width = (int)((percentage / 100.0) * maxProgressBarWidth);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            labelCurrentData.Text = DateTime.Now.ToString("yyyy.MM.dd");
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
