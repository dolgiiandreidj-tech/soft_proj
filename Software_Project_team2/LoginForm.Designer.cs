namespace Software_Project_team2
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            textBox1 = new TextBox();
            panel3 = new Panel();
            textBox2 = new TextBox();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 27, 38);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(441, 116);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 520);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(153, 38);
            label1.Name = "label1";
            label1.Size = new Size(193, 45);
            label1.TabIndex = 0;
            label1.Text = "EVERYTIME";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(32, 35, 48);
            panel2.Controls.Add(textBox1);
            panel2.Location = new Point(60, 120);
            panel2.Name = "panel2";
            panel2.Size = new Size(380, 50);
            panel2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(32, 35, 48);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.FromArgb(160, 165, 180);
            textBox1.Location = new Point(15, 15);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(340, 32);
            textBox1.TabIndex = 0;
            textBox1.Text = "아이디";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(32, 35, 48);
            panel3.Controls.Add(textBox2);
            panel3.Location = new Point(60, 185);
            panel3.Name = "panel3";
            panel3.Size = new Size(380, 50);
            panel3.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(32, 35, 48);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.ForeColor = Color.FromArgb(160, 165, 180);
            textBox2.Location = new Point(15, 15);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(340, 32);
            textBox2.TabIndex = 0;
            textBox2.Text = "비밀번호";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 55, 55);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(60, 251);
            button1.Name = "button1";
            button1.Size = new Size(380, 50);
            button1.TabIndex = 4;
            button1.Text = "로그인";
            button1.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 20, 28);
            ClientSize = new Size(1418, 844);
            Controls.Add(panel1);
            Name = "LoginForm";
            Text = "LoginForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private TextBox textBox1;
        private Panel panel3;
        private TextBox textBox2;
        private Button button1;
    }
}