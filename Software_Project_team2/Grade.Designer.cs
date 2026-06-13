namespace Software_Project_team2
{
    partial class Grade
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
            tableStudent = new TableLayoutPanel();
            lblTitleGrade = new Label();
            labeldivision = new Label();
            labelDepart = new Label();
            labelStudentNum = new Label();
            labelStudentName = new Label();
            labelHagnen = new Label();
            labelProf = new Label();
            labelDepInfo = new Label();
            labelMajor = new Label();
            labelStNumInfo = new Label();
            labelStNameInfo = new Label();
            labelHagchong = new Label();
            labelProfInfo = new Label();
            tableProgram = new TableLayoutPanel();
            labelProgram = new Label();
            labelEngineering = new Label();
            tableCredit = new TableLayoutPanel();
            labelSingchon = new Label();
            labelSagche = new Label();
            labelChvidik = new Label();
            labelPengrang = new Label();
            labelMajor1 = new Label();
            labelrefinement1 = new Label();
            labelMore1 = new Label();
            labelAnother1 = new Label();
            labelMAjor2 = new Label();
            labelrefinement2 = new Label();
            labelMore2 = new Label();
            labelAnother2 = new Label();
            labelMAjor3 = new Label();
            labelrefinement3 = new Label();
            labelMore3 = new Label();
            labelAnother3 = new Label();
            labelHacchokbu = new Label();
            labelScore = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            topPanel.SuspendLayout();
            tableStudent.SuspendLayout();
            tableProgram.SuspendLayout();
            tableCredit.SuspendLayout();
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
            topPanel.Size = new Size(1306, 32);
            topPanel.TabIndex = 1;
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
            // tableStudent
            // 
            tableStudent.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableStudent.ColumnCount = 6;
            tableStudent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableStudent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableStudent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableStudent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableStudent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            tableStudent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tableStudent.Controls.Add(labelProfInfo, 5, 1);
            tableStudent.Controls.Add(labelHagchong, 4, 1);
            tableStudent.Controls.Add(labelStNameInfo, 3, 1);
            tableStudent.Controls.Add(labelStNumInfo, 2, 1);
            tableStudent.Controls.Add(labelMajor, 1, 1);
            tableStudent.Controls.Add(labelDepInfo, 0, 1);
            tableStudent.Controls.Add(labelProf, 5, 0);
            tableStudent.Controls.Add(labelHagnen, 4, 0);
            tableStudent.Controls.Add(labelStudentName, 3, 0);
            tableStudent.Controls.Add(labelStudentNum, 2, 0);
            tableStudent.Controls.Add(labelDepart, 1, 0);
            tableStudent.Controls.Add(labeldivision, 0, 0);
            tableStudent.Location = new Point(18, 85);
            tableStudent.Name = "tableStudent";
            tableStudent.RowCount = 2;
            tableStudent.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableStudent.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableStudent.Size = new Size(980, 120);
            tableStudent.TabIndex = 2;
            // 
            // lblTitleGrade
            // 
            lblTitleGrade.AutoSize = true;
            lblTitleGrade.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleGrade.ForeColor = Color.FromArgb(34, 34, 34);
            lblTitleGrade.Location = new Point(18, 45);
            lblTitleGrade.Margin = new Padding(2, 0, 2, 0);
            lblTitleGrade.Name = "lblTitleGrade";
            lblTitleGrade.Size = new Size(198, 37);
            lblTitleGrade.TabIndex = 3;
            lblTitleGrade.Text = "수강/ 성적조회";
            // 
            // labeldivision
            // 
            labeldivision.AutoSize = true;
            labeldivision.BackColor = SystemColors.ButtonFace;
            labeldivision.Dock = DockStyle.Fill;
            labeldivision.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labeldivision.Location = new Point(4, 1);
            labeldivision.Name = "labeldivision";
            labeldivision.Size = new Size(91, 58);
            labeldivision.TabIndex = 0;
            labeldivision.Text = "구분";
            labeldivision.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelDepart
            // 
            labelDepart.AutoSize = true;
            labelDepart.BackColor = SystemColors.ButtonFace;
            labelDepart.Dock = DockStyle.Fill;
            labelDepart.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDepart.Location = new Point(102, 1);
            labelDepart.Name = "labelDepart";
            labelDepart.Size = new Size(237, 58);
            labelDepart.TabIndex = 1;
            labelDepart.Text = "학과/학부";
            labelDepart.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelStudentNum
            // 
            labelStudentNum.AutoSize = true;
            labelStudentNum.BackColor = SystemColors.ButtonFace;
            labelStudentNum.Dock = DockStyle.Fill;
            labelStudentNum.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStudentNum.Location = new Point(346, 1);
            labelStudentNum.Name = "labelStudentNum";
            labelStudentNum.Size = new Size(139, 58);
            labelStudentNum.TabIndex = 2;
            labelStudentNum.Text = "학번";
            labelStudentNum.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelStudentName
            // 
            labelStudentName.AutoSize = true;
            labelStudentName.BackColor = SystemColors.ButtonFace;
            labelStudentName.Dock = DockStyle.Fill;
            labelStudentName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStudentName.Location = new Point(492, 1);
            labelStudentName.Name = "labelStudentName";
            labelStudentName.Size = new Size(139, 58);
            labelStudentName.TabIndex = 3;
            labelStudentName.Text = "이름";
            labelStudentName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelHagnen
            // 
            labelHagnen.AutoSize = true;
            labelHagnen.BackColor = SystemColors.ButtonFace;
            labelHagnen.Dock = DockStyle.Fill;
            labelHagnen.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHagnen.Location = new Point(638, 1);
            labelHagnen.Name = "labelHagnen";
            labelHagnen.Size = new Size(159, 58);
            labelHagnen.TabIndex = 4;
            labelHagnen.Text = "학적상황";
            labelHagnen.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelProf
            // 
            labelProf.AutoSize = true;
            labelProf.BackColor = SystemColors.ButtonFace;
            labelProf.Dock = DockStyle.Fill;
            labelProf.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelProf.Location = new Point(804, 1);
            labelProf.Name = "labelProf";
            labelProf.Size = new Size(172, 58);
            labelProf.TabIndex = 5;
            labelProf.Text = "지도교수";
            labelProf.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelDepInfo
            // 
            labelDepInfo.AutoSize = true;
            labelDepInfo.BackColor = SystemColors.ButtonFace;
            labelDepInfo.Dock = DockStyle.Fill;
            labelDepInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDepInfo.Location = new Point(4, 60);
            labelDepInfo.Name = "labelDepInfo";
            labelDepInfo.Size = new Size(91, 59);
            labelDepInfo.TabIndex = 6;
            labelDepInfo.Text = "학부";
            labelDepInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelMajor
            // 
            labelMajor.AutoSize = true;
            labelMajor.BackColor = SystemColors.ButtonFace;
            labelMajor.Dock = DockStyle.Fill;
            labelMajor.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMajor.Location = new Point(102, 60);
            labelMajor.Name = "labelMajor";
            labelMajor.Size = new Size(237, 59);
            labelMajor.TabIndex = 7;
            labelMajor.Text = "소프트웨어학부 인공지능전공\n";
            labelMajor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelStNumInfo
            // 
            labelStNumInfo.AutoSize = true;
            labelStNumInfo.BackColor = SystemColors.ButtonFace;
            labelStNumInfo.Dock = DockStyle.Fill;
            labelStNumInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStNumInfo.Location = new Point(346, 60);
            labelStNumInfo.Name = "labelStNumInfo";
            labelStNumInfo.Size = new Size(139, 59);
            labelStNumInfo.TabIndex = 8;
            labelStNumInfo.Text = "2024804501";
            labelStNumInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelStNameInfo
            // 
            labelStNameInfo.AutoSize = true;
            labelStNameInfo.BackColor = SystemColors.ButtonFace;
            labelStNameInfo.Dock = DockStyle.Fill;
            labelStNameInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStNameInfo.Location = new Point(492, 60);
            labelStNameInfo.Name = "labelStNameInfo";
            labelStNameInfo.Size = new Size(139, 59);
            labelStNameInfo.TabIndex = 9;
            labelStNameInfo.Text = "한안드레이";
            labelStNameInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelHagchong
            // 
            labelHagchong.AutoSize = true;
            labelHagchong.BackColor = SystemColors.ButtonFace;
            labelHagchong.Dock = DockStyle.Fill;
            labelHagchong.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHagchong.Location = new Point(638, 60);
            labelHagchong.Name = "labelHagchong";
            labelHagchong.Size = new Size(159, 59);
            labelHagchong.TabIndex = 10;
            labelHagchong.Text = "3학년 재학";
            labelHagchong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelProfInfo
            // 
            labelProfInfo.AutoSize = true;
            labelProfInfo.BackColor = SystemColors.ButtonFace;
            labelProfInfo.Dock = DockStyle.Fill;
            labelProfInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelProfInfo.Location = new Point(804, 60);
            labelProfInfo.Name = "labelProfInfo";
            labelProfInfo.Size = new Size(172, 59);
            labelProfInfo.TabIndex = 11;
            labelProfInfo.Text = "최용철\nwchoi@kw.ac.kr";
            labelProfInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableProgram
            // 
            tableProgram.AutoSize = true;
            tableProgram.BackgroundImageLayout = ImageLayout.None;
            tableProgram.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableProgram.ColumnCount = 2;
            tableProgram.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableProgram.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableProgram.Controls.Add(labelEngineering, 1, 0);
            tableProgram.Controls.Add(labelProgram, 0, 0);
            tableProgram.Location = new Point(18, 223);
            tableProgram.Name = "tableProgram";
            tableProgram.RowCount = 1;
            tableProgram.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableProgram.Size = new Size(286, 32);
            tableProgram.TabIndex = 4;
            // 
            // labelProgram
            // 
            labelProgram.AutoSize = true;
            labelProgram.Dock = DockStyle.Fill;
            labelProgram.Location = new Point(4, 1);
            labelProgram.Name = "labelProgram";
            labelProgram.Size = new Size(135, 30);
            labelProgram.TabIndex = 0;
            labelProgram.Text = "프로그램(학위과정)";
            labelProgram.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelEngineering
            // 
            labelEngineering.AutoSize = true;
            labelEngineering.Dock = DockStyle.Fill;
            labelEngineering.Location = new Point(146, 1);
            labelEngineering.Name = "labelEngineering";
            labelEngineering.Size = new Size(136, 30);
            labelEngineering.TabIndex = 1;
            labelEngineering.Text = "공학";
            labelEngineering.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableCredit
            // 
            tableCredit.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableCredit.ColumnCount = 14;
            tableCredit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.952381F));
            tableCredit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.952381F));
            tableCredit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.952381F));
            tableCredit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.952381F));
            tableCredit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.952381F));
            tableCredit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.952381F));
            tableCredit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.952381F));
            tableCredit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.952381F));
            tableCredit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.952381F));
            tableCredit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.952381F));
            tableCredit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.952381F));
            tableCredit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.952381F));
            tableCredit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableCredit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableCredit.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableCredit.Controls.Add(label14, 13, 2);
            tableCredit.Controls.Add(label13, 12, 2);
            tableCredit.Controls.Add(label12, 11, 2);
            tableCredit.Controls.Add(label11, 10, 2);
            tableCredit.Controls.Add(label10, 9, 2);
            tableCredit.Controls.Add(label9, 8, 2);
            tableCredit.Controls.Add(label8, 7, 2);
            tableCredit.Controls.Add(label7, 6, 2);
            tableCredit.Controls.Add(label6, 5, 2);
            tableCredit.Controls.Add(label5, 4, 2);
            tableCredit.Controls.Add(label4, 3, 2);
            tableCredit.Controls.Add(label3, 2, 2);
            tableCredit.Controls.Add(label2, 1, 2);
            tableCredit.Controls.Add(label1, 0, 2);
            tableCredit.Controls.Add(labelScore, 13, 1);
            tableCredit.Controls.Add(labelHacchokbu, 12, 1);
            tableCredit.Controls.Add(labelAnother3, 11, 1);
            tableCredit.Controls.Add(labelMore3, 10, 1);
            tableCredit.Controls.Add(labelrefinement3, 9, 1);
            tableCredit.Controls.Add(labelMAjor3, 8, 1);
            tableCredit.Controls.Add(labelAnother2, 7, 1);
            tableCredit.Controls.Add(labelMore2, 6, 1);
            tableCredit.Controls.Add(labelrefinement2, 5, 1);
            tableCredit.Controls.Add(labelMAjor2, 4, 1);
            tableCredit.Controls.Add(labelAnother1, 3, 1);
            tableCredit.Controls.Add(labelMore1, 2, 1);
            tableCredit.Controls.Add(labelrefinement1, 1, 1);
            tableCredit.Controls.Add(labelPengrang, 3, 0);
            tableCredit.Controls.Add(labelChvidik, 2, 0);
            tableCredit.Controls.Add(labelSagche, 1, 0);
            tableCredit.Controls.Add(labelSingchon, 0, 0);
            tableCredit.Controls.Add(labelMajor1, 0, 1);
            tableCredit.Location = new Point(18, 271);
            tableCredit.Name = "tableCredit";
            tableCredit.RowCount = 3;
            tableCredit.RowStyles.Add(new RowStyle(SizeType.Percent, 33.1210175F));
            tableCredit.RowStyles.Add(new RowStyle(SizeType.Percent, 66.87898F));
            tableCredit.RowStyles.Add(new RowStyle(SizeType.Absolute, 78F));
            tableCredit.Size = new Size(980, 180);
            tableCredit.TabIndex = 5;
            // 
            // labelSingchon
            // 
            labelSingchon.AutoSize = true;
            labelSingchon.BackColor = SystemColors.ButtonFace;
            tableCredit.SetColumnSpan(labelSingchon, 4);
            labelSingchon.Dock = DockStyle.Fill;
            labelSingchon.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSingchon.Location = new Point(4, 1);
            labelSingchon.Name = "labelSingchon";
            labelSingchon.Size = new Size(225, 32);
            labelSingchon.TabIndex = 0;
            labelSingchon.Text = "1)신청학점";
            labelSingchon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelSagche
            // 
            labelSagche.AutoSize = true;
            labelSagche.BackColor = SystemColors.ButtonFace;
            tableCredit.SetColumnSpan(labelSagche, 4);
            labelSagche.Dock = DockStyle.Fill;
            labelSagche.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSagche.Location = new Point(236, 1);
            labelSagche.Name = "labelSagche";
            labelSagche.Size = new Size(225, 32);
            labelSagche.TabIndex = 1;
            labelSagche.Text = "2)삭제학점";
            labelSagche.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelChvidik
            // 
            labelChvidik.AutoSize = true;
            labelChvidik.BackColor = SystemColors.ButtonFace;
            tableCredit.SetColumnSpan(labelChvidik, 4);
            labelChvidik.Dock = DockStyle.Fill;
            labelChvidik.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelChvidik.Location = new Point(468, 1);
            labelChvidik.Name = "labelChvidik";
            labelChvidik.Size = new Size(225, 32);
            labelChvidik.TabIndex = 2;
            labelChvidik.Text = "3)취득학점";
            labelChvidik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelPengrang
            // 
            labelPengrang.AutoSize = true;
            labelPengrang.BackColor = SystemColors.ButtonFace;
            tableCredit.SetColumnSpan(labelPengrang, 2);
            labelPengrang.Dock = DockStyle.Fill;
            labelPengrang.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPengrang.Location = new Point(700, 1);
            labelPengrang.Name = "labelPengrang";
            labelPengrang.Size = new Size(276, 32);
            labelPengrang.TabIndex = 3;
            labelPengrang.Text = "평량평균";
            labelPengrang.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelMajor1
            // 
            labelMajor1.AutoSize = true;
            labelMajor1.Dock = DockStyle.Fill;
            labelMajor1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMajor1.Location = new Point(4, 34);
            labelMajor1.Name = "labelMajor1";
            labelMajor1.Size = new Size(51, 65);
            labelMajor1.TabIndex = 4;
            labelMajor1.Text = "전공";
            labelMajor1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelrefinement1
            // 
            labelrefinement1.AutoSize = true;
            labelrefinement1.Dock = DockStyle.Fill;
            labelrefinement1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelrefinement1.Location = new Point(62, 34);
            labelrefinement1.Name = "labelrefinement1";
            labelrefinement1.Size = new Size(51, 65);
            labelrefinement1.TabIndex = 5;
            labelrefinement1.Text = "교양";
            labelrefinement1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelMore1
            // 
            labelMore1.AutoSize = true;
            labelMore1.Dock = DockStyle.Fill;
            labelMore1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMore1.Location = new Point(120, 34);
            labelMore1.Name = "labelMore1";
            labelMore1.Size = new Size(51, 65);
            labelMore1.TabIndex = 6;
            labelMore1.Text = "기타";
            labelMore1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelAnother1
            // 
            labelAnother1.AutoSize = true;
            labelAnother1.Dock = DockStyle.Fill;
            labelAnother1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAnother1.Location = new Point(178, 34);
            labelAnother1.Name = "labelAnother1";
            labelAnother1.Size = new Size(51, 65);
            labelAnother1.TabIndex = 7;
            labelAnother1.Text = "계";
            labelAnother1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelMAjor2
            // 
            labelMAjor2.AutoSize = true;
            labelMAjor2.Dock = DockStyle.Fill;
            labelMAjor2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMAjor2.Location = new Point(236, 34);
            labelMAjor2.Name = "labelMAjor2";
            labelMAjor2.Size = new Size(51, 65);
            labelMAjor2.TabIndex = 8;
            labelMAjor2.Text = "전공";
            labelMAjor2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelrefinement2
            // 
            labelrefinement2.AutoSize = true;
            labelrefinement2.Dock = DockStyle.Fill;
            labelrefinement2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelrefinement2.Location = new Point(294, 34);
            labelrefinement2.Name = "labelrefinement2";
            labelrefinement2.Size = new Size(51, 65);
            labelrefinement2.TabIndex = 9;
            labelrefinement2.Text = "교양";
            labelrefinement2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelMore2
            // 
            labelMore2.AutoSize = true;
            labelMore2.Dock = DockStyle.Fill;
            labelMore2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMore2.Location = new Point(352, 34);
            labelMore2.Name = "labelMore2";
            labelMore2.Size = new Size(51, 65);
            labelMore2.TabIndex = 10;
            labelMore2.Text = "기타";
            labelMore2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelAnother2
            // 
            labelAnother2.AutoSize = true;
            labelAnother2.Dock = DockStyle.Fill;
            labelAnother2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAnother2.Location = new Point(410, 34);
            labelAnother2.Name = "labelAnother2";
            labelAnother2.Size = new Size(51, 65);
            labelAnother2.TabIndex = 11;
            labelAnother2.Text = "계";
            labelAnother2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelMAjor3
            // 
            labelMAjor3.AutoSize = true;
            labelMAjor3.Dock = DockStyle.Fill;
            labelMAjor3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMAjor3.Location = new Point(468, 34);
            labelMAjor3.Name = "labelMAjor3";
            labelMAjor3.Size = new Size(51, 65);
            labelMAjor3.TabIndex = 12;
            labelMAjor3.Text = "전공";
            labelMAjor3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelrefinement3
            // 
            labelrefinement3.AutoSize = true;
            labelrefinement3.Dock = DockStyle.Fill;
            labelrefinement3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelrefinement3.Location = new Point(526, 34);
            labelrefinement3.Name = "labelrefinement3";
            labelrefinement3.Size = new Size(51, 65);
            labelrefinement3.TabIndex = 13;
            labelrefinement3.Text = "교양";
            labelrefinement3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelMore3
            // 
            labelMore3.AutoSize = true;
            labelMore3.Dock = DockStyle.Fill;
            labelMore3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMore3.Location = new Point(584, 34);
            labelMore3.Name = "labelMore3";
            labelMore3.Size = new Size(51, 65);
            labelMore3.TabIndex = 14;
            labelMore3.Text = "기타";
            labelMore3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelAnother3
            // 
            labelAnother3.AutoSize = true;
            labelAnother3.Dock = DockStyle.Fill;
            labelAnother3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAnother3.Location = new Point(642, 34);
            labelAnother3.Name = "labelAnother3";
            labelAnother3.Size = new Size(51, 65);
            labelAnother3.TabIndex = 15;
            labelAnother3.Text = "계";
            labelAnother3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelHacchokbu
            // 
            labelHacchokbu.AutoSize = true;
            labelHacchokbu.Dock = DockStyle.Fill;
            labelHacchokbu.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHacchokbu.Location = new Point(700, 34);
            labelHacchokbu.Name = "labelHacchokbu";
            labelHacchokbu.Size = new Size(131, 65);
            labelHacchokbu.TabIndex = 16;
            labelHacchokbu.Text = "4)학적부 기준";
            labelHacchokbu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Dock = DockStyle.Fill;
            labelScore.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelScore.Location = new Point(838, 34);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(138, 65);
            labelScore.TabIndex = 17;
            labelScore.Text = "5)성적증명서 기준";
            labelScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(4, 100);
            label1.Name = "label1";
            label1.Size = new Size(51, 79);
            label1.TabIndex = 18;
            label1.Text = "20";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(62, 100);
            label2.Name = "label2";
            label2.Size = new Size(51, 79);
            label2.TabIndex = 19;
            label2.Text = "52";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(120, 100);
            label3.Name = "label3";
            label3.Size = new Size(51, 79);
            label3.TabIndex = 20;
            label3.Text = "6";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(178, 100);
            label4.Name = "label4";
            label4.Size = new Size(51, 79);
            label4.TabIndex = 21;
            label4.Text = "78";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(236, 100);
            label5.Name = "label5";
            label5.Size = new Size(51, 79);
            label5.TabIndex = 22;
            label5.Text = "0";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(294, 100);
            label6.Name = "label6";
            label6.Size = new Size(51, 79);
            label6.TabIndex = 23;
            label6.Text = "0";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(352, 100);
            label7.Name = "label7";
            label7.Size = new Size(51, 79);
            label7.TabIndex = 24;
            label7.Text = "0";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(410, 100);
            label8.Name = "label8";
            label8.Size = new Size(51, 79);
            label8.TabIndex = 25;
            label8.Text = "0";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(468, 100);
            label9.Name = "label9";
            label9.Size = new Size(51, 79);
            label9.TabIndex = 26;
            label9.Text = "20";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(526, 100);
            label10.Name = "label10";
            label10.Size = new Size(51, 79);
            label10.TabIndex = 27;
            label10.Text = "52";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Fill;
            label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(584, 100);
            label11.Name = "label11";
            label11.Size = new Size(51, 79);
            label11.TabIndex = 28;
            label11.Text = "6";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Dock = DockStyle.Fill;
            label12.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(642, 100);
            label12.Name = "label12";
            label12.Size = new Size(51, 79);
            label12.TabIndex = 29;
            label12.Text = "78";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Dock = DockStyle.Fill;
            label13.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(700, 100);
            label13.Name = "label13";
            label13.Size = new Size(131, 79);
            label13.TabIndex = 30;
            label13.Text = "3.15";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Dock = DockStyle.Fill;
            label14.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(838, 100);
            label14.Name = "label14";
            label14.Size = new Size(138, 79);
            label14.TabIndex = 31;
            label14.Text = "3.15";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Grade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1306, 575);
            Controls.Add(tableCredit);
            Controls.Add(tableProgram);
            Controls.Add(lblTitleGrade);
            Controls.Add(tableStudent);
            Controls.Add(topPanel);
            Name = "Grade";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Grade";
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            tableStudent.ResumeLayout(false);
            tableStudent.PerformLayout();
            tableProgram.ResumeLayout(false);
            tableProgram.PerformLayout();
            tableCredit.ResumeLayout(false);
            tableCredit.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel topPanel;
        private Label lblLogo;
        private TableLayoutPanel tableStudent;
        private Label lblTitleGrade;
        private Label labelProfInfo;
        private Label labelHagchong;
        private Label labelStNameInfo;
        private Label labelStNumInfo;
        private Label labelMajor;
        private Label labelDepInfo;
        private Label labelProf;
        private Label labelHagnen;
        private Label labelStudentName;
        private Label labelStudentNum;
        private Label labelDepart;
        private Label labeldivision;
        private TableLayoutPanel tableProgram;
        private Label labelProgram;
        private Label labelEngineering;
        private TableLayoutPanel tableCredit;
        private Label labelSingchon;
        private Label labelPengrang;
        private Label labelChvidik;
        private Label labelSagche;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label labelScore;
        private Label labelHacchokbu;
        private Label labelAnother3;
        private Label labelMore3;
        private Label labelrefinement3;
        private Label labelMAjor3;
        private Label labelAnother2;
        private Label labelMore2;
        private Label labelrefinement2;
        private Label labelMAjor2;
        private Label labelAnother1;
        private Label labelMore1;
        private Label labelrefinement1;
        private Label labelMajor1;
    }
}