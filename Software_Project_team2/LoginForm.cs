using Everytime.Sessions;
using System;
using System.Linq;
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
            var raw = textBoxCookies.Text.Trim();
            if (string.IsNullOrEmpty(raw))
            {
                MessageBox.Show("쿠키를 입력하세요.");
                return;
            }

            var cookies = raw.Split(';', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(pair =>
                {
                    var idx = pair.IndexOf('=');
                    if (idx < 0) return null;
                    return new SessionCookie(pair[..idx].Trim(), pair[(idx + 1)..].Trim(), ".everytime.kr", "/", null);
                })
                .Where(c => c != null)
                .Cast<SessionCookie>()
                .ToList();

            var session = new Session
            {
                Cookies = cookies,
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:151.0) Gecko/20100101 Firefox/151.0"
            };

            var store = new SessionStore(
                System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "everytime.session.json"));

            await store.SaveAsync(session);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
