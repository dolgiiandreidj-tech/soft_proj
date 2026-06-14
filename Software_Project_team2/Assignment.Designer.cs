namespace Software_Project_team2
{
    partial class Assignment
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
            lblTitleGrade = new Label();
            listBoxMaterial = new ListBox();
            labelMatherial = new Label();
            listBoxTask = new ListBox();
            labelTask = new Label();
            listBoxNotice = new ListBox();
            labelNotice = new Label();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(90, 0, 31);
            topPanel.Controls.Add(lblLogo);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(2);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1253, 34);
            topPanel.TabIndex = 2;
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
            // lblTitleGrade
            // 
            lblTitleGrade.AutoSize = true;
            lblTitleGrade.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleGrade.ForeColor = Color.FromArgb(34, 34, 34);
            lblTitleGrade.Location = new Point(18, 47);
            lblTitleGrade.Margin = new Padding(2, 0, 2, 0);
            lblTitleGrade.Name = "lblTitleGrade";
            lblTitleGrade.Size = new Size(178, 40);
            lblTitleGrade.TabIndex = 4;
            lblTitleGrade.Text = "과제 및 자료";
            // 
            // listBoxMaterial
            // 
            listBoxMaterial.BorderStyle = BorderStyle.FixedSingle;
            listBoxMaterial.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBoxMaterial.FormattingEnabled = true;
            listBoxMaterial.IntegralHeight = false;
            listBoxMaterial.ItemHeight = 20;
            listBoxMaterial.Items.AddRange(new object[] { "📄 Week 1 - C# 기초.pdf", "", "📄 Week 2 - 객체지향 프로그래밍.pdf", "", "📄 Week 3 - ASP.NET 개요.pptx", "", "📦 Week 4 - ADO.NET 실습자료.zip", "", "📄 Database 설계.pdf" });
            listBoxMaterial.Location = new Point(841, 128);
            listBoxMaterial.Name = "listBoxMaterial";
            listBoxMaterial.Size = new Size(368, 445);
            listBoxMaterial.TabIndex = 0;
            listBoxMaterial.SelectedIndexChanged += listBoxMaterial_SelectedIndexChanged;
            // 
            // labelMatherial
            // 
            labelMatherial.BackColor = Color.White;
            labelMatherial.BorderStyle = BorderStyle.FixedSingle;
            labelMatherial.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMatherial.ForeColor = Color.Black;
            labelMatherial.Location = new Point(841, 100);
            labelMatherial.Name = "labelMatherial";
            labelMatherial.Size = new Size(368, 25);
            labelMatherial.TabIndex = 10;
            labelMatherial.Text = "📚 강의자료";
            // 
            // listBoxTask
            // 
            listBoxTask.BorderStyle = BorderStyle.FixedSingle;
            listBoxTask.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBoxTask.FormattingEnabled = true;
            listBoxTask.IntegralHeight = false;
            listBoxTask.ItemHeight = 20;
            listBoxTask.Items.AddRange(new object[] { "ASP.NET 과제 1", "마감: 2026-06-20", "상태: 미제출", "", "ASP.NET 과제 2", "마감: 2026-06-25", "상태: 제출완료", "", "DB 과제 3", "마감: 2026-06-30", "상태: 진행중" });
            listBoxTask.Location = new Point(429, 128);
            listBoxTask.Name = "listBoxTask";
            listBoxTask.Size = new Size(368, 445);
            listBoxTask.TabIndex = 11;
            // 
            // labelTask
            // 
            labelTask.BackColor = Color.White;
            labelTask.BorderStyle = BorderStyle.FixedSingle;
            labelTask.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTask.ForeColor = Color.Black;
            labelTask.Location = new Point(429, 100);
            labelTask.Name = "labelTask";
            labelTask.Size = new Size(368, 25);
            labelTask.TabIndex = 12;
            labelTask.Text = "📋 과제";
            // 
            // listBoxNotice
            // 
            listBoxNotice.BorderStyle = BorderStyle.FixedSingle;
            listBoxNotice.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBoxNotice.FormattingEnabled = true;
            listBoxNotice.IntegralHeight = false;
            listBoxNotice.ItemHeight = 20;
            listBoxNotice.Items.AddRange(new object[] { "📌 과제 제출 안내", "2026-06-10", "", "📌 프로젝트 공지", "2026-06-01", "", "📌 기말 발표 안내", "2026-05-25", "", "📌 강의 자료 업로드 안내", "2026-05-20" });
            listBoxNotice.Location = new Point(20, 128);
            listBoxNotice.Name = "listBoxNotice";
            listBoxNotice.Size = new Size(368, 445);
            listBoxNotice.TabIndex = 13;
            // 
            // labelNotice
            // 
            labelNotice.BackColor = Color.White;
            labelNotice.BorderStyle = BorderStyle.FixedSingle;
            labelNotice.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNotice.ForeColor = Color.Black;
            labelNotice.Location = new Point(20, 100);
            labelNotice.Name = "labelNotice";
            labelNotice.Size = new Size(368, 25);
            labelNotice.TabIndex = 14;
            labelNotice.Text = "📢 공지사항";
            // 
            // Assignment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1253, 596);
            Controls.Add(labelNotice);
            Controls.Add(listBoxNotice);
            Controls.Add(labelTask);
            Controls.Add(listBoxTask);
            Controls.Add(labelMatherial);
            Controls.Add(listBoxMaterial);
            Controls.Add(lblTitleGrade);
            Controls.Add(topPanel);
            Name = "Assignment";
            Text = "Assignment";
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel topPanel;
        private Label lblLogo;
        private Label lblTitleGrade;
        private ListBox listBoxMaterial;
        private Label labelMatherial;
        private ListBox listBoxTask;
        private Label labelTask;
        private ListBox listBoxNotice;
        private Label labelNotice;
    }
}