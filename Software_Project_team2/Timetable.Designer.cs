namespace Software_Project_team2
{
    partial class Timetable
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            topPanel     = new Panel();
            lblLogo      = new Label();
            panelContent = new Panel();
            topPanel.SuspendLayout();
            SuspendLayout();

            // topPanel
            topPanel.BackColor = Color.FromArgb(90, 0, 31);
            topPanel.Controls.Add(lblLogo);
            topPanel.Dock     = DockStyle.Top;
            topPanel.Size     = new Size(1050, 32);
            topPanel.Name     = "topPanel";
            topPanel.TabIndex = 0;

            // lblLogo
            lblLogo.AutoSize  = true;
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Font      = new Font("Times New Roman", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location  = new Point(18, 5);
            lblLogo.Name      = "lblLogo";
            lblLogo.Text      = "KWANGWOON UNIVERSITY";
            lblLogo.TabIndex  = 0;

            // panelContent — scrollable fill area, all course cards live here
            panelContent.Dock       = DockStyle.Fill;
            panelContent.BackColor  = Color.White;
            panelContent.AutoScroll = true;
            panelContent.Name       = "panelContent";
            panelContent.TabIndex   = 1;

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.White;
            ClientSize          = new Size(1050, 640);
            Controls.Add(panelContent);
            Controls.Add(topPanel);
            Name          = "Timetable";
            StartPosition = FormStartPosition.CenterScreen;
            Text          = "수업시간표";

            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
        }

        private Panel topPanel;
        private Label lblLogo;
        private Panel panelContent;
    }
}
