using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software_Project_team2.Services;

namespace Software_Project_team2
{
    public partial class DashboardPage : Form
    {
        private KlasService klasService;
        private readonly Services.NoticeService _noticeService = new();

        // Ensure 133 matches the maximum credits defined in the UI
        private const int TotalRequiredCredits = 133;

        public DashboardPage(KlasService klas)
        {
            InitializeComponent();

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
            buttonMoreClaass.Click += (_, _) => new RecommendedCoursesForm().Show();
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
        }

        private async Task LoadProgressionDataAsync()
        {
            try
            {
                var credits = await klasService.GetProgressionCreditsAsync();

                // Calculate the sum of all parsing sections
                int totalAcquiredCredits = credits.Major + credits.General + credits.Other;

                // Fetch GPA (new)
                string gpa = await klasService.GetGpaAsync();

                // Fetch username and current date string
                string userName = string.Empty;
                try
                {
                    userName = await klasService.GetUserNameAsync();
                }
                catch
                {
                    // ignore errors fetching user name
                }

                string currentDate = DateTime.Now.ToString("yyyy.MM.dd HH:mm");

                // Update UI Labels safely inside the UI Thread
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

        private void UpdateUI(int totalAcquiredCredits, string gpa)
        {
            // 0. Update GPA label
            label3.Text = string.IsNullOrWhiteSpace(gpa) ? "0.0" : gpa;

            // 1. Set the aggregated main value
            label10.Text = totalAcquiredCredits.ToString();

            // 2. IMPORTANT: Adjust position of the target text ("/133") so it doesn't overlap
            label9.Left = label10.Right + 3; // +3 is a small padding gap

            // 3. Calculate progress ratio
            double percentage = Math.Min(100.0, ((double)totalAcquiredCredits / TotalRequiredCredits) * 100);

            // 4. Update texts and bar width visually
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