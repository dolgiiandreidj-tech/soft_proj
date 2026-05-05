using Software_Project_team2.Services;
using System;
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
                await BrowserService.Instance.LoginAsync(userId, password);

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
