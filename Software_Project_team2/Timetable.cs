using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software_Project_team2.Services;

namespace Software_Project_team2
{
    public partial class Timetable : Form
    {
        private readonly KlasService _klasService;

        private static readonly Color[] Palette =
        {
            Color.FromArgb(90,   0,  31),   // KW dark red
            Color.FromArgb( 0, 102, 153),   // steel blue
            Color.FromArgb(34, 120,  50),   // forest green
            Color.FromArgb(150,  70,   0),  // amber
            Color.FromArgb(80,   40, 130),  // purple
        };

        public Timetable(KlasService klasService)
        {
            _klasService = klasService;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _ = LoadAsync();
        }

        private async Task LoadAsync()
        {
            try
            {
                var result = await _klasService.GetCourseListAsync();
                if (InvokeRequired) Invoke(() => Render(result));
                else Render(result);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Timetable] {ex.Message}");
            }
        }

        private void Render(CourseListResult data)
        {
            panelContent.SuspendLayout();
            panelContent.Controls.Clear();

            int y    = 24;
            int left = 30;

            // ── Title + semester label ────────────────────────────────────
            var lblTitle = new Label
            {
                Text      = "수강과목",
                Font      = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.FromArgb(25, 25, 25),
                AutoSize  = true,
                Location  = new Point(left, y),
            };
            panelContent.Controls.Add(lblTitle);

            var lblSem = new Label
            {
                Text      = $"( {data.Yearhakgi} )",
                Font      = new Font("Segoe UI", 13F),
                ForeColor = Color.FromArgb(145, 145, 145),
                AutoSize  = true,
                Location  = new Point(left + lblTitle.PreferredWidth + 14, y + 9),
            };
            panelContent.Controls.Add(lblSem);
            y += 56;

            // ── Day activity dots ─────────────────────────────────────────
            var weekStrip = BuildWeekStrip(data.Subjects);
            weekStrip.Location = new Point(left, y);
            panelContent.Controls.Add(weekStrip);
            y += 64;

            // ── Horizontal rule ───────────────────────────────────────────
            var rule = new Panel
            {
                BackColor = Color.FromArgb(210, 210, 210),
                Size      = new Size(panelContent.ClientSize.Width - left * 2, 1),
                Location  = new Point(left, y),
                Anchor    = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
            };
            panelContent.Controls.Add(rule);
            y += 20;

            // ── Course cards ──────────────────────────────────────────────
            if (data.Subjects.Count == 0)
            {
                panelContent.Controls.Add(new Label
                {
                    Text      = "수강 과목이 없습니다.",
                    Font      = new Font("Segoe UI", 12F),
                    ForeColor = Color.Gray,
                    AutoSize  = true,
                    Location  = new Point(left, y),
                });
            }
            else
            {
                int cardW = Math.Max(300, panelContent.ClientSize.Width - left * 2 - 18);
                for (int i = 0; i < data.Subjects.Count; i++)
                {
                    var card = BuildCourseCard(data.Subjects[i], i);
                    card.Location = new Point(left, y);
                    card.Width    = cardW;
                    card.Anchor   = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                    panelContent.Controls.Add(card);
                    y += card.Height + 20;
                }
            }

            panelContent.ResumeLayout(true);
        }

