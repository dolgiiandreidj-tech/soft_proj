using Software_Project_team2.Services;
using System.Drawing;
using System.Windows.Forms;

namespace Software_Project_team2
{
    public class MainForm : Form
    {
        public MainForm()
        {
            Text = "Dashboard";
            BackColor = Color.FromArgb(20, 22, 28);
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;

            var dashboard = new DashboardPage
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(dashboard);

            // tear the shared Playwright browser down when the dashboard closes
            FormClosed += async (_, _) => await BrowserService.Instance.DisposeAsync();
        }
    }
}
