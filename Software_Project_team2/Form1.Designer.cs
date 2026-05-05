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
            labelKWU.Location = new Point(2, 15);
            labelKWU.Margin = new Padding(2, 0, 2, 0);
            labelKWU.Name = "labelKWU";
            labelKWU.Size = new Size(467, 48);
            labelKWU.TabIndex = 0;
            labelKWU.Text = "KWANGWOON UNIVERSITY";
            // 
            // panelLoginKwu
            // 
            panelLoginKwu.BackColor = Color.FromArgb(20, 22, 32);
            panelLoginKwu.Controls.Add(buttonLogin);
            panelLoginKwu.Controls.Add(panelKwuId);
            panelLoginKwu.Controls.Add(labelKWU);
            panelLoginKwu.Controls.Add(panelKwuPsw);
            panelLoginKwu.Location = new Point(460, 164);
            panelLoginKwu.Margin = new Padding(2);
            panelLoginKwu.Name = "panelLoginKwu";
            panelLoginKwu.Size = new Size(500, 450);
            panelLoginKwu.TabIndex = 1;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(98, 120, 255);
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
            panelKwuId.BackColor = Color.FromArgb(26, 27, 27);
            panelKwuId.Controls.Add(textBoxId);
            panelKwuId.Location = new Point(98, 112);
            panelKwuId.Margin = new Padding(2);
            panelKwuId.Name = "panelKwuId";
            panelKwuId.Size = new Size(314, 54);
            panelKwuId.TabIndex = 6;
            // 
            // textBoxId
            // 
            textBoxId.BackColor = Color.FromArgb(26, 27, 27);
            textBoxId.BorderStyle = BorderStyle.None;
            textBoxId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxId.ForeColor = Color.White;
            textBoxId.Location = new Point(2, 2);
            textBoxId.Margin = new Padding(2);
            textBoxId.Name = "textBoxId";
            textBoxId.PlaceholderText = "ID(학번 또는 사번)";
            textBoxId.Size = new Size(308, 32);
            textBoxId.TabIndex = 3;
            // 
            // panelKwuPsw
            // 
            panelKwuPsw.BackColor = Color.FromArgb(26, 27, 27);
            panelKwuPsw.Controls.Add(textBoxPassword);
            panelKwuPsw.Location = new Point(98, 205);
            panelKwuPsw.Margin = new Padding(2);
            panelKwuPsw.Name = "panelKwuPsw";
            panelKwuPsw.Size = new Size(314, 54);
            panelKwuPsw.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BackColor = Color.FromArgb(26, 27, 27);
            textBoxPassword.BorderStyle = BorderStyle.None;
            textBoxPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxPassword.ForeColor = Color.White;
            textBoxPassword.Location = new Point(2, 2);
            textBoxPassword.Margin = new Padding(2);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PlaceholderText = "PASSWORD";
            textBoxPassword.Size = new Size(308, 32);
            textBoxPassword.TabIndex = 4;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 27, 38);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1448, 773);
            Controls.Add(panelLoginKwu);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
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
