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
        private System.Windows.Forms.Label lblSyllabusBody;
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
            lblSyllabusBody = new Label();
            lblSyllabusHeader = new Label();
            lblStatus = new Label();
            panelReviews = new Panel();
            flowReviews = new FlowLayoutPanel();
            lblReviewsHeader = new Label();
            panelByProf.SuspendLayout();
            panelByClass.SuspendLayout();
            panelDetail.SuspendLayout();
            panelSyllabus.SuspendLayout();
            panelReviews.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.BackColor = Color.Transparent;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Black;
            lblHeader.Location = new Point(18, 21);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(218, 30);
            lblHeader.TabIndex = 10;
            lblHeader.Text = "Everytime 강의 검색";
            // 
            // lblSearchHint
            // 
            lblSearchHint.AutoSize = true;
            lblSearchHint.BackColor = Color.Transparent;
            lblSearchHint.Font = new Font("Segoe UI", 10F);
            lblSearchHint.ForeColor = Color.Black;
            lblSearchHint.Location = new Point(18, 53);
            lblSearchHint.Name = "lblSearchHint";
            lblSearchHint.Size = new Size(279, 19);
            lblSearchHint.TabIndex = 9;
            lblSearchHint.Text = "search for class from everytime (review, info)";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(224, 224, 224);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.ForeColor = Color.Black;
            txtSearch.Location = new Point(18, 83);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "type here";
            txtSearch.Size = new Size(946, 29);
            txtSearch.TabIndex = 0;
            // 
            // btnGo
            // 
            btnGo.BackColor = Color.FromArgb(90, 0, 31);
            btnGo.Cursor = Cursors.Hand;
            btnGo.FlatAppearance.BorderSize = 0;
            btnGo.FlatAppearance.MouseOverBackColor = Color.FromArgb(120, 140, 255);
            btnGo.FlatStyle = FlatStyle.Flat;
            btnGo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGo.ForeColor = Color.White;
            btnGo.Location = new Point(976, 83);
            btnGo.Margin = new Padding(3, 2, 3, 2);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(88, 29);
            btnGo.TabIndex = 1;
            btnGo.Text = "GO";
            btnGo.UseVisualStyleBackColor = false;
            // 
            // rbProf
            // 
            rbProf.AutoSize = true;
            rbProf.BackColor = Color.Transparent;
            rbProf.Font = new Font("Segoe UI", 11F);
            rbProf.ForeColor = Color.Black;
            rbProf.Location = new Point(18, 121);
            rbProf.Margin = new Padding(3, 2, 3, 2);
            rbProf.Name = "rbProf";
            rbProf.Size = new Size(99, 24);
            rbProf.TabIndex = 2;
            rbProf.Text = "교수 (prof)";
            rbProf.UseVisualStyleBackColor = false;
            // 
            // rbClass
            // 
            rbClass.AutoSize = true;
            rbClass.BackColor = Color.Transparent;
            rbClass.Checked = true;
            rbClass.Font = new Font("Segoe UI", 11F);
            rbClass.ForeColor = Color.Black;
            rbClass.Location = new Point(148, 121);
            rbClass.Margin = new Padding(3, 2, 3, 2);
            rbClass.Name = "rbClass";
            rbClass.Size = new Size(117, 24);
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
            panelByProf.Location = new Point(18, 150);
            panelByProf.Margin = new Padding(3, 2, 3, 2);
            panelByProf.Name = "panelByProf";
            panelByProf.Padding = new Padding(14, 12, 14, 12);
            panelByProf.Size = new Size(281, 384);
            panelByProf.TabIndex = 4;
            // 
            // lstByProf
            // 
            lstByProf.BackColor = Color.FromArgb(252, 252, 252);
            lstByProf.BorderStyle = BorderStyle.None;
            lstByProf.Font = new Font("Segoe UI", 10F);
            lstByProf.ForeColor = Color.White;
            lstByProf.FormattingEnabled = true;
            lstByProf.IntegralHeight = false;
            lstByProf.ItemHeight = 17;
            lstByProf.Location = new Point(14, 37);
            lstByProf.Margin = new Padding(3, 2, 3, 2);
            lstByProf.Name = "lstByProf";
            lstByProf.Size = new Size(252, 333);
            lstByProf.TabIndex = 0;
            // 
            // lblByProf
            // 
            lblByProf.AutoSize = true;
            lblByProf.BackColor = Color.Transparent;
            lblByProf.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblByProf.ForeColor = Color.Black;
            lblByProf.Location = new Point(14, 11);
            lblByProf.Name = "lblByProf";
            lblByProf.Size = new Size(88, 20);
            lblByProf.TabIndex = 1;
            lblByProf.Text = "교수명 결과";
            // 
            // panelByClass
            // 
            panelByClass.BackColor = Color.FromArgb(252, 252, 252);
            panelByClass.BorderStyle = BorderStyle.FixedSingle;
            panelByClass.Controls.Add(lstByClass);
            panelByClass.Controls.Add(lblByClass);
            panelByClass.Location = new Point(307, 150);
            panelByClass.Margin = new Padding(3, 2, 3, 2);
            panelByClass.Name = "panelByClass";
            panelByClass.Padding = new Padding(14, 12, 14, 12);
            panelByClass.Size = new Size(281, 384);
            panelByClass.TabIndex = 5;
            // 
            // lstByClass
            // 
            lstByClass.BackColor = Color.FromArgb(252, 252, 252);
            lstByClass.BorderStyle = BorderStyle.None;
            lstByClass.Font = new Font("Segoe UI", 10F);
            lstByClass.ForeColor = Color.White;
            lstByClass.FormattingEnabled = true;
            lstByClass.IntegralHeight = false;
            lstByClass.ItemHeight = 17;
            lstByClass.Location = new Point(14, 37);
            lstByClass.Margin = new Padding(3, 2, 3, 2);
            lstByClass.Name = "lstByClass";
            lstByClass.Size = new Size(252, 333);
            lstByClass.TabIndex = 0;
            // 
            // lblByClass
            // 
            lblByClass.AutoSize = true;
            lblByClass.BackColor = Color.Transparent;
            lblByClass.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblByClass.ForeColor = Color.Black;
            lblByClass.Location = new Point(14, 11);
            lblByClass.Name = "lblByClass";
            lblByClass.Size = new Size(88, 20);
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
            panelDetail.Location = new Point(595, 150);
            panelDetail.Margin = new Padding(3, 2, 3, 2);
            panelDetail.Name = "panelDetail";
            panelDetail.Padding = new Padding(14, 12, 14, 12);
            panelDetail.Size = new Size(473, 188);
            panelDetail.TabIndex = 6;
            // 
            // lblDetailStatus
            // 
            lblDetailStatus.AutoSize = true;
            lblDetailStatus.BackColor = Color.Transparent;
            lblDetailStatus.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblDetailStatus.ForeColor = Color.FromArgb(140, 145, 160);
            lblDetailStatus.Location = new Point(14, 161);
            lblDetailStatus.Name = "lblDetailStatus";
            lblDetailStatus.Size = new Size(0, 15);
            lblDetailStatus.TabIndex = 0;
            // 
            // lblDetailReviews
            // 
            lblDetailReviews.AutoSize = true;
            lblDetailReviews.BackColor = Color.Transparent;
            lblDetailReviews.Font = new Font("Segoe UI", 11F);
            lblDetailReviews.ForeColor = Color.FromArgb(160, 165, 180);
            lblDetailReviews.Location = new Point(105, 127);
            lblDetailReviews.Name = "lblDetailReviews";
            lblDetailReviews.Size = new Size(0, 20);
            lblDetailReviews.TabIndex = 1;
            // 
            // lblDetailRating
            // 
            lblDetailRating.AutoSize = true;
            lblDetailRating.BackColor = Color.Transparent;
            lblDetailRating.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDetailRating.ForeColor = Color.FromArgb(255, 200, 90);
            lblDetailRating.Location = new Point(14, 121);
            lblDetailRating.Name = "lblDetailRating";
            lblDetailRating.Size = new Size(0, 25);
            lblDetailRating.TabIndex = 2;
            // 
            // lblDetailCode
            // 
            lblDetailCode.AutoSize = true;
            lblDetailCode.BackColor = Color.Transparent;
            lblDetailCode.Font = new Font("Segoe UI", 11F);
            lblDetailCode.ForeColor = Color.FromArgb(160, 165, 180);
            lblDetailCode.Location = new Point(14, 96);
            lblDetailCode.Name = "lblDetailCode";
            lblDetailCode.Size = new Size(0, 20);
            lblDetailCode.TabIndex = 3;
            // 
            // lblDetailProfessor
            // 
            lblDetailProfessor.AutoSize = true;
            lblDetailProfessor.BackColor = Color.Transparent;
            lblDetailProfessor.Font = new Font("Segoe UI", 11F);
            lblDetailProfessor.ForeColor = Color.FromArgb(200, 205, 215);
            lblDetailProfessor.Location = new Point(14, 72);
            lblDetailProfessor.Name = "lblDetailProfessor";
            lblDetailProfessor.Size = new Size(0, 20);
            lblDetailProfessor.TabIndex = 4;
            // 
            // lblDetailName
            // 
            lblDetailName.AutoSize = true;
            lblDetailName.BackColor = Color.Transparent;
            lblDetailName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDetailName.ForeColor = Color.White;
            lblDetailName.Location = new Point(14, 39);
            lblDetailName.MaximumSize = new Size(444, 0);
            lblDetailName.Name = "lblDetailName";
            lblDetailName.Size = new Size(0, 25);
            lblDetailName.TabIndex = 5;
            // 
            // lblDetailHeader
            // 
            lblDetailHeader.AutoSize = true;
            lblDetailHeader.BackColor = Color.Transparent;
            lblDetailHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailHeader.ForeColor = Color.Black;
            lblDetailHeader.Location = new Point(14, 11);
            lblDetailHeader.Name = "lblDetailHeader";
            lblDetailHeader.Size = new Size(73, 20);
            lblDetailHeader.TabIndex = 6;
            lblDetailHeader.Text = "강의 상세";
            // 
            // panelSyllabus
            // 
            panelSyllabus.BackColor = Color.FromArgb(252, 252, 252);
            panelSyllabus.BorderStyle = BorderStyle.FixedSingle;
            panelSyllabus.Controls.Add(lblSyllabusBody);
            panelSyllabus.Controls.Add(lblSyllabusHeader);
            panelSyllabus.Location = new Point(595, 353);
            panelSyllabus.Margin = new Padding(3, 2, 3, 2);
            panelSyllabus.Name = "panelSyllabus";
            panelSyllabus.Padding = new Padding(14, 12, 14, 12);
            panelSyllabus.Size = new Size(473, 181);
            panelSyllabus.TabIndex = 7;
            // 
            // lblSyllabusBody
            // 
            lblSyllabusBody.BackColor = Color.Transparent;
            lblSyllabusBody.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblSyllabusBody.ForeColor = Color.FromArgb(140, 145, 160);
            lblSyllabusBody.Location = new Point(14, 37);
            lblSyllabusBody.Name = "lblSyllabusBody";
            lblSyllabusBody.Size = new Size(444, 127);
            lblSyllabusBody.TabIndex = 0;
            lblSyllabusBody.Text = "Coming soon — syllabus will be loaded here.";
            lblSyllabusBody.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSyllabusHeader
            // 
            lblSyllabusHeader.AutoSize = true;
            lblSyllabusHeader.BackColor = Color.Transparent;
            lblSyllabusHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSyllabusHeader.ForeColor = Color.Black;
            lblSyllabusHeader.Location = new Point(14, 11);
            lblSyllabusHeader.Name = "lblSyllabusHeader";
            lblSyllabusHeader.Size = new Size(149, 20);
            lblSyllabusHeader.TabIndex = 1;
            lblSyllabusHeader.Text = "강의계획서 (준비 중)";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.FromArgb(160, 165, 180);
            lblStatus.Location = new Point(18, 810);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 19);
            lblStatus.TabIndex = 0;
            // 
            // panelReviews
            // 
            panelReviews.BackColor = Color.FromArgb(252, 252, 252);
            panelReviews.BorderStyle = BorderStyle.FixedSingle;
            panelReviews.Controls.Add(flowReviews);
            panelReviews.Controls.Add(lblReviewsHeader);
            panelReviews.Location = new Point(18, 547);
            panelReviews.Margin = new Padding(3, 2, 3, 2);
            panelReviews.Name = "panelReviews";
            panelReviews.Padding = new Padding(14, 12, 14, 12);
            panelReviews.Size = new Size(1051, 256);
            panelReviews.TabIndex = 8;
            // 
            // flowReviews
            // 
            flowReviews.AutoScroll = true;
            flowReviews.BackColor = Color.FromArgb(252, 252, 252);
            flowReviews.BorderStyle = BorderStyle.FixedSingle;
            flowReviews.FlowDirection = FlowDirection.TopDown;
            flowReviews.Location = new Point(14, 35);
            flowReviews.Margin = new Padding(3, 2, 3, 2);
            flowReviews.Name = "flowReviews";
            flowReviews.Size = new Size(1023, 210);
            flowReviews.TabIndex = 0;
            flowReviews.WrapContents = false;
            // 
            // lblReviewsHeader
            // 
            lblReviewsHeader.AutoSize = true;
            lblReviewsHeader.BackColor = Color.Transparent;
            lblReviewsHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblReviewsHeader.ForeColor = Color.Black;
            lblReviewsHeader.Location = new Point(14, 11);
            lblReviewsHeader.Name = "lblReviewsHeader";
            lblReviewsHeader.Size = new Size(88, 20);
            lblReviewsHeader.TabIndex = 1;
            lblReviewsHeader.Text = "최근 강의평";
            // 
            // SchedulePanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(1088, 762);
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
            Controls.Add(lblSearchHint);
            Controls.Add(lblHeader);
            ForeColor = SystemColors.ControlLightLight;
            Margin = new Padding(3, 2, 3, 2);
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
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
