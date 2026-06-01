namespace Software_Project_team2
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            labelHint = new Label();
            textBoxCookies = new TextBox();
            buttonLogin = new Button();
            panel1.SuspendLayout();
            SuspendLayout();

            // panel1
            panel1.BackColor = Color.FromArgb(24, 27, 38);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(labelHint);
            panel1.Controls.Add(textBoxCookies);
            panel1.Controls.Add(buttonLogin);
            panel1.Location = new Point(217, 113);
            panel1.Size = new Size(700, 300);
            panel1.TabIndex = 0;

            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(40, 24);
            label1.Text = "에브리타임 쿠키 설정";

            // labelHint
            labelHint.AutoSize = false;
            labelHint.Font = new Font("Segoe UI", 9F);
            labelHint.ForeColor = Color.FromArgb(160, 165, 180);
            labelHint.Location = new Point(40, 70);
            labelHint.Size = new Size(620, 36);
            labelHint.Text = "브라우저 DevTools → Storage → Cookies에서 x-et-device와 etsid 값을 복사해 붙여넣으세요";

            // textBoxCookies
            textBoxCookies.BackColor = Color.FromArgb(32, 35, 48);
            textBoxCookies.BorderStyle = BorderStyle.None;
            textBoxCookies.Font = new Font("Segoe UI", 11F);
            textBoxCookies.ForeColor = Color.FromArgb(220, 222, 230);
            textBoxCookies.Location = new Point(40, 116);
            textBoxCookies.Multiline = true;
            textBoxCookies.Size = new Size(620, 60);
            textBoxCookies.PlaceholderText = "x-et-device=xxx; etsid=xxx";
            textBoxCookies.TabIndex = 1;

            // buttonLogin
            buttonLogin.BackColor = Color.FromArgb(255, 55, 55);
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(40, 196);
            buttonLogin.Size = new Size(620, 44);
            buttonLogin.TabIndex = 2;
            buttonLogin.Text = "저장";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;

            // LoginForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 20, 28);
            ClientSize = new Size(1134, 530);
            Controls.Add(panel1);
            Name = "LoginForm";
            Text = "에브리타임 쿠키 설정";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panel1;
        private Label label1;
        private Label labelHint;
        private TextBox textBoxCookies;
        private Button buttonLogin;
    }
}
