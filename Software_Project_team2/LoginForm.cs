using EvertimeScraper.Scrappers;
using Microsoft.Playwright;
using Software_Project_team2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Project_team2
{
    public partial class LoginForm : Form
    {
        private KlasService klasService;
        private EverytimeService everytimeService = new EverytimeService();
        public LoginForm(KlasService klas)
        {
            InitializeComponent();
            klasService = klas;
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            bool success = await everytimeService.LoginAsync(textBoxId.Text, textBoxPassword.Text);

            if (success)
            {
                this.Hide();

                var main = new DashboardPage(klasService, everytimeService);
                main.Show();
            }
            else
            {
                MessageBox.Show("Everytime login failed");
            }
        }
    }
}