        // Draws coloured circles for each weekday; filled = has class that day
        private static Panel BuildWeekStrip(List<CourseInfo> subjects)
        {
            var activeDays    = new HashSet<string>();
            foreach (var s in subjects)
                foreach (var seg in s.LctrumSchdulInfo.Split(','))
                {
                    var t = seg.Trim();
                    if (t.Length > 0) activeDays.Add(t[0].ToString());
                }

            const string days      = "월화수목금토";
            var          activeClr = Color.FromArgb(90, 0, 31);
            var          idleClr   = Color.FromArgb(232, 232, 232);

            var strip = new Panel { Width = days.Length * 54, Height = 52, BackColor = Color.Transparent };

            strip.Paint += (_, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using var font = new Font("Segoe UI", 10F, FontStyle.Bold);
                using var sf   = new StringFormat
                    { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

                for (int i = 0; i < days.Length; i++)
                {
                    string d      = days[i].ToString();
                    bool   active = activeDays.Contains(d);
                    int    x      = i * 54;
                    using var fill = new SolidBrush(active ? activeClr : idleClr);
                    using var fore = new SolidBrush(active ? Color.White : Color.FromArgb(185, 185, 185));
                    g.FillEllipse(fill, x, 4, 44, 44);
                    g.DrawString(d, font, fore, new RectangleF(x, 4, 44, 44), sf);
                }
            };

            return strip;
        }

        // Builds one horizontal course card
        private Panel BuildCourseCard(CourseInfo course, int index)
        {
            var accent = Palette[index % Palette.Length];
            var tagBg  = Color.FromArgb(
                Math.Min(255, accent.R + 200),
                Math.Min(255, accent.G + 210),
                Math.Min(255, accent.B + 210));

            var card = new Panel { Height = 148, BackColor = Color.White };
            card.Paint += (s, e) =>
            {
                var rc = ((Panel)s!).ClientRectangle;
                using var pen = new Pen(Color.FromArgb(222, 222, 222));
                e.Graphics.DrawRectangle(pen, 0, 0, rc.Width - 1, rc.Height - 1);
            };

            // Left colour bar
            card.Controls.Add(new Panel { Width = 6, Dock = DockStyle.Left, BackColor = accent });

            // Content laid out in a 4-row TableLayoutPanel
            var tbl = new TableLayoutPanel
            {
                Dock        = DockStyle.Fill,
                ColumnCount = 1,
                RowCount    = 4,
                Padding     = new Padding(16, 10, 16, 8),
                BackColor   = Color.Transparent,
            };
            tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));      // course name
            tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));      // course code
            tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));      // professor
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // schedule tags
            card.Controls.Add(tbl);

            // Row 0 — course name (ellipsis for long names)
            tbl.Controls.Add(new Label
            {
                Text         = course.SubjNm,
                Font         = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor    = Color.FromArgb(25, 25, 25),
                AutoSize     = false,
                AutoEllipsis = true,
                Dock         = DockStyle.Fill,
                TextAlign    = ContentAlignment.MiddleLeft,
            }, 0, 0);

            // Row 1 — course code (small, muted)
            tbl.Controls.Add(new Label
            {
                Text      = course.Hakjungno,
                Font      = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(160, 160, 160),
                AutoSize  = false,
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
            }, 0, 1);

            // Row 2 — professor name
            tbl.Controls.Add(new Label
            {
                Text      = course.ProfNm,
                Font      = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(115, 115, 115),
                AutoSize  = false,
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
            }, 0, 2);

            // Row 3 — schedule pill tags with resolved time range
            var flow = new FlowLayoutPanel
            {
                Dock          = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents  = true,
                BackColor     = Color.Transparent,
                Padding       = new Padding(0, 2, 0, 0),
            };
            foreach (var seg in course.LctrumSchdulInfo.Split(new[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
            {
                flow.Controls.Add(new Label
                {
                    Text        = FormatScheduleTag(seg.Trim()),
                    Font        = new Font("Segoe UI", 8.5F),
                    ForeColor   = accent,
                    BackColor   = tagBg,
                    AutoSize    = true,
                    Padding     = new Padding(8, 4, 8, 4),
                    Margin      = new Padding(0, 0, 8, 4),
                    BorderStyle = BorderStyle.FixedSingle,
                });
            }
            tbl.Controls.Add(flow, 0, 3);

            return card;
        }

        private static readonly Dictionary<int, (string Start, string End)> PeriodTimes = new()
        {
            {  0, ("08:00", "08:50") },
            {  1, ("09:00", "10:15") },
            {  2, ("10:30", "11:45") },
            {  3, ("12:00", "13:15") },
            {  4, ("13:30", "14:45") },
            {  5, ("15:00", "16:15") },
            {  6, ("16:30", "17:45") },
            {  7, ("18:00", "18:45") },
            {  8, ("18:50", "19:35") },
            {  9, ("19:40", "20:25") },
            { 10, ("20:30", "21:15") },
            { 11, ("21:20", "22:05") },
        };

        // "화 5교시/참B101"  →  "화  5교시  15:00~16:15  참B101"
        // "수 0,1,2교시/새빛301"  →  "수  0,1,2교시  08:00~11:45  새빛301"
        private static string FormatScheduleTag(string raw)
        {
            int slash = raw.IndexOf('/');
            if (slash < 0) return raw;

            string dayPeriod = raw[..slash].Trim();
            string room      = raw[(slash + 1)..].Trim();
            int    sp        = dayPeriod.IndexOf(' ');
            if (sp < 0) return raw.Replace("/", "  ");

            string day        = dayPeriod[..sp];
            string periodPart = dayPeriod[(sp + 1)..];              // "5교시" or "0,1,2교시"
            string nums       = periodPart.Replace("교시", "").Trim();

            int min = int.MaxValue, max = int.MinValue;
            foreach (var p in nums.Split(','))
                if (int.TryParse(p.Trim(), out int n))
                { if (n < min) min = n; if (n > max) max = n; }

            string time = "";
            if (min != int.MaxValue
                && PeriodTimes.TryGetValue(min, out var ts)
                && PeriodTimes.TryGetValue(max, out var te))
                time = $"  {ts.Start}~{te.End}";

            return $"{day}  {periodPart}{time}  {room}";
        }
    }
}

