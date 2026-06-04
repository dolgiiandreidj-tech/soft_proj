namespace Software_Project_team2
{
    partial class NoticeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoticeForm));
            kw_label = new Label();
            pnlHeader = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            richNotice = new RichTextBox();
            btn_all = new Button();
            btn_study = new Button();
            btn_scholarship = new Button();
            btn_employment = new Button();
            btn_inernat = new Button();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // kw_label
            // 
            kw_label.AutoSize = true;
            kw_label.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            kw_label.ForeColor = Color.White;
            kw_label.Location = new Point(30, 25);
            kw_label.Name = "kw_label";
            kw_label.Size = new Size(473, 65);
            kw_label.TabIndex = 0;
            kw_label.Text = "광운대학교 공지사항";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(90, 0, 31);
            pnlHeader.Controls.Add(kw_label);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1378, 100);
            pnlHeader.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.WhiteSmoke;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(30, 120);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 37);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(90, 0, 31);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(290, 120);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(45, 35);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "🔍";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // richNotice
            // 
            richNotice.BackColor = Color.WhiteSmoke;
            richNotice.BorderStyle = BorderStyle.None;
            richNotice.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richNotice.ForeColor = Color.Black;
            richNotice.Location = new Point(12, 214);
            richNotice.Name = "richNotice";
            richNotice.ReadOnly = true;
            richNotice.Size = new Size(1354, 518);
            richNotice.TabIndex = 4;
            richNotice.Text = resources.GetString("richNotice.Text");
            // 
            // btn_all
            // 
            btn_all.BackColor = Color.FromArgb(90, 0, 31);
            btn_all.FlatStyle = FlatStyle.Flat;
            btn_all.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_all.ForeColor = Color.White;
            btn_all.Location = new Point(22, 173);
            btn_all.Name = "btn_all";
            btn_all.Size = new Size(100, 35);
            btn_all.TabIndex = 5;
            btn_all.Text = "전체";
            btn_all.UseVisualStyleBackColor = false;
            // 
            // btn_study
            // 
            btn_study.BackColor = Color.FromArgb(90, 0, 31);
            btn_study.FlatStyle = FlatStyle.Flat;
            btn_study.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_study.ForeColor = Color.White;
            btn_study.Location = new Point(128, 173);
            btn_study.Name = "btn_study";
            btn_study.Size = new Size(100, 35);
            btn_study.TabIndex = 6;
            btn_study.Text = "학사";
            btn_study.UseVisualStyleBackColor = false;
            btn_study.Click += button2_Click;
            // 
            // btn_scholarship
            // 
            btn_scholarship.BackColor = Color.FromArgb(90, 0, 31);
            btn_scholarship.FlatStyle = FlatStyle.Flat;
            btn_scholarship.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_scholarship.ForeColor = Color.White;
            btn_scholarship.Location = new Point(235, 173);
            btn_scholarship.Name = "btn_scholarship";
            btn_scholarship.Size = new Size(100, 35);
            btn_scholarship.TabIndex = 7;
            btn_scholarship.Text = " 장학";
            btn_scholarship.UseVisualStyleBackColor = false;
            // 
            // btn_employment
            // 
            btn_employment.BackColor = Color.FromArgb(90, 0, 31);
            btn_employment.FlatStyle = FlatStyle.Flat;
            btn_employment.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_employment.ForeColor = Color.White;
            btn_employment.Location = new Point(341, 173);
            btn_employment.Name = "btn_employment";
            btn_employment.Size = new Size(100, 35);
            btn_employment.TabIndex = 8;
            btn_employment.Text = "취업";
            btn_employment.UseVisualStyleBackColor = false;
            // 
            // btn_inernat
            // 
            btn_inernat.BackColor = Color.FromArgb(90, 0, 31);
            btn_inernat.FlatStyle = FlatStyle.Flat;
            btn_inernat.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_inernat.ForeColor = Color.White;
            btn_inernat.Location = new Point(447, 173);
            btn_inernat.Name = "btn_inernat";
            btn_inernat.Size = new Size(100, 35);
            btn_inernat.TabIndex = 9;
            btn_inernat.Text = "국제";
            btn_inernat.UseVisualStyleBackColor = false;
            // 
            // NoticeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1378, 744);
            Controls.Add(btn_inernat);
            Controls.Add(btn_employment);
            Controls.Add(btn_scholarship);
            Controls.Add(btn_study);
            Controls.Add(btn_all);
            Controls.Add(richNotice);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(pnlHeader);
            Name = "NoticeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NoticeForm";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label kw_label;
        private Panel pnlHeader;
        private TextBox txtSearch;
        private Button btnSearch;
        private RichTextBox richNotice;
        private Button btn_all;
        private Button btn_study;
        private Button btn_scholarship;
        private Button btn_employment;
        private Button btn_inernat;
    }
}