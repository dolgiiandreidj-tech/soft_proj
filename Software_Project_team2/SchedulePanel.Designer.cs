namespace Software_Project_team2
{
    partial class SchedulePanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSearchHint;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.RadioButton rbProf;
        private System.Windows.Forms.RadioButton rbClass;
        private System.Windows.Forms.Panel panelByProf;
        private System.Windows.Forms.Label lblByProf;
        private System.Windows.Forms.ListBox lstByProf;
        private System.Windows.Forms.Panel panelByClass;
        private System.Windows.Forms.Label lblByClass;
        private System.Windows.Forms.ListBox lstByClass;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Label lblDetailHeader;
        private System.Windows.Forms.Label lblDetailName;
        private System.Windows.Forms.Label lblDetailProfessor;
        private System.Windows.Forms.Label lblDetailCode;
        private System.Windows.Forms.Label lblDetailRating;
        private System.Windows.Forms.Label lblDetailReviews;
        private System.Windows.Forms.Label lblDetailStatus;
        private System.Windows.Forms.Panel panelSyllabus;
        private System.Windows.Forms.Label lblSyllabusHeader;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelReviews;
        private System.Windows.Forms.Label lblReviewsHeader;
        private System.Windows.Forms.FlowLayoutPanel flowReviews;

        private void InitializeComponent()
        {
            lblHeader = new Label();
            lblSearchHint = new Label();
            txtSearch = new TextBox();
            btnGo = new Button();
            rbProf = new RadioButton();
            rbClass = new RadioButton();
            panelByProf = new Panel();
            lstByProf = new ListBox();
            lblByProf = new Label();
            panelByClass = new Panel();
            lstByClass = new ListBox();
            lblByClass = new Label();
            panelDetail = new Panel();
            lblDetailStatus = new Label();
            lblDetailReviews = new Label();
            lblDetailRating = new Label();
            lblDetailCode = new Label();
            lblDetailProfessor = new Label();
            lblDetailName = new Label();
            lblDetailHeader = new Label();
            panelSyllabus = new Panel();
            lblSyllabusHeader = new Label();
            lblStatus = new Label();
            panelReviews = new Panel();
            flowReviews = new FlowLayoutPanel();
            lblReviewsHeader = new Label();
            topPanel = new Panel();
            panelByProf.SuspendLayout();
            panelByClass.SuspendLayout();
            panelDetail.SuspendLayout();
            panelSyllabus.SuspendLayout();
            panelReviews.SuspendLayout();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.BackColor = Color.Transparent;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Transparent;
            lblHeader.Location = new Point(26, 15);
            lblHeader.Margin = new Padding(4, 0, 4, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(315, 45);
            lblHeader.TabIndex = 10;
            lblHeader.Text = "Everytime 강의 검색";
            // 
            // lblSearchHint
            // 
            lblSearchHint.AutoSize = true;
            lblSearchHint.BackColor = Color.Transparent;
            lblSearchHint.Font = new Font("Segoe UI", 10F);
            lblSearchHint.ForeColor = Color.White;
            lblSearchHint.Location = new Point(26, 68);
            lblSearchHint.Margin = new Padding(4, 0, 4, 0);
            lblSearchHint.Name = "lblSearchHint";
            lblSearchHint.Size = new Size(396, 28);
            lblSearchHint.TabIndex = 9;
            lblSearchHint.Text = "search for class from everytime (review, info)";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(224, 224, 224);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.ForeColor = Color.Black;
            txtSearch.Location = new Point(26, 138);
            txtSearch.Margin = new Padding(4, 3, 4, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "type here";
            txtSearch.Size = new Size(1351, 39);
            txtSearch.TabIndex = 0;
            // 
            // btnGo
            // 
            btnGo.BackColor = Color.FromArgb(90, 0, 31);
            btnGo.Cursor = Cursors.Hand;
            btnGo.FlatAppearance.BorderSize = 0;
            btnGo.FlatAppearance.MouseOverBackColor = Color.FromArgb(120, 140, 255);
            btnGo.FlatStyle = FlatStyle.Flat;
            btnGo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGo.ForeColor = Color.White;
            btnGo.Location = new Point(1394, 138);
            btnGo.Margin = new Padding(4, 3, 4, 3);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(126, 48);
            btnGo.TabIndex = 1;
            btnGo.Text = "GO";
            btnGo.UseVisualStyleBackColor = false;
            // 
            // rbProf
            // 
            rbProf.AutoSize = true;
            rbProf.BackColor = Color.Transparent;
            rbProf.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbProf.ForeColor = Color.Black;
            rbProf.Location = new Point(26, 202);
            rbProf.Margin = new Padding(4, 3, 4, 3);
            rbProf.Name = "rbProf";
            rbProf.Size = new Size(154, 35);
            rbProf.TabIndex = 2;
            rbProf.Text = "교수 (prof)";
            rbProf.UseVisualStyleBackColor = false;
            // 
            // rbClass
            // 
            rbClass.AutoSize = true;
            rbClass.BackColor = Color.Transparent;
            rbClass.Checked = true;
            rbClass.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbClass.ForeColor = Color.Black;
            rbClass.Location = new Point(211, 202);
            rbClass.Margin = new Padding(4, 3, 4, 3);
            rbClass.Name = "rbClass";
            rbClass.Size = new Size(180, 35);
            rbClass.TabIndex = 3;
            rbClass.TabStop = true;
            rbClass.Text = "강의명 (class)";
            rbClass.UseVisualStyleBackColor = false;
            // 
            // panelByProf
            // 
            panelByProf.BackColor = Color.FromArgb(252, 252, 252);
            panelByProf.BorderStyle = BorderStyle.FixedSingle;
            panelByProf.Controls.Add(lstByProf);
            panelByProf.Controls.Add(lblByProf);
            panelByProf.Location = new Point(26, 250);
            panelByProf.Margin = new Padding(4, 3, 4, 3);
            panelByProf.Name = "panelByProf";
            panelByProf.Padding = new Padding(20, 20, 20, 20);
            panelByProf.Size = new Size(401, 639);
            panelByProf.TabIndex = 4;
            // 
            // lstByProf
            // 
            lstByProf.BackColor = Color.FromArgb(252, 252, 252);
            lstByProf.BorderStyle = BorderStyle.None;
            lstByProf.Font = new Font("Segoe UI", 10F);
            lstByProf.ForeColor = Color.Black;
            lstByProf.FormattingEnabled = true;
            lstByProf.IntegralHeight = false;
            lstByProf.ItemHeight = 28;
            lstByProf.Location = new Point(20, 62);
            lstByProf.Margin = new Padding(4, 3, 4, 3);
            lstByProf.Name = "lstByProf";
            lstByProf.Size = new Size(360, 555);
            lstByProf.TabIndex = 0;
            // 
            // lblByProf
            // 
            lblByProf.AutoSize = true;
            lblByProf.BackColor = Color.Transparent;
            lblByProf.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblByProf.ForeColor = Color.Black;
            lblByProf.Location = new Point(20, 18);
            lblByProf.Margin = new Padding(4, 0, 4, 0);
            lblByProf.Name = "lblByProf";
            lblByProf.Size = new Size(129, 30);
            lblByProf.TabIndex = 1;
            lblByProf.Text = "교수명 결과";
            // 
            // panelByClass
            // 
            panelByClass.BackColor = Color.FromArgb(252, 252, 252);
            panelByClass.BorderStyle = BorderStyle.FixedSingle;
            panelByClass.Controls.Add(lstByClass);
            panelByClass.Controls.Add(lblByClass);
            panelByClass.Location = new Point(439, 250);
            panelByClass.Margin = new Padding(4, 3, 4, 3);
            panelByClass.Name = "panelByClass";
            panelByClass.Padding = new Padding(20, 20, 20, 20);
            panelByClass.Size = new Size(401, 639);
            panelByClass.TabIndex = 5;
            // 
            // lstByClass
            // 
            lstByClass.BackColor = Color.FromArgb(252, 252, 252);
            lstByClass.BorderStyle = BorderStyle.None;
            lstByClass.Font = new Font("Segoe UI", 10F);
            lstByClass.ForeColor = Color.Black;
            lstByClass.FormattingEnabled = true;
            lstByClass.IntegralHeight = false;
            lstByClass.ItemHeight = 28;
            lstByClass.Location = new Point(20, 62);
            lstByClass.Margin = new Padding(4, 3, 4, 3);
            lstByClass.Name = "lstByClass";
            lstByClass.Size = new Size(360, 555);
            lstByClass.TabIndex = 0;
            // 
            // lblByClass
            // 
            lblByClass.AutoSize = true;
            lblByClass.BackColor = Color.Transparent;
            lblByClass.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblByClass.ForeColor = Color.Black;
            lblByClass.Location = new Point(20, 18);
            lblByClass.Margin = new Padding(4, 0, 4, 0);
            lblByClass.Name = "lblByClass";
            lblByClass.Size = new Size(129, 30);
            lblByClass.TabIndex = 1;
            lblByClass.Text = "강의명 결과";
            // 
            // panelDetail
            // 
            panelDetail.BackColor = Color.FromArgb(252, 252, 252);
            panelDetail.BorderStyle = BorderStyle.FixedSingle;
            panelDetail.Controls.Add(lblDetailStatus);
            panelDetail.Controls.Add(lblDetailReviews);
            panelDetail.Controls.Add(lblDetailRating);
            panelDetail.Controls.Add(lblDetailCode);
            panelDetail.Controls.Add(lblDetailProfessor);
            panelDetail.Controls.Add(lblDetailName);
            panelDetail.Controls.Add(lblDetailHeader);
            panelDetail.Location = new Point(850, 250);
            panelDetail.Margin = new Padding(4, 3, 4, 3);
            panelDetail.Name = "panelDetail";
            panelDetail.Padding = new Padding(20, 20, 20, 20);
            panelDetail.Size = new Size(675, 312);
            panelDetail.TabIndex = 6;
            // 
            // lblDetailStatus
            // 
            lblDetailStatus.AutoSize = true;
            lblDetailStatus.BackColor = Color.Transparent;
            lblDetailStatus.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblDetailStatus.ForeColor = Color.FromArgb(140, 145, 160);
            lblDetailStatus.Location = new Point(20, 268);
            lblDetailStatus.Margin = new Padding(4, 0, 4, 0);
            lblDetailStatus.Name = "lblDetailStatus";
            lblDetailStatus.Size = new Size(0, 25);
            lblDetailStatus.TabIndex = 0;
            // 
            // lblDetailReviews
            // 
            lblDetailReviews.AutoSize = true;
            lblDetailReviews.BackColor = Color.Transparent;
            lblDetailReviews.Font = new Font("Segoe UI", 11F);
            lblDetailReviews.ForeColor = Color.FromArgb(70, 75, 90);
            lblDetailReviews.Location = new Point(150, 212);
            lblDetailReviews.Margin = new Padding(4, 0, 4, 0);
            lblDetailReviews.Name = "lblDetailReviews";
            lblDetailReviews.Size = new Size(0, 30);
            lblDetailReviews.TabIndex = 1;
            // 
            // lblDetailRating
            // 
            lblDetailRating.AutoSize = true;
            lblDetailRating.BackColor = Color.Transparent;
            lblDetailRating.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDetailRating.ForeColor = Color.FromArgb(255, 200, 90);
            lblDetailRating.Location = new Point(20, 202);
            lblDetailRating.Margin = new Padding(4, 0, 4, 0);
            lblDetailRating.Name = "lblDetailRating";
            lblDetailRating.Size = new Size(0, 38);
            lblDetailRating.TabIndex = 2;
            // 
            // lblDetailCode
            // 
            lblDetailCode.AutoSize = true;
            lblDetailCode.BackColor = Color.Transparent;
            lblDetailCode.Font = new Font("Segoe UI", 11F);
            lblDetailCode.ForeColor = Color.FromArgb(70, 75, 90);
            lblDetailCode.Location = new Point(20, 160);
            lblDetailCode.Margin = new Padding(4, 0, 4, 0);
            lblDetailCode.Name = "lblDetailCode";
            lblDetailCode.Size = new Size(0, 30);
            lblDetailCode.TabIndex = 3;
            // 
            // lblDetailProfessor
            // 
            lblDetailProfessor.AutoSize = true;
            lblDetailProfessor.BackColor = Color.Transparent;
            lblDetailProfessor.Font = new Font("Segoe UI", 11F);
            lblDetailProfessor.ForeColor = Color.FromArgb(50, 55, 65);
            lblDetailProfessor.Location = new Point(20, 120);
            lblDetailProfessor.Margin = new Padding(4, 0, 4, 0);
            lblDetailProfessor.Name = "lblDetailProfessor";
            lblDetailProfessor.Size = new Size(0, 30);
            lblDetailProfessor.TabIndex = 4;
            // 
            // lblDetailName
            // 
            lblDetailName.AutoSize = true;
            lblDetailName.BackColor = Color.Transparent;
            lblDetailName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDetailName.ForeColor = Color.Black;
            lblDetailName.Location = new Point(20, 65);
            lblDetailName.Margin = new Padding(4, 0, 4, 0);
            lblDetailName.MaximumSize = new Size(634, 0);
            lblDetailName.Name = "lblDetailName";
            lblDetailName.Size = new Size(0, 38);
            lblDetailName.TabIndex = 5;
            // 
            // lblDetailHeader
            // 
            lblDetailHeader.AutoSize = true;
            lblDetailHeader.BackColor = Color.Transparent;
            lblDetailHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailHeader.ForeColor = Color.Black;
            lblDetailHeader.Location = new Point(20, 18);
            lblDetailHeader.Margin = new Padding(4, 0, 4, 0);
            lblDetailHeader.Name = "lblDetailHeader";
            lblDetailHeader.Size = new Size(107, 30);
            lblDetailHeader.TabIndex = 6;
            lblDetailHeader.Text = "강의 상세";
            // 
            // panelSyllabus
            // 
            panelSyllabus.BackColor = Color.FromArgb(252, 252, 252);
            panelSyllabus.BorderStyle = BorderStyle.FixedSingle;
            panelSyllabus.Controls.Add(lblSyllabusHeader);
            panelSyllabus.Location = new Point(850, 588);
            panelSyllabus.Margin = new Padding(4, 3, 4, 3);
            panelSyllabus.Name = "panelSyllabus";
            panelSyllabus.Padding = new Padding(20, 20, 20, 20);
            panelSyllabus.Size = new Size(675, 300);
            panelSyllabus.TabIndex = 7;
            // 
            // lblSyllabusHeader
            // 
            lblSyllabusHeader.AutoSize = true;
            lblSyllabusHeader.BackColor = Color.Transparent;
            lblSyllabusHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSyllabusHeader.ForeColor = Color.Black;
            lblSyllabusHeader.Location = new Point(20, 18);
            lblSyllabusHeader.Margin = new Padding(4, 0, 4, 0);
            lblSyllabusHeader.Name = "lblSyllabusHeader";
            lblSyllabusHeader.Size = new Size(123, 30);
            lblSyllabusHeader.TabIndex = 1;
            lblSyllabusHeader.Text = "강의계획서";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.FromArgb(160, 165, 180);
            lblStatus.Location = new Point(26, 1350);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 28);
            lblStatus.TabIndex = 0;
            // 
            // panelReviews
            // 
            panelReviews.BackColor = Color.FromArgb(252, 252, 252);
            panelReviews.BorderStyle = BorderStyle.FixedSingle;
            panelReviews.Controls.Add(flowReviews);
            panelReviews.Controls.Add(lblReviewsHeader);
            panelReviews.Location = new Point(26, 912);
            panelReviews.Margin = new Padding(4, 3, 4, 3);
            panelReviews.Name = "panelReviews";
            panelReviews.Padding = new Padding(20, 20, 20, 20);
            panelReviews.Size = new Size(1501, 425);
            panelReviews.TabIndex = 8;
            // 
            // flowReviews
            // 
            flowReviews.AutoScroll = true;
            flowReviews.BackColor = Color.FromArgb(252, 252, 252);
            flowReviews.BorderStyle = BorderStyle.FixedSingle;
            flowReviews.FlowDirection = FlowDirection.TopDown;
            flowReviews.Location = new Point(20, 58);
            flowReviews.Margin = new Padding(4, 3, 4, 3);
            flowReviews.Name = "flowReviews";
            flowReviews.Size = new Size(1461, 349);
            flowReviews.TabIndex = 0;
            flowReviews.WrapContents = false;
            // 
            // lblReviewsHeader
            // 
            lblReviewsHeader.AutoSize = true;
            lblReviewsHeader.BackColor = Color.Transparent;
            lblReviewsHeader.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReviewsHeader.ForeColor = Color.Black;
            lblReviewsHeader.Location = new Point(20, 18);
            lblReviewsHeader.Margin = new Padding(4, 0, 4, 0);
            lblReviewsHeader.Name = "lblReviewsHeader";
            lblReviewsHeader.Size = new Size(135, 31);
            lblReviewsHeader.TabIndex = 1;
            lblReviewsHeader.Text = "최근 강의평";
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(90, 0, 31);
            topPanel.Controls.Add(lblHeader);
            topPanel.Controls.Add(lblSearchHint);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1528, 110);
            topPanel.TabIndex = 11;
            // 
            // SchedulePanel
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(1554, 1270);
            Controls.Add(topPanel);
            Controls.Add(lblStatus);
            Controls.Add(panelReviews);
            Controls.Add(panelSyllabus);
            Controls.Add(panelDetail);
            Controls.Add(panelByClass);
            Controls.Add(panelByProf);
            Controls.Add(rbClass);
            Controls.Add(rbProf);
            Controls.Add(btnGo);
            Controls.Add(txtSearch);
            ForeColor = SystemColors.ControlLightLight;
            Margin = new Padding(4, 3, 4, 3);
            Name = "SchedulePanel";
            Text = "Everytime 강의 검색";
            panelByProf.ResumeLayout(false);
            panelByProf.PerformLayout();
            panelByClass.ResumeLayout(false);
            panelByClass.PerformLayout();
            panelDetail.ResumeLayout(false);
            panelDetail.PerformLayout();
            panelSyllabus.ResumeLayout(false);
            panelSyllabus.PerformLayout();
            panelReviews.ResumeLayout(false);
            panelReviews.PerformLayout();
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private Panel topPanel;
    }
}
