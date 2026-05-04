using System.Drawing;
using System.Windows.Forms;

namespace Software_Project_team2
{
    public partial class DashboardPage : UserControl
    {
        private readonly SchedulePanel _schedulePanel;

        public DashboardPage()
        {
            InitializeComponent();

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
