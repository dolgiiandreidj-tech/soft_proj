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
            lblHeader = new System.Windows.Forms.Label();
            lblSearchHint = new System.Windows.Forms.Label();
            txtSearch = new System.Windows.Forms.TextBox();
            btnGo = new System.Windows.Forms.Button();
            rbProf = new System.Windows.Forms.RadioButton();
            rbClass = new System.Windows.Forms.RadioButton();
            panelByProf = new System.Windows.Forms.Panel();
            lblByProf = new System.Windows.Forms.Label();
            lstByProf = new System.Windows.Forms.ListBox();
            panelByClass = new System.Windows.Forms.Panel();
            lblByClass = new System.Windows.Forms.Label();
            lstByClass = new System.Windows.Forms.ListBox();
            panelDetail = new System.Windows.Forms.Panel();
            lblDetailHeader = new System.Windows.Forms.Label();
            lblDetailName = new System.Windows.Forms.Label();
            lblDetailProfessor = new System.Windows.Forms.Label();
            lblDetailCode = new System.Windows.Forms.Label();
            lblDetailRating = new System.Windows.Forms.Label();
            lblDetailReviews = new System.Windows.Forms.Label();
            lblDetailStatus = new System.Windows.Forms.Label();
            panelSyllabus = new System.Windows.Forms.Panel();
            lblSyllabusHeader = new System.Windows.Forms.Label();
            lblSyllabusBody = new System.Windows.Forms.Label();
            lblStatus = new System.Windows.Forms.Label();
            panelReviews = new System.Windows.Forms.Panel();
            lblReviewsHeader = new System.Windows.Forms.Label();
            flowReviews = new System.Windows.Forms.FlowLayoutPanel();
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
            lblHeader.BackColor = System.Drawing.Color.Transparent;
            lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblHeader.ForeColor = System.Drawing.Color.White;
            lblHeader.Location = new System.Drawing.Point(20, 28);
            lblHeader.Name = "lblHeader";
            lblHeader.Text = "Everytime 강의 검색";
            //
            // lblSearchHint
            //
            lblSearchHint.AutoSize = true;
            lblSearchHint.BackColor = System.Drawing.Color.Transparent;
            lblSearchHint.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSearchHint.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180);
            lblSearchHint.Location = new System.Drawing.Point(20, 78);
            lblSearchHint.Name = "lblSearchHint";
            lblSearchHint.Text = "search for class from everytime (review, info)";
            //
            // txtSearch
            //
            txtSearch.BackColor = System.Drawing.Color.FromArgb(38, 41, 52);
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            txtSearch.ForeColor = System.Drawing.Color.White;
            txtSearch.Location = new System.Drawing.Point(20, 110);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "type here";
            txtSearch.Size = new System.Drawing.Size(1080, 34);
            txtSearch.TabIndex = 0;
            //
            // btnGo
            //
            btnGo.BackColor = System.Drawing.Color.FromArgb(98, 120, 255);
            btnGo.Cursor = System.Windows.Forms.Cursors.Hand;
            btnGo.FlatAppearance.BorderSize = 0;
            btnGo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(120, 140, 255);
            btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnGo.ForeColor = System.Drawing.Color.White;
            btnGo.Location = new System.Drawing.Point(1115, 108);
            btnGo.Name = "btnGo";
            btnGo.Size = new System.Drawing.Size(100, 38);
            btnGo.TabIndex = 1;
            btnGo.Text = "GO";
            btnGo.UseVisualStyleBackColor = false;
            //
            // rbProf
            //
            rbProf.AutoSize = true;
            rbProf.BackColor = System.Drawing.Color.Transparent;
            rbProf.Font = new System.Drawing.Font("Segoe UI", 11F);
            rbProf.ForeColor = System.Drawing.Color.FromArgb(220, 222, 230);
            rbProf.Location = new System.Drawing.Point(20, 162);
            rbProf.Name = "rbProf";
            rbProf.Text = "교수 (prof)";
            rbProf.TabIndex = 2;
            rbProf.UseVisualStyleBackColor = false;
            //
            // rbClass
            //
            rbClass.AutoSize = true;
            rbClass.BackColor = System.Drawing.Color.Transparent;
            rbClass.Checked = true;
            rbClass.Font = new System.Drawing.Font("Segoe UI", 11F);
            rbClass.ForeColor = System.Drawing.Color.FromArgb(220, 222, 230);
            rbClass.Location = new System.Drawing.Point(170, 162);
            rbClass.Name = "rbClass";
            rbClass.Text = "강의명 (class)";
            rbClass.TabIndex = 3;
            rbClass.TabStop = true;
            rbClass.UseVisualStyleBackColor = false;
            //
            // panelByProf
            //
            panelByProf.BackColor = System.Drawing.Color.FromArgb(30, 32, 40);
            panelByProf.Controls.Add(lstByProf);
            panelByProf.Controls.Add(lblByProf);
            panelByProf.Location = new System.Drawing.Point(20, 200);
            panelByProf.Name = "panelByProf";
            panelByProf.Padding = new System.Windows.Forms.Padding(16);
            panelByProf.Size = new System.Drawing.Size(320, 510);
            panelByProf.TabIndex = 4;
            //
            // lblByProf
            //
            lblByProf.AutoSize = true;
            lblByProf.BackColor = System.Drawing.Color.Transparent;
            lblByProf.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblByProf.ForeColor = System.Drawing.Color.White;
            lblByProf.Location = new System.Drawing.Point(16, 14);
            lblByProf.Name = "lblByProf";
            lblByProf.Text = "교수명 결과";
            //
            // lstByProf
            //
            lstByProf.BackColor = System.Drawing.Color.FromArgb(38, 41, 52);
            lstByProf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lstByProf.Font = new System.Drawing.Font("Segoe UI", 10F);
            lstByProf.ForeColor = System.Drawing.Color.White;
            lstByProf.FormattingEnabled = true;
            lstByProf.IntegralHeight = false;
            lstByProf.ItemHeight = 22;
            lstByProf.Location = new System.Drawing.Point(16, 50);
            lstByProf.Name = "lstByProf";
            lstByProf.Size = new System.Drawing.Size(288, 444);
            lstByProf.TabIndex = 0;
            //
            // panelByClass
            //
            panelByClass.BackColor = System.Drawing.Color.FromArgb(30, 32, 40);
            panelByClass.Controls.Add(lstByClass);
            panelByClass.Controls.Add(lblByClass);
            panelByClass.Location = new System.Drawing.Point(350, 200);
            panelByClass.Name = "panelByClass";
            panelByClass.Padding = new System.Windows.Forms.Padding(16);
            panelByClass.Size = new System.Drawing.Size(320, 510);
            panelByClass.TabIndex = 5;
            //
            // lblByClass
            //
            lblByClass.AutoSize = true;
            lblByClass.BackColor = System.Drawing.Color.Transparent;
            lblByClass.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblByClass.ForeColor = System.Drawing.Color.White;
            lblByClass.Location = new System.Drawing.Point(16, 14);
            lblByClass.Name = "lblByClass";
            lblByClass.Text = "강의명 결과";
            //
            // lstByClass
            //
            lstByClass.BackColor = System.Drawing.Color.FromArgb(38, 41, 52);
            lstByClass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lstByClass.Font = new System.Drawing.Font("Segoe UI", 10F);
            lstByClass.ForeColor = System.Drawing.Color.White;
            lstByClass.FormattingEnabled = true;
            lstByClass.IntegralHeight = false;
            lstByClass.ItemHeight = 22;
            lstByClass.Location = new System.Drawing.Point(16, 50);
            lstByClass.Name = "lstByClass";
            lstByClass.Size = new System.Drawing.Size(288, 444);
            lstByClass.TabIndex = 0;
            //
            // panelDetail
            //
            panelDetail.BackColor = System.Drawing.Color.FromArgb(30, 32, 40);
            panelDetail.Controls.Add(lblDetailStatus);
            panelDetail.Controls.Add(lblDetailReviews);
            panelDetail.Controls.Add(lblDetailRating);
            panelDetail.Controls.Add(lblDetailCode);
            panelDetail.Controls.Add(lblDetailProfessor);
            panelDetail.Controls.Add(lblDetailName);
            panelDetail.Controls.Add(lblDetailHeader);
            panelDetail.Location = new System.Drawing.Point(680, 200);
            panelDetail.Name = "panelDetail";
            panelDetail.Padding = new System.Windows.Forms.Padding(16);
            panelDetail.Size = new System.Drawing.Size(540, 250);
            panelDetail.TabIndex = 6;
            //
            // lblDetailHeader
            //
            lblDetailHeader.AutoSize = true;
            lblDetailHeader.BackColor = System.Drawing.Color.Transparent;
            lblDetailHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblDetailHeader.ForeColor = System.Drawing.Color.White;
            lblDetailHeader.Location = new System.Drawing.Point(16, 14);
            lblDetailHeader.Name = "lblDetailHeader";
            lblDetailHeader.Text = "강의 상세";
            //
            // lblDetailName
            //
            lblDetailName.AutoSize = true;
            lblDetailName.BackColor = System.Drawing.Color.Transparent;
            lblDetailName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblDetailName.ForeColor = System.Drawing.Color.White;
            lblDetailName.Location = new System.Drawing.Point(16, 52);
            lblDetailName.MaximumSize = new System.Drawing.Size(508, 0);
            lblDetailName.Name = "lblDetailName";
            lblDetailName.Text = "";
            //
            // lblDetailProfessor
            //
            lblDetailProfessor.AutoSize = true;
            lblDetailProfessor.BackColor = System.Drawing.Color.Transparent;
            lblDetailProfessor.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblDetailProfessor.ForeColor = System.Drawing.Color.FromArgb(200, 205, 215);
            lblDetailProfessor.Location = new System.Drawing.Point(16, 96);
            lblDetailProfessor.Name = "lblDetailProfessor";
            lblDetailProfessor.Text = "";
            //
            // lblDetailCode
            //
            lblDetailCode.AutoSize = true;
            lblDetailCode.BackColor = System.Drawing.Color.Transparent;
            lblDetailCode.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblDetailCode.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180);
            lblDetailCode.Location = new System.Drawing.Point(16, 128);
            lblDetailCode.Name = "lblDetailCode";
            lblDetailCode.Text = "";
            //
            // lblDetailRating
            //
            lblDetailRating.AutoSize = true;
            lblDetailRating.BackColor = System.Drawing.Color.Transparent;
            lblDetailRating.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblDetailRating.ForeColor = System.Drawing.Color.FromArgb(255, 200, 90);
            lblDetailRating.Location = new System.Drawing.Point(16, 162);
            lblDetailRating.Name = "lblDetailRating";
            lblDetailRating.Text = "";
            //
            // lblDetailReviews
            //
            lblDetailReviews.AutoSize = true;
            lblDetailReviews.BackColor = System.Drawing.Color.Transparent;
            lblDetailReviews.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblDetailReviews.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180);
            lblDetailReviews.Location = new System.Drawing.Point(120, 170);
            lblDetailReviews.Name = "lblDetailReviews";
            lblDetailReviews.Text = "";
            //
            // lblDetailStatus
            //
            lblDetailStatus.AutoSize = true;
            lblDetailStatus.BackColor = System.Drawing.Color.Transparent;
            lblDetailStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblDetailStatus.ForeColor = System.Drawing.Color.FromArgb(140, 145, 160);
            lblDetailStatus.Location = new System.Drawing.Point(16, 215);
            lblDetailStatus.Name = "lblDetailStatus";
            lblDetailStatus.Text = "";
            //
            // panelSyllabus
            //
            panelSyllabus.BackColor = System.Drawing.Color.FromArgb(30, 32, 40);
            panelSyllabus.Controls.Add(lblSyllabusBody);
            panelSyllabus.Controls.Add(lblSyllabusHeader);
            panelSyllabus.Location = new System.Drawing.Point(680, 470);
            panelSyllabus.Name = "panelSyllabus";
            panelSyllabus.Padding = new System.Windows.Forms.Padding(16);
            panelSyllabus.Size = new System.Drawing.Size(540, 240);
            panelSyllabus.TabIndex = 7;
            //
            // lblSyllabusHeader
            //
            lblSyllabusHeader.AutoSize = true;
            lblSyllabusHeader.BackColor = System.Drawing.Color.Transparent;
            lblSyllabusHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblSyllabusHeader.ForeColor = System.Drawing.Color.White;
            lblSyllabusHeader.Location = new System.Drawing.Point(16, 14);
            lblSyllabusHeader.Name = "lblSyllabusHeader";
            lblSyllabusHeader.Text = "강의계획서 (준비 중)";
            //
            // lblSyllabusBody
            //
            lblSyllabusBody.AutoSize = false;
            lblSyllabusBody.BackColor = System.Drawing.Color.Transparent;
            lblSyllabusBody.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            lblSyllabusBody.ForeColor = System.Drawing.Color.FromArgb(140, 145, 160);
            lblSyllabusBody.Location = new System.Drawing.Point(16, 50);
            lblSyllabusBody.Name = "lblSyllabusBody";
            lblSyllabusBody.Size = new System.Drawing.Size(508, 170);
            lblSyllabusBody.Text = "Coming soon — syllabus will be loaded here.";
            lblSyllabusBody.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblStatus
            //
            lblStatus.AutoSize = true;
            lblStatus.BackColor = System.Drawing.Color.Transparent;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblStatus.ForeColor = System.Drawing.Color.FromArgb(160, 165, 180);
            lblStatus.Location = new System.Drawing.Point(20, 1080);
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "";
            //
            // panelReviews
            //
            panelReviews.BackColor = System.Drawing.Color.FromArgb(30, 32, 40);
            panelReviews.Controls.Add(flowReviews);
            panelReviews.Controls.Add(lblReviewsHeader);
            panelReviews.Location = new System.Drawing.Point(20, 730);
            panelReviews.Name = "panelReviews";
            panelReviews.Padding = new System.Windows.Forms.Padding(16);
            panelReviews.Size = new System.Drawing.Size(1200, 340);
            panelReviews.TabIndex = 8;
            //
            // lblReviewsHeader
            //
            lblReviewsHeader.AutoSize = true;
            lblReviewsHeader.BackColor = System.Drawing.Color.Transparent;
            lblReviewsHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblReviewsHeader.ForeColor = System.Drawing.Color.White;
            lblReviewsHeader.Location = new System.Drawing.Point(16, 14);
            lblReviewsHeader.Name = "lblReviewsHeader";
            lblReviewsHeader.Text = "최근 강의평";
            //
            // flowReviews
            //
            flowReviews.AutoScroll = true;
            flowReviews.BackColor = System.Drawing.Color.FromArgb(30, 32, 40);
            flowReviews.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowReviews.Location = new System.Drawing.Point(16, 46);
            flowReviews.Name = "flowReviews";
            flowReviews.Size = new System.Drawing.Size(1168, 278);
            flowReviews.TabIndex = 0;
            flowReviews.WrapContents = false;
            //
            // SchedulePanel
            //
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = System.Drawing.Color.FromArgb(20, 22, 28);
            ClientSize = new System.Drawing.Size(1243, 1120);
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
