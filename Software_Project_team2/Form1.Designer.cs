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
            label1 = new Label();
            panel1 = new Panel();
            textBox1 = new TextBox();
            panel2 = new Panel();
            textBox2 = new TextBox();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Malgun Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(153, 50);
            label1.Name = "label1";
            label1.Size = new Size(426, 45);
            label1.TabIndex = 0;
            label1.Text = "KWANGWOON UNIVERSITY";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Brown;
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(224, 122);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 44);
            panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Brown;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(6, 3);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "ID(학번 또는 사번)";
            textBox1.Size = new Size(294, 24);
            textBox1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Brown;
            panel2.Controls.Add(textBox2);
            panel2.Location = new Point(224, 187);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 44);
            panel2.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Brown;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(3, 3);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "PASSWORD";
            textBox2.Size = new Size(297, 24);
            textBox2.TabIndex = 4;
            textBox2.UseSystemPasswordChar = true;
            textBox2.TextChanged += textBox2_TextChanged;
            textBox2.Enter += textBox2_Enter;
            textBox2.Leave += textBox2_Leave;
            // 
            // button1
            // 
            button1.BackColor = Color.Brown;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(314, 246);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 5;
            button1.Text = "로그인";
            button1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(739, 450);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
    }
}
