using Software_Project_team2.Services;
using System;
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
            if (string.IsNullOrWhiteSpace(textBoxId.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Please enter your Everytime ID and password.");
                return;
            }

            bool success = await everytimeService.LoginAsync(textBoxId.Text, textBoxPassword.Text);

            if (success)
            {
                var main = new MainForm(klasService, everytimeService);
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Everytime login failed");
            }
        }
    }
}
