using Software_Project_team2.Models;

namespace Software_Project_team2
{
    public partial class RecommendedCoursesForm : Form
    {
        private readonly List<RecommendedCourse> _courses;

        public RecommendedCoursesForm(List<RecommendedCourse> courses)
        {
            _courses = courses;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PopulateCourses();
        }

        private void PopulateCourses()
        {
            flowCourses.Controls.Clear();

            if (_courses.Count == 0)
            {
                flowCourses.Controls.Add(new Label
                {
                    Text = "추천 강의를 불러올 수 없습니다.",
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(10, 20, 0, 0)
                });
                return;
            }

            int cardWidth = Math.Max(400, flowCourses.ClientSize.Width - flowCourses.Padding.Horizontal - 4);
            foreach (var course in _courses)
                flowCourses.Controls.Add(CreateCourseCard(course, cardWidth));
        }

        internal static Panel CreateCourseCard(RecommendedCourse course, int width)
        {
            var card = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(width, 80),
                Margin = new Padding(0, 0, 0, 8)
            };

            var lblCode = new Label
            {
                Text = string.IsNullOrEmpty(course.Code) ? "-" : course.Code,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(90, 0, 31),
                Location = new Point(15, 10),
                Size = new Size(120, 60),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var lblName = new Label
            {
                Text = course.Name,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 45),
                Location = new Point(148, 10),
                Size = new Size((int)(width * 0.44), 26),
                AutoSize = false
            };

            var lblProf = new Label
            {
                Text = course.Professor,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(120, 120, 120),
                Location = new Point(148, 40),
                Size = new Size((int)(width * 0.44), 22),
                AutoSize = false
            };

            var lblCredits = new Label
            {
                Text = $"{course.Credits} 학점",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(120, 120, 120),
                Location = new Point((int)(width * 0.63), 10),
                Size = new Size(90, 60),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblRating = new Label
            {
                Text = course.Rating > 0 ? $"★ {course.Rating:F1}" : "★ -",
                Font = new Font("Segoe UI", 12F),
                ForeColor = Color.FromArgb(45, 45, 45),
                Location = new Point(width - 130, 10),
                Size = new Size(110, 60),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight
            };

            card.Controls.AddRange(new Control[] { lblCode, lblName, lblProf, lblCredits, lblRating });
            return card;
        }
    }
}
