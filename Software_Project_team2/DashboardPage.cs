using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDoc = HtmlAgilityPack.HtmlDocument;

namespace Software_Project_team2
{
    public partial class DashboardPage : UserControl
    {
        public DashboardPage()
        {
            InitializeComponent();
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

        private async Task<List<(string Title, DateTime Date, string Url)>> ParseNoticesAsync()
        {
            var result = new List<(string Title, DateTime Date, string Url)>();
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                var html = await client.GetStringAsync(
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
            catch { }

            return result;
        }
    }
}