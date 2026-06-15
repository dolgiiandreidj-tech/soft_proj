using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software_Project_team2.Services;

namespace Software_Project_team2
{
    public partial class Timetable : Form
    {
        private readonly KlasService _klasService;
        private Panel schedulePanel;
        private const int TimeLabelWidth = 60;
        private const int SlotHeight = 60;

        public Timetable(KlasService klasService)
        {
            _klasService = klasService ?? throw new ArgumentNullException(nameof(klasService));
            InitializeComponent();
            InitializeRuntimeControls();

            btnSearch.Click += async (_, __) => await LoadAndRenderTimetableAsync();
        }

        private void InitializeRuntimeControls()
        {
            // create schedule panel area under the filter
            schedulePanel = new Panel
            {
                Location = new Point(28, 130),
                Size = new Size(1158, 480),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true
            };
            mainPanel.Controls.Add(schedulePanel);
        }

        private async Task LoadAndRenderTimetableAsync()
        {
            btnSearch.Enabled = false;
            try
            {
                var lessons = await _klasService.GetTimetableAsync();
                RenderSchedule(lessons);
            }
            catch (Exception ex)
            {
                MessageBox.Show("시간표 로드 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSearch.Enabled = true;
            }
        }

        private void RenderSchedule(List<LessonModel> lessons)
        {
            schedulePanel.Controls.Clear();

            // if no lessons, show placeholder
            if (lessons == null || lessons.Count == 0)
            {
                var lbl = new Label
                {
                    Text = "시간표가 없습니다.",
                    AutoSize = true,
                    ForeColor = Color.Gray,
                    Location = new Point(10, 10)
                };
                schedulePanel.Controls.Add(lbl);
                return;
            }

            // determine max slot (for rows)
            int maxSlot = Math.Max(6, lessons.Max(l => l.StartSlot + Math.Max(0, l.Duration - 1)));
            int rows = maxSlot + 1;

            int gridWidth = schedulePanel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            int colWidth = (gridWidth - TimeLabelWidth) / 6;
            int headerHeight = 40;

            // draw headers (days)
            string[] days = new[] { "월", "화", "수", "목", "금", "토" };
            for (int d = 0; d < 6; d++)
            {
                var dayLbl = new Label
                {
                    Text = days[d],
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent,
                    ForeColor = Color.FromArgb(40, 40, 40),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Location = new Point(TimeLabelWidth + d * colWidth, 0),
                    Size = new Size(colWidth, headerHeight)
                };
                schedulePanel.Controls.Add(dayLbl);
            }

            // draw time labels and grid lines
            for (int s = 0; s < rows; s++)
            {
                int y = headerHeight + s * SlotHeight;
                var timeLbl = new Label
                {
                    Text = s.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(0, y),
                    Size = new Size(TimeLabelWidth, SlotHeight),
                    ForeColor = Color.Gray
                };
                schedulePanel.Controls.Add(timeLbl);

                // horizontal separator
                var hLine = new Panel
                {
                    BackColor = Color.FromArgb(230, 230, 230),
                    Location = new Point(TimeLabelWidth, y + SlotHeight - 1),
                    Size = new Size(gridWidth - TimeLabelWidth, 1)
                };
                schedulePanel.Controls.Add(hLine);
            }

            // vertical separators
            for (int d = 0; d <= 6; d++)
            {
                int x = TimeLabelWidth + d * colWidth;
                var vLine = new Panel
                {
                    BackColor = Color.FromArgb(230, 230, 230),
                    Location = new Point(x, headerHeight),
                    Size = new Size(1, rows * SlotHeight)
                };
                schedulePanel.Controls.Add(vLine);
            }

            // prepare color map for css tokens
            var palette = new[]
            {
                Color.FromArgb(242, 178, 84),
                Color.FromArgb(122, 201, 150),
                Color.FromArgb(184, 126, 238),
                Color.FromArgb(119, 199, 199),
                Color.FromArgb(244, 154, 211)
            };

            // render lessons
            foreach (var lesson in lessons)
            {
                int day = Math.Max(0, Math.Min(5, lesson.Day));
                int start = Math.Max(0, lesson.StartSlot);
                int dur = Math.Max(1, lesson.Duration);

                int x = TimeLabelWidth + day * colWidth + 4; // small padding
                int y = headerHeight + start * SlotHeight + 4;
                int w = colWidth - 8;
                int h = dur * SlotHeight - 8;
                var panel = new Panel
                {
                    Location = new Point(x, y),
                    Size = new Size(w, h),
                    BackColor = PickColor(lesson.CssClass, palette),
                    Cursor = Cursors.Hand,
                    BorderStyle = BorderStyle.None,
                    Tag = lesson
                };

                var title = new Label
                {
                    Text = lesson.Title,
                    Location = new Point(6, 6),
                    Size = new Size(w - 12, Math.Max(18, h / 3)),
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    AutoEllipsis = true
                };
                panel.Controls.Add(title);

                var info = new Label
                {
                    Text = $"{lesson.Location}{(string.IsNullOrEmpty(lesson.Location) || string.IsNullOrEmpty(lesson.Instructor) ? "" : " / ")}{lesson.Instructor}",
                    Location = new Point(6, 6 + title.Height),
                    Size = new Size(w - 12, Math.Max(16, h - title.Height - 12)),
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI", 8F),
                    AutoEllipsis = true
                };
                panel.Controls.Add(info);

                // simple click to show details
                panel.Click += (s, e) =>
                {
                    var l = (s as Control)?.Tag as LessonModel;
                    if (l != null)
                    {
                        MessageBox.Show($"{l.Title}\n{l.Location} / {l.Instructor}\n시작 슬롯: {l.StartSlot}, 지속: {l.Duration}", "강의 정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };

                schedulePanel.Controls.Add(panel);
            }

            // adjust scrollable height
            schedulePanel.AutoScrollMinSize = new Size(0, headerHeight + rows * SlotHeight);
        }

        private Color PickColor(string cssClass, Color[] palette)
        {
            if (string.IsNullOrWhiteSpace(cssClass)) return palette[0];
            // try to extract namecolXX to derive an index
            var m = System.Text.RegularExpressions.Regex.Match(cssClass, @"namecol0?(\d+)");
            if (m.Success && int.TryParse(m.Groups[1].Value, out int idx))
            {
                return palette[(idx - 1) % palette.Length];
            }
            // fallback hash
            int hash = cssClass.Aggregate(0, (acc, ch) => acc * 31 + ch);
            return palette[Math.Abs(hash) % palette.Length];
        }
    }
}
