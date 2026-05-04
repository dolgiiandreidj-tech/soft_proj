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

            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("ID와 비밀번호를 입력하세요.");
                return;
            }

            buttonLogin.Enabled = false;
            try
            {
                using var playwright = await Playwright.CreateAsync();
                var browser = await playwright.Chromium.LaunchAsync(new()
                {
                    Headless = false
                });

                var sessionManager = new SessionManager(browser);
                await sessionManager.SaveSessionAsync(userId, password);
                await browser.CloseAsync();

                var main = new MainForm();
                main.FormClosed += (_, _) => Close();
                Hide();
                main.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"로그인 실패: {ex.Message}");
                buttonLogin.Enabled = true;
            }
        }
    }
}