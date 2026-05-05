using Software_Project_team2.Services;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Project_team2
{
    public partial class DashboardPage : UserControl
    {
        private readonly SchedulePanel _schedulePanel;
        private KlasService klasService;
        private EverytimeService everytimeService;

        // Ensure 133 matches the maximum credits defined in the UI
        private const int TotalRequiredCredits = 133;

        public DashboardPage(KlasService klas, EverytimeService every)
        {
            InitializeComponent();

            klasService = klas;
            everytimeService = every;

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

                // Update UI Labels safely inside the UI Thread
                if (InvokeRequired)
                {
                    Invoke(new Action(() => UpdateUI(totalAcquiredCredits)));
                }
                else
                {
                    UpdateUI(totalAcquiredCredits);
                }
            }
            catch (Exception ex)
            {
                if (!IsDisposed)
                {
                    Invoke(new Action(() =>
                    {
                        label10.Text = "ERR";
                        label7.Text = "0.0%";
                        panel2.Width = 0;
                    }));
                }
            }
        }

        private void UpdateUI(int totalAcquiredCredits)
        {
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