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
            bool success = await klasService.LoginAsync(textBoxId.Text, textBoxPassword.Text);

            if (success)
            {
                this.Hide();

                var form2 = new LoginForm(klasService);
                form2.Show();
            }
            else
            {
                MessageBox.Show("KLAS login failed");
            }
        }
    }
}