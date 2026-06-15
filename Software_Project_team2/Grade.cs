using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software_Project_team2.Services;

namespace Software_Project_team2
{
    public partial class Grade : Form
    {
        private readonly KlasService _klas;

        public Grade(KlasService klas)
        {
            InitializeComponent();
            _klas = klas;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _ = LoadAsync();
        }

        private async Task LoadAsync()
        {
            try
            {
                var infoTask    = _klas.GetHakjukInfoAsync();
                var totTask     = _klas.GetSungjukTotAsync();
                var programTask = _klas.GetProgramGubunAsync();

                await Task.WhenAll(infoTask, totTask, programTask);

                var info               = infoTask.Result;
                var tot                = totTask.Result;
                var (pgmName, certOpt) = programTask.Result;

                void Apply()
                {
                    // Student info row
                    labelDepInfo.Text    = "학부";
                    labelMajor.Text      = info.Hakgwa;
                    labelStNumInfo.Text  = info.Hakbun;
                    labelStNameInfo.Text = info.KName;
                    labelHagchong.Text   = info.HakjukStatu;
                    labelProfInfo.Text   = string.IsNullOrEmpty(info.Email)
                        ? info.JidoName
                        : $"{info.JidoName}\n{info.Email}";

                    // Program row
                    string prog = pgmName;
                    if (!string.IsNullOrEmpty(certOpt))
                        prog = string.IsNullOrEmpty(prog) ? certOpt : $"{prog} / {certOpt}";
                    labelEngineering.Text = prog;

                    // Credit table — 신청학점 (cols 0-3)
                    label1.Text = tot.MajorApplyHakjum.ToString();
                    label2.Text = tot.CultureApplyHakjum.ToString();
                    label3.Text = tot.EtcApplyHakjum.ToString();
                    label4.Text = tot.ApplyHakjum.ToString();
                    // 삭제학점 (cols 4-7)
                    label5.Text = tot.MajorDelHakjum.ToString();
                    label6.Text = tot.CultureDelHakjum.ToString();
                    label7.Text = tot.EtcDelHakjum.ToString();
                    label8.Text = tot.DelHakjum.ToString();
                    // 취득학점 (cols 8-11)
                    label9.Text  = tot.MajorChidukHakjum.ToString();
                    label10.Text = tot.CultureChidukHakjum.ToString();
                    label11.Text = tot.EtcChidukHakjum.ToString();
                    label12.Text = tot.ChidukHakjum.ToString();
                    // 평량평균 (cols 12-13)
                    label13.Text = tot.HwakinScoresum.ToString("F2", CultureInfo.InvariantCulture);
                    label14.Text = tot.JaechulScoresum.ToString("F2", CultureInfo.InvariantCulture);
                }

                if (InvokeRequired) Invoke(Apply);
                else Apply();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Grade] load failed: {ex.Message}");
            }
        }
    }
}
