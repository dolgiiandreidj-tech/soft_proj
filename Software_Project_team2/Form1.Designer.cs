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
            labelKWU.Location = new Point(22, 24);
            labelKWU.Margin = new Padding(2, 0, 2, 0);
            labelKWU.Name = "labelKWU";
            labelKWU.Size = new Size(467, 48);
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
            panelLoginKwu.Location = new Point(482, 146);
            panelLoginKwu.Margin = new Padding(2);
            panelLoginKwu.Name = "panelLoginKwu";
            panelLoginKwu.Size = new Size(500, 450);
            panelLoginKwu.TabIndex = 1;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(170, 28, 18);
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(191, 295);
            buttonLogin.Margin = new Padding(2);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(120, 48);
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
            panelKwuId.Location = new Point(98, 98);
            panelKwuId.Margin = new Padding(2);
            panelKwuId.Name = "panelKwuId";
            panelKwuId.Size = new Size(314, 68);
            panelKwuId.TabIndex = 6;
            // 
            // textBoxId
            // 
            textBoxId.BackColor = Color.FromArgb(36, 36, 36);
            textBoxId.BorderStyle = BorderStyle.None;
            textBoxId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxId.ForeColor = Color.Transparent;
            textBoxId.Location = new Point(2, 18);
            textBoxId.Margin = new Padding(2);
            textBoxId.Name = "textBoxId";
            textBoxId.PlaceholderText = "ID(학번 또는 사번)";
            textBoxId.Size = new Size(311, 32);
            textBoxId.TabIndex = 3;
            // 
            // panelKwuPsw
            // 
            panelKwuPsw.BackColor = Color.FromArgb(36, 36, 36);
            panelKwuPsw.BorderStyle = BorderStyle.FixedSingle;
            panelKwuPsw.Controls.Add(textBoxPassword);
            panelKwuPsw.Location = new Point(98, 191);
            panelKwuPsw.Margin = new Padding(2);
            panelKwuPsw.Name = "panelKwuPsw";
            panelKwuPsw.Size = new Size(314, 68);
            panelKwuPsw.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BackColor = Color.FromArgb(36, 36, 36);
            textBoxPassword.BorderStyle = BorderStyle.None;
            textBoxPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxPassword.ForeColor = Color.FromArgb(170, 170, 170);
            textBoxPassword.Location = new Point(2, 18);
            textBoxPassword.Margin = new Padding(2);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PlaceholderText = "PASSWORD";
            textBoxPassword.Size = new Size(305, 32);
            textBoxPassword.TabIndex = 4;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1448, 773);
            Controls.Add(panelLoginKwu);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ImeMode = ImeMode.NoControl;
            Margin = new Padding(2);
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
