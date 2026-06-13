namespace Software_Project_team2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            labelKWU = new Label();
            panelLoginKwu = new Panel();
            buttonLogin = new Button();
            panelKwuId = new Panel();
            textBoxId = new TextBox();
            panelKwuPsw = new Panel();
            textBoxPassword = new TextBox();
            panelLoginKwu.SuspendLayout();
            panelKwuId.SuspendLayout();
            panelKwuPsw.SuspendLayout();
            SuspendLayout();
            // 
            // labelKWU
            // 
            labelKWU.AutoSize = true;
            labelKWU.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelKWU.ForeColor = Color.White;
            labelKWU.Location = new Point(15, 14);
            labelKWU.Margin = new Padding(1, 0, 1, 0);
            labelKWU.Name = "labelKWU";
            labelKWU.Size = new Size(307, 32);
            labelKWU.TabIndex = 0;
            labelKWU.Text = "KWANGWOON UNIVERSITY";
            // 
            // panelLoginKwu
            // 
            panelLoginKwu.BackColor = Color.FromArgb(20, 18, 28);
            panelLoginKwu.Controls.Add(buttonLogin);
            panelLoginKwu.Controls.Add(panelKwuId);
            panelLoginKwu.Controls.Add(labelKWU);
            panelLoginKwu.Controls.Add(panelKwuPsw);
            panelLoginKwu.Location = new Point(353, 97);
            panelLoginKwu.Margin = new Padding(1);
            panelLoginKwu.Name = "panelLoginKwu";
            panelLoginKwu.Size = new Size(350, 270);
            panelLoginKwu.TabIndex = 1;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(170, 28, 18);
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(134, 177);
            buttonLogin.Margin = new Padding(1);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(84, 29);
            buttonLogin.TabIndex = 5;
            buttonLogin.Text = "로그인";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // panelKwuId
            // 
            panelKwuId.BackColor = Color.FromArgb(36, 36, 36);
            panelKwuId.BorderStyle = BorderStyle.FixedSingle;
            panelKwuId.Controls.Add(textBoxId);
            panelKwuId.Location = new Point(69, 59);
            panelKwuId.Margin = new Padding(1);
            panelKwuId.Name = "panelKwuId";
            panelKwuId.Size = new Size(220, 42);
            panelKwuId.TabIndex = 6;
            // 
            // textBoxId
            // 
            textBoxId.BackColor = Color.FromArgb(36, 36, 36);
            textBoxId.BorderStyle = BorderStyle.None;
            textBoxId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxId.ForeColor = Color.Transparent;
            textBoxId.Location = new Point(1, 11);
            textBoxId.Margin = new Padding(1);
            textBoxId.Name = "textBoxId";
            textBoxId.PlaceholderText = "ID(학번 또는 사번)";
            textBoxId.Size = new Size(218, 22);
            textBoxId.TabIndex = 3;
            // 
            // panelKwuPsw
            // 
            panelKwuPsw.BackColor = Color.FromArgb(36, 36, 36);
            panelKwuPsw.BorderStyle = BorderStyle.FixedSingle;
            panelKwuPsw.Controls.Add(textBoxPassword);
            panelKwuPsw.Location = new Point(69, 115);
            panelKwuPsw.Margin = new Padding(1);
            panelKwuPsw.Name = "panelKwuPsw";
            panelKwuPsw.Size = new Size(220, 42);
            panelKwuPsw.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BackColor = Color.FromArgb(36, 36, 36);
            textBoxPassword.BorderStyle = BorderStyle.None;
            textBoxPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxPassword.ForeColor = Color.FromArgb(170, 170, 170);
            textBoxPassword.Location = new Point(1, 11);
            textBoxPassword.Margin = new Padding(1);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PlaceholderText = "PASSWORD";
            textBoxPassword.Size = new Size(214, 22);
            textBoxPassword.TabIndex = 4;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1047, 508);
            Controls.Add(panelLoginKwu);
            DoubleBuffered = true;
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(1);
            Name = "Form1";
            Text = "Form1";
            panelLoginKwu.ResumeLayout(false);
            panelLoginKwu.PerformLayout();
            panelKwuId.ResumeLayout(false);
            panelKwuId.PerformLayout();
            panelKwuPsw.ResumeLayout(false);
            panelKwuPsw.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelKWU;
        private Panel panelLoginKwu;
        private Panel panelKwuPsw;
        private TextBox textBoxId;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private Panel panelKwuId;
    }
}
