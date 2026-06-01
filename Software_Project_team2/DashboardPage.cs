using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDoc = HtmlAgilityPack.HtmlDocument;
using Software_Project_team2.Services;

namespace Software_Project_team2
{
    public partial class DashboardPage : UserControl
    {
        private readonly SchedulePanel _schedulePanel;
        private KlasService klasService;

        // Ensure 133 matches the maximum credits defined in the UI
        private const int TotalRequiredCredits = 133;

        public DashboardPage(KlasService klas)
        {
            InitializeComponent();

            klasService = klas;

            _schedulePanel = new SchedulePanel
            {
                Location = new Point(250, 0),
                Size = new Size(Width - 250, Height),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Visible = false
            };
            Controls.Add(_schedulePanel);
            _schedulePanel.BringToFront();

            buttonSchedule.Click += (_, _) => ShowSchedule(true);
            buttonDashboard.Click += (_, _) => ShowSchedule(false);

            _ = LoadNoticesAsync();
        }

        private async Task LoadNoticesAsync()
        {
            var notices = await ParseNoticesAsync();

            panelNotice.Controls.Remove(panelNotice1);
            panelNotice.Controls.Remove(panel8);
            panelNotice.Controls.Remove(panel9);
            panelNotice.Controls.Remove(panel10);
            panelNotice.Controls.Remove(panel11);

            int yPos = 98;
            int count = 0;

            foreach (var notice in notices)
            {
                if (count >= 4) break;
                var card = CreateNoticeCard(notice.Title, notice.Date.ToString("yyyy.MM.dd"), notice.Url, yPos);
                panelNotice.Controls.Add(card);
                yPos += 82;
                count++;
            }
        }

        private Panel CreateNoticeCard(string title, string date, string url, int y)
        {
            var panel = new Panel
            {
                Location = new Point(12, y),
                Size = new Size(305, 72),
                BackColor = panelNotice.BackColor,
                Cursor = Cursors.Hand
            };

            panel.Controls.Add(new Label
            {
                Text = "•",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(98, 120, 255),
                Location = new Point(4, 21),
                AutoSize = true
            });

            var titleLabel = new Label
            {
                Text = title.Length > 28 ? title.Substring(0, 28) + "…" : title,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(22, 22),
                Size = new Size(268, 22),
                AutoSize = false,
                AutoEllipsis = true,
                Cursor = Cursors.Hand
            };
            panel.Controls.Add(titleLabel);

            panel.Controls.Add(new Label
            {
                Text = date,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(160, 165, 180),
                Location = new Point(20, 46),
                AutoSize = true
            });

            EventHandler openUrl = (s, e) =>
            {
                if (!string.IsNullOrEmpty(url))
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            };
            panel.Click += openUrl;
            titleLabel.Click += openUrl;

            return panel;
        }

        private static readonly HttpClient _httpClient = new HttpClient();

        private async Task<List<(string Title, DateTime Date, string Url)>> ParseNoticesAsync()
        {
            var result = new List<(string Title, DateTime Date, string Url)>();
            try
            {
                if (!_httpClient.DefaultRequestHeaders.Contains("User-Agent"))
                    _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                var html = await _httpClient.GetStringAsync(
                    "https://www.kw.ac.kr/ko/life/notice.jsp?BoardMode=list&tpage=1&searchKey=1&searchVal=&srCategoryId=");

                var doc = new HtmlDoc();
                doc.LoadHtml(html);

                var items = doc.DocumentNode.SelectNodes(
                    "//div[contains(@class,'board-list-box')]//li[contains(@class,'top-notice') or contains(@class,'no')]");
                if (items == null) return result;

                var oneMonthAgo = DateTime.Now.AddMonths(-1);

                foreach (var item in items)
                {
                    var titleNode = item.SelectSingleNode(".//div[contains(@class,'board-text')]//a");
                    var infoNode = item.SelectSingleNode(".//p[contains(@class,'info')]");

                    if (titleNode == null || infoNode == null) continue;

                    string title = System.Net.WebUtility.HtmlDecode(titleNode.InnerText)
                        .Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();

                    string href = titleNode.GetAttributeValue("href", "");
                    string url = href.StartsWith("http") ? href : "https://www.kw.ac.kr" + href;

                    string infoText = infoNode.InnerText.Trim();
                    string dateStr = "";
                    foreach (var part in infoText.Split(' '))
                    {
                        if (Regex.IsMatch(part.Trim(), @"^\d{4}-\d{2}-\d{2}$"))
                        {
                            dateStr = part.Trim();
                            break;
                        }
                    }

                    if (string.IsNullOrEmpty(title)) continue;
                    if (DateTime.TryParse(dateStr, out DateTime date) && date >= oneMonthAgo)
                        result.Add((title, date, url));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Notices] fetch failed: {ex.Message}");
            }

            return result;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
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

                // Update UI Labels safely inside the UI Thread
                if (InvokeRequired)
                {
                    Invoke(new Action(() => UpdateUI(totalAcquiredCredits, gpa)));
                }
                else
                {
                    UpdateUI(totalAcquiredCredits, gpa);
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

        private void ShowSchedule(bool show)
        {
            _schedulePanel.Visible = show;
            if (show) _schedulePanel.BringToFront();

            foreach (Control c in Controls)
            {
                if (c == _schedulePanel || c == panelSidebar) continue;
                if (c is Label lbl && (lbl.Name == "labelUserName" || lbl.Name == "lblTime" || lbl.Name == "labelCurrentData"))
                    continue;
                c.Visible = !show;
            }
        }
    }
}