namespace Software_Project_team2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
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
            panelHeader.BackColor = Color.FromArgb(90, 0, 31);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(labelStatus);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 52;

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 12);
            labelTitle.Text = "KLAS 로그인";

            // labelStatus
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 9F);
            labelStatus.ForeColor = Color.FromArgb(255, 200, 180);
            labelStatus.Location = new Point(180, 17);
            labelStatus.Text = "광운대학교 KLAS 계정으로 로그인하세요";

            // panelBrowser
            panelBrowser.Dock = DockStyle.Fill;

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 750);
            Controls.Add(panelBrowser);
            Controls.Add(panelHeader);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KLAS 로그인 — 광운대학교";
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
