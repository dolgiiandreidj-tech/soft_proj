namespace Software_Project_team2
{
    partial class RecommendedCoursesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            topPanel = new Panel();
            lblLogo = new Label();
            panelHeader = new Panel();
            lblHeader = new Label();
            lblUnderHeader = new Label();
            flowCourses = new FlowLayoutPanel();
            topPanel.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            //
            // topPanel
            //
            topPanel.BackColor = Color.FromArgb(90, 0, 31);
            topPanel.Controls.Add(lblLogo);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1554, 57);
            topPanel.TabIndex = 0;
            //
            // lblLogo
            //
            lblLogo.AutoSize = true;
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Font = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(26, 10);
            lblLogo.Name = "lblLogo";
            lblLogo.TabIndex = 0;
            lblLogo.Text = "KWANGWOON UNIVERSITY";
            //
            // panelHeader
            //
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblHeader);
            panelHeader.Controls.Add(lblUnderHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 57);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1554, 96);
            panelHeader.TabIndex = 1;
            //
            // lblHeader
            //
            lblHeader.AutoSize = true;
            lblHeader.BackColor = Color.Transparent;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = Color.Black;
            lblHeader.Location = new Point(26, 12);
            lblHeader.Name = "lblHeader";
            lblHeader.TabIndex = 0;
            lblHeader.Text = "추천 강의";
            //
            // lblUnderHeader
            //
            lblUnderHeader.AutoSize = true;
            lblUnderHeader.BackColor = Color.Transparent;
            lblUnderHeader.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnderHeader.ForeColor = Color.FromArgb(100, 100, 100);
            lblUnderHeader.Location = new Point(26, 60);
            lblUnderHeader.Name = "lblUnderHeader";
            lblUnderHeader.TabIndex = 1;
            lblUnderHeader.Text = "전공 커리큘럼 기반 미이수 강의 중 에브리타임 평점 순위입니다.";
            //
            // flowCourses
            //
            flowCourses.AutoScroll = true;
            flowCourses.BackColor = Color.White;
            flowCourses.Dock = DockStyle.Fill;
            flowCourses.FlowDirection = FlowDirection.TopDown;
            flowCourses.Name = "flowCourses";
            flowCourses.Padding = new Padding(50, 15, 50, 20);
            flowCourses.TabIndex = 2;
            flowCourses.WrapContents = false;
            //
            // RecommendedCoursesForm
            //
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1554, 1270);
            Controls.Add(flowCourses);
            Controls.Add(panelHeader);
            Controls.Add(topPanel);
            Name = "RecommendedCoursesForm";
            Text = "추천 강의";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        private Panel topPanel;
        private Label lblLogo;
        private Panel panelHeader;
        private Label lblHeader;
        private Label lblUnderHeader;
        private FlowLayoutPanel flowCourses;
    }
}
