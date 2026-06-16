using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software_Project_team2.Services;

namespace Software_Project_team2
{
    public partial class NoticeForm : Form
    {
        private static readonly (string Name, string Id)[] Categories =
        {
            ("전체",    ""),
            ("일반",    "0"),
            ("학사",    "1"),
            ("학생",    "2"),
            ("봉사",    "3"),
            ("등록/장학","4"),
            ("입학",    "5"),
            ("시설",    "6"),
            ("병무",    "7"),
            ("외부",    "8"),
            ("국제교류","9"),
            ("국제학생","10"),
        };

        private readonly NoticeService _noticeService = new();
        private ListView listViewNotices;
        private Button _activeCategoryBtn;
        private string _currentCategoryId = "";

        public NoticeForm()
        {
            InitializeComponent();

            richNotice.Visible = false;

            SetupListView();
            SetupCategoryButtons();

            btnSearch.Click += (_, _) => _ = LoadNoticesAsync();
            txtSearch.KeyPress += (_, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                    _ = LoadNoticesAsync();
            };

            _ = LoadNoticesAsync();
        }

        private void SetupListView()
        {
            int fillWidth = richNotice.Width
                            - 70 - 110 - 110 - 130
                            - SystemInformation.VerticalScrollBarWidth
                            - 4;

            listViewNotices = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = false,
                Location = richNotice.Location,
                Size = richNotice.Size,
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.None,
                HeaderStyle = ColumnHeaderStyle.Nonclickable,
            };

            listViewNotices.Columns.Add("번호",    70);
            listViewNotices.Columns.Add("카테고리", 110);
            listViewNotices.Columns.Add("제목",    fillWidth);
            listViewNotices.Columns.Add("작성일",  110);
            listViewNotices.Columns.Add("부서",    130);

            listViewNotices.DoubleClick += ListViewNotices_DoubleClick;
            Controls.Add(listViewNotices);
        }

        private void SetupCategoryButtons()
        {
            foreach (var (name, id) in Categories)
            {
                var btn = new Button
                {
                    Text = name,
                    AutoSize = false,
                    Size = new Size(110, 36),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F),
                    BackColor = Color.FromArgb(220, 220, 220),
                    ForeColor = Color.Black,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(2, 2, 2, 2),
                };
                btn.FlatAppearance.BorderSize = 0;

                string capturedId = id;
                btn.Click += (_, _) =>
                {
                    SetActiveButton(btn);
                    _currentCategoryId = capturedId;
                    txtSearch.Clear();
                    _ = LoadNoticesAsync();
                };

                if (id == "")
                    SetActiveButton(btn);

                flpCategories.Controls.Add(btn);
            }
        }

        private void SetActiveButton(Button btn)
        {
            if (_activeCategoryBtn != null)
            {
                _activeCategoryBtn.BackColor = Color.FromArgb(220, 220, 220);
                _activeCategoryBtn.ForeColor = Color.Black;
            }
            _activeCategoryBtn = btn;
            btn.BackColor = Color.FromArgb(90, 0, 31);
            btn.ForeColor = Color.White;
        }

        private async Task LoadNoticesAsync()
        {
            listViewNotices.Items.Clear();
            listViewNotices.Items.Add(new ListViewItem(new[] { "", "", "불러오는 중…", "", "" }));

            try
            {
                var notices = await _noticeService.FetchAsync(_currentCategoryId, txtSearch.Text.Trim());

                void updateUI()
                {
                    listViewNotices.Items.Clear();

                    if (notices.Count == 0)
                    {
                        listViewNotices.Items.Add(
                            new ListViewItem(new[] { "", "", "공지사항이 없습니다.", "", "" }));
                        return;
                    }

                    foreach (var n in notices)
                    {
                        var item = new ListViewItem(
                            new[] { n.Number, n.Category, n.Title, n.Date, n.Author });
                        item.Tag = n.Url;
                        if (n.IsPinned)
                            item.ForeColor = Color.FromArgb(90, 0, 31);
                        listViewNotices.Items.Add(item);
                    }
                }

                if (InvokeRequired) Invoke(updateUI);
                else updateUI();
            }
            catch
            {
                void setError()
                {
                    listViewNotices.Items.Clear();
                    listViewNotices.Items.Add(new ListViewItem(
                        new[] { "", "", "공지사항을 불러올 수 없습니다. 네트워크 연결을 확인하세요.", "", "" }));
                }
                if (InvokeRequired) Invoke(setError);
                else setError();
            }
        }

        private void ListViewNotices_DoubleClick(object sender, EventArgs e)
        {
            if (listViewNotices.SelectedItems.Count == 0) return;
            var url = listViewNotices.SelectedItems[0].Tag as string;
            if (!string.IsNullOrEmpty(url))
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
