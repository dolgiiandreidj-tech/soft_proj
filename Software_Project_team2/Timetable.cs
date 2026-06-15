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

        // Tracks lesson panels we added so we can clear them on re-render
        private readonly List<Control> _lessonControls = new();
        private bool _placeholdersRemoved;

        // Color palette for distinguishing different courses
        private static readonly Color[] Palette = new[]
        {
            Color.FromArgb(242, 178, 84),
            Color.FromArgb(122, 201, 150),
            Color.FromArgb(184, 126, 238),
            Color.FromArgb(119, 199, 199),
            Color.FromArgb(244, 154, 211)
        };

        public Timetable(KlasService klasService)
        {
            _klasService = klasService ?? throw new ArgumentNullException(nameof(klasService));
            InitializeComponent();
            btnSearch.Click += async (_, __) => await LoadAndRenderTimetableAsync();
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
                MessageBox.Show("시간표 로드 중 오류가 발생했습니다: " + ex.Message, "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSearch.Enabled = true;
            }
        }

        private void RemovePlaceholders()
        {
            if (_placeholdersRemoved) return;
            // Remove the designer's hardcoded example lesson labels so cells are free for real data
            foreach (var lbl in new[] { label1, label2, label3, label4, label5, label6, label7, label8 })
                tableLayoutPanel1.Controls.Remove(lbl);
            _placeholdersRemoved = true;
        }

        private void RenderSchedule(List<LessonModel> lessons)
        {
            RemovePlaceholders();

            // Remove lesson controls from the previous render
            foreach (var ctrl in _lessonControls)
                tableLayoutPanel1.Controls.Remove(ctrl);
            _lessonControls.Clear();

            if (lessons == null || lessons.Count == 0)
            {
                var noData = new Label
                {
                    Text = "시간표가 없습니다.",
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.Gray,
                    Font = new Font("Segoe UI", 10F)
                };
                tableLayoutPanel1.Controls.Add(noData, 1, 1);
                tableLayoutPanel1.SetColumnSpan(noData, 5);
                tableLayoutPanel1.SetRowSpan(noData, 8);
                _lessonControls.Add(noData);
                return;
            }

            // Assign consistent colors per course title
            var colorMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            int colorIdx = 0;

            foreach (var lesson in lessons)
            {
                // Day 0=Mon→col1, 1=Tue→col2, ..., 4=Fri→col5; Saturday (col 6) is outside the grid
                int col = lesson.Day + 1;
                if (col < 1 || col > 5) continue;

                // StartSlot 1–8 maps directly to rows 1–8 in tableLayoutPanel1
                int row = lesson.StartSlot;
                if (row < 1 || row > 8) continue;

                // Clamp duration so the lesson doesn't overflow past row 8
                int dur = Math.Max(1, Math.Min(lesson.Duration, 9 - row));

                if (!colorMap.TryGetValue(lesson.Title, out int paletteIdx))
                {
                    paletteIdx = colorIdx % Palette.Length;
                    colorMap[lesson.Title] = paletteIdx;
                    colorIdx++;
                }

                var panel = BuildLessonPanel(lesson, paletteIdx);
                tableLayoutPanel1.Controls.Add(panel, col, row);
                if (dur > 1)
                    tableLayoutPanel1.SetRowSpan(panel, dur);

                _lessonControls.Add(panel);
            }
        }

        private Panel BuildLessonPanel(LessonModel lesson, int paletteIdx)
        {
            var panel = new Panel
            {
                BackColor = Palette[paletteIdx],
                Dock = DockStyle.Fill,
                Cursor = Cursors.Hand,
                Margin = new Padding(2),
                Tag = lesson
            };

            var titleLabel = new Label
            {
                Text = lesson.Title,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoEllipsis = true,
                Padding = new Padding(4, 4, 4, 0),
                AutoSize = false,
                Height = 32
            };

            var infoText = string.Join(" / ",
                new[] { lesson.Location, lesson.Instructor }.Where(s => !string.IsNullOrEmpty(s)));
            var infoLabel = new Label
            {
                Text = infoText,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 7.5F),
                ForeColor = Color.Black,
                AutoEllipsis = true,
                Padding = new Padding(4, 2, 4, 2),
                AutoSize = false
            };

            // Add info first so DockStyle.Fill works under the Top-docked title
            panel.Controls.Add(infoLabel);
            panel.Controls.Add(titleLabel);

            panel.Click += ShowLessonDetail;
            titleLabel.Click += ShowLessonDetail;
            infoLabel.Click += ShowLessonDetail;

            return panel;
        }

        private void ShowLessonDetail(object? sender, EventArgs e)
        {
            var ctrl = sender as Control;
            // Walk up to find the panel that holds the LessonModel in its Tag
            while (ctrl != null && ctrl.Tag is not LessonModel)
                ctrl = ctrl.Parent;
            if (ctrl?.Tag is LessonModel l)
            {
                MessageBox.Show(
                    $"{l.Title}\n{l.Location} / {l.Instructor}\n시작 교시: {l.StartSlot}, 지속: {l.Duration}교시",
                    "강의 정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
