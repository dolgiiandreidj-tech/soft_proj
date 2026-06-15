using Everytime.Sessions;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace Software_Project_team2
{
    public partial class Form1 : Form
    {
        public static readonly string SessionPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "klas.session.json");

        private readonly WebView2 _webView = new();
        private bool _saved;

        public Form1()
        {
            InitializeComponent();
            _webView.Dock = DockStyle.Fill;
            panelBrowser.Controls.Add(_webView);
            Load += async (_, _) => await InitAsync();
        }

        private async Task InitAsync()
        {
            try
            {
                labelStatus.Text = "WebView2 초기화 중...";
                await _webView.EnsureCoreWebView2Async();
                _webView.CoreWebView2.NavigationCompleted += OnNavigationCompleted;
                _webView.CoreWebView2.Navigate("https://klas.kw.ac.kr");
                labelStatus.Text = "광운대학교 KLAS 계정으로 로그인하세요";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"WebView2 초기화 실패: {ex.Message}\n\nMicrosoft Edge WebView2 런타임이 설치되어 있는지 확인하세요.",
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private async void OnNavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (_saved) return;

            var url = _webView.Source?.ToString() ?? "";
            if (url.Contains("Frame.do"))
            {
                _saved = true;
                labelStatus.Text = "로그인 성공! 세션 저장 중...";
                await SaveSessionAsync();
            }
        }

        private async Task SaveSessionAsync()
        {
            var mgr = _webView.CoreWebView2.CookieManager;
            var raw = await mgr.GetCookiesAsync("https://klas.kw.ac.kr");

            var cookies = raw.Select(c => new SessionCookie(
                    c.Name,
                    c.Value,
                    string.IsNullOrEmpty(c.Domain) ? ".klas.kw.ac.kr" : c.Domain,
                    string.IsNullOrEmpty(c.Path) ? "/" : c.Path,
                    c.Expires == DateTime.MinValue ? null : (DateTimeOffset?)new DateTimeOffset(c.Expires)))
                .ToList();

            var session = new Session
            {
                Cookies = cookies,
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36"
            };

            var store = new SessionStore(SessionPath);
            await store.SaveAsync(session);

            Invoke(() => { DialogResult = DialogResult.OK; Close(); });
        }
    }
}
