using Software_Project_team2.Services;

namespace Software_Project_team2
{
    public partial class Form1 : Form
    {
        private KlasService klasService = new KlasService();
        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxId.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Please enter your KLAS ID and password.");
                return;
            }

            bool success = await klasService.LoginAsync(textBoxId.Text, textBoxPassword.Text);

            if (success)
            {
                var form2 = new LoginForm(klasService);
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("KLAS login failed");
            }
        }
    }
}