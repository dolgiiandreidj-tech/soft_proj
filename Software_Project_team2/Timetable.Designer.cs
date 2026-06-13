namespace Software_Project_team2
{
    partial class Timetable
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
            topPanel = new Panel();
            lblLogo = new Label();
            lblTitle = new Label();
            cmbSemester = new ComboBox();
            cmbYear = new ComboBox();
            btnSearch = new Button();
            richtextSemestr = new RichTextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            label1 = new Label();
            labelclass1 = new Label();
            labelFriday = new Label();
            labelThursday = new Label();
            labelWensday = new Label();
            labelTuesday = new Label();
            labelMonday = new Label();
            labelclass = new Label();
            labelclass2 = new Label();
            labelclass3 = new Label();
            labelclass4 = new Label();
            labelclass5 = new Label();
            labelclass6 = new Label();
            labelclass7 = new Label();
            labelclass8 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            topPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(90, 0, 31);
            topPanel.Controls.Add(lblLogo);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(2, 2, 2, 2);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1306, 32);
            topPanel.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(18, 5);
            lblLogo.Margin = new Padding(2, 0, 2, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(313, 25);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "KWANGWOON UNIVERSITY";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(34, 34, 34);
            lblTitle.Location = new Point(18, 47);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(152, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "수업시간표";
            // 
            // cmbSemester
            // 
            cmbSemester.FormattingEnabled = true;
            cmbSemester.Location = new Point(1086, 52);
            cmbSemester.Margin = new Padding(2, 2, 2, 2);
            cmbSemester.Name = "cmbSemester";
            cmbSemester.Size = new Size(78, 23);
            cmbSemester.TabIndex = 2;
            cmbSemester.Text = "1 학기";
            // 
            // cmbYear
            // 
            cmbYear.FormattingEnabled = true;
            cmbYear.Location = new Point(1004, 52);
            cmbYear.Margin = new Padding(2, 2, 2, 2);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(78, 23);
            cmbYear.TabIndex = 0;
            cmbYear.Text = "2026년도";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(90, 0, 31);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(1184, 47);
            btnSearch.Margin = new Padding(2, 2, 2, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(82, 26);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "시간표 조회";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // richtextSemestr
            // 
            richtextSemestr.BorderStyle = BorderStyle.FixedSingle;
            richtextSemestr.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richtextSemestr.Location = new Point(18, 90);
            richtextSemestr.Margin = new Padding(2, 2, 2, 2);
            richtextSemestr.Name = "richtextSemestr";
            richtextSemestr.ReadOnly = true;
            richtextSemestr.ScrollBars = RichTextBoxScrollBars.None;
            richtextSemestr.Size = new Size(202, 262);
            richtextSemestr.TabIndex = 3;
            richtextSemestr.Text = "📅 현재 학기\n\n2026학년도 1학기\n\n총 학점\n18 학점\n\n신청 과목 수\n6 과목\n\n학적 상태\n● 재학중";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.WhiteSmoke;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.7142916F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.85714F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.8571434F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.8571434F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.8571434F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.8571434F));
            tableLayoutPanel1.Controls.Add(label2, 2, 1);
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Controls.Add(labelclass1, 0, 1);
            tableLayoutPanel1.Controls.Add(labelFriday, 5, 0);
            tableLayoutPanel1.Controls.Add(labelThursday, 4, 0);
            tableLayoutPanel1.Controls.Add(labelWensday, 3, 0);
            tableLayoutPanel1.Controls.Add(labelTuesday, 2, 0);
            tableLayoutPanel1.Controls.Add(labelMonday, 1, 0);
            tableLayoutPanel1.Controls.Add(labelclass, 0, 0);
            tableLayoutPanel1.Controls.Add(labelclass2, 0, 2);
            tableLayoutPanel1.Controls.Add(labelclass3, 0, 3);
            tableLayoutPanel1.Controls.Add(labelclass4, 0, 4);
            tableLayoutPanel1.Controls.Add(labelclass5, 0, 5);
            tableLayoutPanel1.Controls.Add(labelclass6, 0, 6);
            tableLayoutPanel1.Controls.Add(labelclass7, 0, 7);
            tableLayoutPanel1.Controls.Add(labelclass8, 0, 8);
            tableLayoutPanel1.Controls.Add(label3, 2, 2);
            tableLayoutPanel1.Controls.Add(label4, 3, 3);
            tableLayoutPanel1.Controls.Add(label5, 3, 4);
            tableLayoutPanel1.Controls.Add(label6, 4, 6);
            tableLayoutPanel1.Controls.Add(label7, 5, 2);
            tableLayoutPanel1.Controls.Add(label8, 1, 5);
            tableLayoutPanel1.Location = new Point(242, 90);
            tableLayoutPanel1.Margin = new Padding(2, 2, 2, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.100801F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.3623981F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.3623981F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.3623981F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.3623981F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.3623981F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.3623981F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.3623981F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.3623981F));
            tableLayoutPanel1.Size = new Size(1026, 455);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.OldLace;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(295, 42);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(177, 50);
            label2.TabIndex = 14;
            label2.Text = "C# 프로그래밍\r\n310-1";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightBlue;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(113, 42);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(177, 50);
            label1.TabIndex = 5;
            label1.Text = "C# 프로그래밍\r\n310-1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelclass1
            // 
            labelclass1.AutoSize = true;
            labelclass1.BackColor = Color.Gainsboro;
            labelclass1.Dock = DockStyle.Fill;
            labelclass1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelclass1.Location = new Point(3, 42);
            labelclass1.Margin = new Padding(2, 0, 2, 0);
            labelclass1.Name = "labelclass1";
            labelclass1.Size = new Size(105, 50);
            labelclass1.TabIndex = 6;
            labelclass1.Text = "1교시\r\n09:00~10:15";
            labelclass1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelFriday
            // 
            labelFriday.AutoSize = true;
            labelFriday.BackColor = Color.Gainsboro;
            labelFriday.Dock = DockStyle.Fill;
            labelFriday.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFriday.Location = new Point(841, 1);
            labelFriday.Margin = new Padding(2, 0, 2, 0);
            labelFriday.Name = "labelFriday";
            labelFriday.Size = new Size(182, 40);
            labelFriday.TabIndex = 5;
            labelFriday.Text = "금요일";
            labelFriday.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelThursday
            // 
            labelThursday.AutoSize = true;
            labelThursday.BackColor = Color.Gainsboro;
            labelThursday.Dock = DockStyle.Fill;
            labelThursday.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelThursday.Location = new Point(659, 1);
            labelThursday.Margin = new Padding(2, 0, 2, 0);
            labelThursday.Name = "labelThursday";
            labelThursday.Size = new Size(177, 40);
            labelThursday.TabIndex = 4;
            labelThursday.Text = "목요일";
            labelThursday.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelWensday
            // 
            labelWensday.AutoSize = true;
            labelWensday.BackColor = Color.Gainsboro;
            labelWensday.Dock = DockStyle.Fill;
            labelWensday.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelWensday.Location = new Point(477, 1);
            labelWensday.Margin = new Padding(2, 0, 2, 0);
            labelWensday.Name = "labelWensday";
            labelWensday.Size = new Size(177, 40);
            labelWensday.TabIndex = 3;
            labelWensday.Text = "수요일";
            labelWensday.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTuesday
            // 
            labelTuesday.AutoSize = true;
            labelTuesday.BackColor = Color.Gainsboro;
            labelTuesday.Dock = DockStyle.Fill;
            labelTuesday.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTuesday.Location = new Point(295, 1);
            labelTuesday.Margin = new Padding(2, 0, 2, 0);
            labelTuesday.Name = "labelTuesday";
            labelTuesday.Size = new Size(177, 40);
            labelTuesday.TabIndex = 2;
            labelTuesday.Text = "화요일";
            labelTuesday.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelMonday
            // 
            labelMonday.AutoSize = true;
            labelMonday.BackColor = Color.Gainsboro;
            labelMonday.Dock = DockStyle.Fill;
            labelMonday.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMonday.Location = new Point(113, 1);
            labelMonday.Margin = new Padding(2, 0, 2, 0);
            labelMonday.Name = "labelMonday";
            labelMonday.Size = new Size(177, 40);
            labelMonday.TabIndex = 1;
            labelMonday.Text = "월요일";
            labelMonday.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelclass
            // 
            labelclass.AutoSize = true;
            labelclass.BackColor = Color.Gainsboro;
            labelclass.Dock = DockStyle.Fill;
            labelclass.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelclass.Location = new Point(3, 1);
            labelclass.Margin = new Padding(2, 0, 2, 0);
            labelclass.Name = "labelclass";
            labelclass.Size = new Size(105, 40);
            labelclass.TabIndex = 0;
            labelclass.Text = "교시";
            labelclass.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelclass2
            // 
            labelclass2.AutoSize = true;
            labelclass2.BackColor = Color.Gainsboro;
            labelclass2.Dock = DockStyle.Fill;
            labelclass2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelclass2.Location = new Point(3, 93);
            labelclass2.Margin = new Padding(2, 0, 2, 0);
            labelclass2.Name = "labelclass2";
            labelclass2.Size = new Size(105, 50);
            labelclass2.TabIndex = 7;
            labelclass2.Text = "2교시\r\n10:30~11:45";
            labelclass2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelclass3
            // 
            labelclass3.AutoSize = true;
            labelclass3.BackColor = Color.Gainsboro;
            labelclass3.Dock = DockStyle.Fill;
            labelclass3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelclass3.Location = new Point(3, 144);
            labelclass3.Margin = new Padding(2, 0, 2, 0);
            labelclass3.Name = "labelclass3";
            labelclass3.Size = new Size(105, 50);
            labelclass3.TabIndex = 8;
            labelclass3.Text = "3교시\r\n12:00~13:15";
            labelclass3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelclass4
            // 
            labelclass4.AutoSize = true;
            labelclass4.BackColor = Color.Gainsboro;
            labelclass4.Dock = DockStyle.Fill;
            labelclass4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelclass4.Location = new Point(3, 195);
            labelclass4.Margin = new Padding(2, 0, 2, 0);
            labelclass4.Name = "labelclass4";
            labelclass4.Size = new Size(105, 50);
            labelclass4.TabIndex = 9;
            labelclass4.Text = "4교시\r\n13:30~14:45";
            labelclass4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelclass5
            // 
            labelclass5.AutoSize = true;
            labelclass5.BackColor = Color.Gainsboro;
            labelclass5.Dock = DockStyle.Fill;
            labelclass5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelclass5.Location = new Point(3, 246);
            labelclass5.Margin = new Padding(2, 0, 2, 0);
            labelclass5.Name = "labelclass5";
            labelclass5.Size = new Size(105, 50);
            labelclass5.TabIndex = 10;
            labelclass5.Text = "5교시\r\n15:00~16:15";
            labelclass5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelclass6
            // 
            labelclass6.AutoSize = true;
            labelclass6.BackColor = Color.Gainsboro;
            labelclass6.Dock = DockStyle.Fill;
            labelclass6.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelclass6.Location = new Point(3, 297);
            labelclass6.Margin = new Padding(2, 0, 2, 0);
            labelclass6.Name = "labelclass6";
            labelclass6.Size = new Size(105, 50);
            labelclass6.TabIndex = 11;
            labelclass6.Text = "6교시\r\n16:30~17:45";
            labelclass6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelclass7
            // 
            labelclass7.AutoSize = true;
            labelclass7.BackColor = Color.Gainsboro;
            labelclass7.Dock = DockStyle.Fill;
            labelclass7.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelclass7.Location = new Point(3, 348);
            labelclass7.Margin = new Padding(2, 0, 2, 0);
            labelclass7.Name = "labelclass7";
            labelclass7.Size = new Size(105, 50);
            labelclass7.TabIndex = 12;
            labelclass7.Text = "7교시\r\n18:00~19:15";
            labelclass7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelclass8
            // 
            labelclass8.AutoSize = true;
            labelclass8.BackColor = Color.Gainsboro;
            labelclass8.Dock = DockStyle.Fill;
            labelclass8.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelclass8.Location = new Point(3, 399);
            labelclass8.Margin = new Padding(2, 0, 2, 0);
            labelclass8.Name = "labelclass8";
            labelclass8.Size = new Size(105, 55);
            labelclass8.TabIndex = 13;
            labelclass8.Text = "8교시\r\n19:30~20:45";
            labelclass8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightGreen;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(295, 93);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(177, 50);
            label3.TabIndex = 15;
            label3.Text = "C# 프로그래밍\r\n310-1";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.NavajoWhite;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(477, 144);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(177, 50);
            label4.TabIndex = 16;
            label4.Text = "C# 프로그래밍\r\n310-1";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.SandyBrown;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(477, 195);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(177, 50);
            label5.TabIndex = 17;
            label5.Text = "C# 프로그래밍\r\n310-1";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Plum;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(659, 297);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(177, 50);
            label6.TabIndex = 18;
            label6.Text = "C# 프로그래밍\r\n310-1";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Pink;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(841, 93);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(182, 50);
            label7.TabIndex = 19;
            label7.Text = "C# 프로그래밍\r\n310-1";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.CornflowerBlue;
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(113, 246);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(177, 50);
            label8.TabIndex = 20;
            label8.Text = "C# 프로그래밍\r\n310-1";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Timetable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1306, 575);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(richtextSemestr);
            Controls.Add(btnSearch);
            Controls.Add(cmbSemester);
            Controls.Add(cmbYear);
            Controls.Add(lblTitle);
            Controls.Add(topPanel);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Timetable";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "수업시간표";
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel topPanel;
        private Label lblLogo;
        private Label lblTitle;
        private ComboBox cmbSemester;
        private ComboBox cmbYear;
        private Button btnSearch;
        private RichTextBox richtextSemestr;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelclass;
        private Label labelFriday;
        private Label labelThursday;
        private Label labelWensday;
        private Label labelTuesday;
        private Label labelMonday;
        private Label labelclass1;
        private Label labelclass2;
        private Label labelclass3;
        private Label labelclass4;
        private Label labelclass5;
        private Label labelclass6;
        private Label labelclass7;
        private Label labelclass8;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}