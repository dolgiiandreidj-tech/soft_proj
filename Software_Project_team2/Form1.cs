using Software_Project_team2.Services;

namespace Software_Project_team2
{
    public partial class Form1 : Form
    {
        private KlasService klasService = new KlasService();

        public Form1()
        {
            InitializeComponent();
            this.Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            textBoxId.TabIndex = 0;
            textBoxPassword.TabIndex = 1;
            buttonLogin.TabIndex = 2;

            this.ActiveControl = textBoxId;
            textBoxId.Focus();
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
                var dashboard = new DashboardPage(klasService);
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("KLAS login failed");
            }
        }
    }
}