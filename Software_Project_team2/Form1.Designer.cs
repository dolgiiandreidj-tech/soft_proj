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
            label1 = new Label();
            panel1 = new Panel();
            textBox1 = new TextBox();
            panel2 = new Panel();
            textBox2 = new TextBox();
            button1 = new Button();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(20, 21);
            label1.Name = "label1";
            label1.Size = new Size(467, 48);
            label1.TabIndex = 0;
            label1.Text = "KWANGWOON UNIVERSITY";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(20, 22, 32);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(460, 164);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 450);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(26, 27, 27);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(3, 3);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "ID(학번 또는 사번)";
            textBox1.Size = new Size(308, 32);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(26, 27, 27);
            panel2.Controls.Add(textBox2);
            panel2.Location = new Point(97, 205);
            panel2.Name = "panel2";
            panel2.Size = new Size(314, 54);
            panel2.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(26, 27, 27);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(3, 3);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "PASSWORD";
            textBox2.Size = new Size(308, 32);
            textBox2.TabIndex = 4;
            textBox2.UseSystemPasswordChar = true;
            textBox2.TextChanged += textBox2_TextChanged;
            textBox2.Enter += textBox2_Enter;
            textBox2.Leave += textBox2_Leave;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(98, 120, 255);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(191, 295);
            button1.Name = "button1";
            button1.Size = new Size(120, 39);
            button1.TabIndex = 5;
            button1.Text = "로그인";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(26, 27, 27);
            panel3.Controls.Add(textBox1);
            panel3.Location = new Point(97, 112);
            panel3.Name = "panel3";
            panel3.Size = new Size(314, 54);
            panel3.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 27, 38);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1418, 844);
            Controls.Add(panel1);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Panel panel3;
    }
}
