using Everytime.Sessions;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace Software_Project_team2
{
    public partial class LoginForm : Form
    {
        private readonly WebView2 _webView = new();
        private bool _saved;

        public LoginForm()
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
                await _webView.EnsureCoreWebView2Async();
                _webView.CoreWebView2.NavigationCompleted += OnNavigationCompleted;
                _webView.CoreWebView2.Navigate("https://everytime.kr/login");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"WebView2 초기화 실패: {ex.Message}\n\nWebView2 런타임이 설치되어 있는지 확인하세요.",
                    "오류");
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private async void OnNavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (_saved) return;

            var url = _webView.Source?.ToString() ?? "";

            // Login succeeded when redirected away from the login page back to the main site
            if (!url.Contains("/login") && url.StartsWith("https://everytime.kr/"))
            {
                await TrySaveSessionAsync();
            }
        }

        private async Task TrySaveSessionAsync()
        {
            var mgr = _webView.CoreWebView2.CookieManager;

            var raw = await mgr.GetCookiesAsync("https://everytime.kr");

            var etsid = raw.FirstOrDefault(c => c.Name == "etsid");
            if (etsid == null) return; // not logged in yet

            _saved = true;

            // Also grab account-subdomain cookies (x-et-device lives there)
            var accountRaw = await mgr.GetCookiesAsync("https://account.everytime.kr");

            var all = raw.Concat(accountRaw)
                .GroupBy(c => c.Name)
                .Select(g => g.First())
                .Select(c =>
                {
                    // WebView2/Chrome strips leading dots from Set-Cookie Domain attributes.
                    // Restore it so cookies reach api.everytime.kr (not just the exact host).
                    var dom = string.IsNullOrEmpty(c.Domain) ? ".everytime.kr" : c.Domain;
                    if (!dom.StartsWith('.')) dom = "." + dom;
                    return new SessionCookie(
                        c.Name, c.Value, dom,
                        string.IsNullOrEmpty(c.Path) ? "/" : c.Path,
                        c.Expires == DateTime.MinValue ? null : (DateTimeOffset?)new DateTimeOffset(c.Expires));
                })
                .ToList();

            var session = new Session
            {
                Cookies = all,
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:139.0) Gecko/20100101 Firefox/139.0"
            };

            var store = new SessionStore(
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "everytime.session.json"));

            await store.SaveAsync(session);

            Invoke(() =>
            {
                DialogResult = DialogResult.OK;
                Close();
            });
        }
    }
}
