using Software_Project_team2.Services;
using System.Windows.Forms;

namespace Software_Project_team2
{
    public class MainForm : Form
    {
        public MainForm(KlasService klas, EverytimeService every)
        {
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            var dashboard = new DashboardPage(klas, every);
            dashboard.Dock = DockStyle.Fill;
            Controls.Add(dashboard);
        }
    }
}
