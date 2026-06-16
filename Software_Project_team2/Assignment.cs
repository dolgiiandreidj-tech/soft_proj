using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software_Project_team2.Services;

namespace Software_Project_team2
{
    public partial class Assignment : Form
    {
        private readonly KlasService _klasService;

        public Assignment(KlasService klasService)
        {
            InitializeComponent();
            _klasService = klasService;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _ = LoadNoticesAsync();
            _ = LoadTasksAsync();
            _ = LoadMaterialsAsync();
        }

        private async Task LoadNoticesAsync()
        {
            try
            {
                var notices = await _klasService.GetSubjNotiListAsync();

                listBoxNotice.Items.Clear();
                foreach (var n in notices)
                {
                    string date = n.RegistDt.ToLocalTime().ToString("yyyy-MM-dd");
                    listBoxNotice.Items.Add($"{date}  {n.TypeNm} > {n.SubjNm}");
                    listBoxNotice.Items.Add($"   {n.Title}");
                    listBoxNotice.Items.Add("");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Notices] load failed: {ex.Message}");
            }
        }

        private async Task LoadTasksAsync()
        {
            try
            {
                var tasks = await _klasService.GetAllTasksAsync();

                listBoxTask.Items.Clear();
                foreach (var t in tasks)
                {
                    string deadline = t.ExpireDate?.ToString("yyyy-MM-dd HH:mm") ?? "-";
                    string deadlineLine = t.ReExpireDate.HasValue
                        ? $"   마감: {deadline}  →  연장: {t.ReExpireDate.Value:yyyy-MM-dd HH:mm}"
                        : $"   마감: {deadline}";

                    listBoxTask.Items.Add($"[{t.SubjNm}]  {t.Title}");
                    listBoxTask.Items.Add(deadlineLine);
                    listBoxTask.Items.Add("");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Tasks] load failed: {ex.Message}");
            }
        }

        private async Task LoadMaterialsAsync()
        {
            try
            {
                var materials = await _klasService.GetAllMaterialsAsync();

                listBoxMaterial.Items.Clear();
                foreach (var m in materials)
                {
                    string date = m.RegistDt.ToLocalTime().ToString("yyyy-MM-dd");
                    string files = m.FileCnt > 0 ? $"  📎{m.FileCnt}" : "";
                    listBoxMaterial.Items.Add($"[{m.SubjNm}]  {m.Title}");
                    listBoxMaterial.Items.Add($"   {m.UserNm}  ·  {date}{files}");
                    listBoxMaterial.Items.Add("");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Materials] load failed: {ex.Message}");
            }
        }

        private void listBoxMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
