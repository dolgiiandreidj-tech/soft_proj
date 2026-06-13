namespace Software_Project_team2
{
    partial class LoginForm
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
            panelHeader = new Panel();
            labelTitle = new Label();
            labelStatus = new Label();
            panelBrowser = new Panel();
            panelHeader.SuspendLayout();
            SuspendLayout();

            // panelHeader
            panelHeader.BackColor = Color.FromArgb(24, 27, 38);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(labelStatus);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 56;

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(20, 14);
            labelTitle.Text = "에브리타임 로그인";

            // labelStatus
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 9F);
            labelStatus.ForeColor = Color.FromArgb(160, 165, 180);
            labelStatus.Location = new Point(220, 18);
            labelStatus.Text = "";

            // panelBrowser
            panelBrowser.Dock = DockStyle.Fill;

            // LoginForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 20, 28);
            ClientSize = new Size(960, 680);
            Controls.Add(panelBrowser);
            Controls.Add(panelHeader);
            Name = "LoginForm";
            Text = "에브리타임 로그인";
            StartPosition = FormStartPosition.CenterScreen;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelHeader;
        private Label labelTitle;
        private Label labelStatus;
        private Panel panelBrowser;
    }
}
