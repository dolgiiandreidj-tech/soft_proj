using EvertimeScraper.Scrappers;
using Microsoft.Playwright;
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
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            string userId = textBoxId.Text;
            string password = textBoxPassword.Text;

            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false // set true later
            });

            var sessionManager = new SessionManager(browser);

            await sessionManager.SaveSessionAsync(userId, password);

            MessageBox.Show("Login successful & session saved");

            await browser.CloseAsync();
        }
    }
}