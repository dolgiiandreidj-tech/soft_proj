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
            mainPanel = new Panel();
            lblTitle = new Label();
            filterPanel = new Panel();
            cmbYear = new ComboBox();
            cmbSemester = new ComboBox();
            btnSearch = new Button();
            topPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            filterPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(90, 0, 31);
            topPanel.Controls.Add(lblLogo);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1378, 54);
            topPanel.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(25, 9);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(449, 36);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "KWANGWOON UNIVERSITY";
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(filterPanel);
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Location = new Point(59, 84);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1240, 636);
            mainPanel.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(34, 34, 34);
            lblTitle.Location = new Point(28, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(223, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "수업시간표";
            // 
            // filterPanel
            // 
            filterPanel.BorderStyle = BorderStyle.FixedSingle;
            filterPanel.Controls.Add(btnSearch);
            filterPanel.Controls.Add(cmbSemester);
            filterPanel.Controls.Add(cmbYear);
            filterPanel.Location = new Point(28, 82);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(1158, 40);
            filterPanel.TabIndex = 1;
            // 
            // cmbYear
            // 
            cmbYear.FormattingEnabled = true;
            cmbYear.Location = new Point(432, 4);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(110, 33);
            cmbYear.TabIndex = 0;
            cmbYear.Text = "2026년도";
            // 
            // cmbSemester
            // 
            cmbSemester.FormattingEnabled = true;
            cmbSemester.Location = new Point(548, 3);
            cmbSemester.Name = "cmbSemester";
            cmbSemester.Size = new Size(110, 33);
            cmbSemester.TabIndex = 2;
            cmbSemester.Text = "1 학기";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(124, 124, 124);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(674, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(118, 34);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "시간표 조회";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // Timetable
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(1378, 764);
            Controls.Add(mainPanel);
            Controls.Add(topPanel);
            Name = "Timetable";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "수업시간표";
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            filterPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel topPanel;
        private Label lblLogo;
        private Panel mainPanel;
        private Label lblTitle;
        private Button btnSearch;
        private Panel filterPanel;
        private ComboBox cmbSemester;
        private ComboBox cmbYear;
    }
}