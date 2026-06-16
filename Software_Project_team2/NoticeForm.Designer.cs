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
            flpCategories = new FlowLayoutPanel();
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
            pnlHeader.Size = new Size(1866, 100);
            pnlHeader.TabIndex = 2;
            //
            // txtSearch
            //
            txtSearch.BackColor = Color.WhiteSmoke;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.ForeColor = Color.Black;
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
            richNotice.BackColor = Color.White;
            richNotice.BorderStyle = BorderStyle.None;
            richNotice.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richNotice.ForeColor = Color.Black;
            richNotice.Location = new Point(12, 214);
            richNotice.Name = "richNotice";
            richNotice.ReadOnly = true;
            richNotice.Size = new Size(1888, 1015);
            richNotice.TabIndex = 4;
            richNotice.Text = resources.GetString("richNotice.Text");
            //
            // flpCategories
            //
            flpCategories.FlowDirection = FlowDirection.LeftToRight;
            flpCategories.WrapContents = false;
            flpCategories.Location = new Point(22, 168);
            flpCategories.Size = new Size(1840, 42);
            flpCategories.Name = "flpCategories";
            flpCategories.TabIndex = 10;
            //
            // NoticeForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1866, 959);
            Controls.Add(flpCategories);
            Controls.Add(richNotice);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(pnlHeader);
            Name = "NoticeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "공지사항";
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
        private FlowLayoutPanel flpCategories;
    }
}
