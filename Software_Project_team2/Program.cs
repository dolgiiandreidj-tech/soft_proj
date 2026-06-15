using Everytime.Sessions;
using Software_Project_team2.Services;

namespace Software_Project_team2
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Step 1: KLAS login (WebView2)
            var klasSession = EnsureKlasSession();
            if (klasSession == null) return;

            // Step 2: Everytime login (WebView2)
            if (!EnsureEverytimeSession()) return;

            // Step 3: Launch dashboard
            var klasService = new KlasService(klasSession);
            Application.Run(new DashboardPage(klasService));
        }

        private static Session? EnsureKlasSession()
        {
            var store = new SessionStore(Form1.SessionPath);

            // Try to load a cached session (valid for 12 hours)
            Session? session = null;
            try { session = store.LoadAsync().GetAwaiter().GetResult(); } catch { }

            if (session != null && !session.IsExpired(TimeSpan.FromHours(12)))
                return session;

            // Need fresh login
            using var form = new Form1();
            if (form.ShowDialog() != DialogResult.OK)
                return null;

            try { session = store.LoadAsync().GetAwaiter().GetResult(); } catch { }
            return session;
        }

        private static bool EnsureEverytimeSession()
        {
            var storePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "everytime.session.json");
            var store = new SessionStore(storePath);

            Session? session = null;
            try { session = store.LoadAsync().GetAwaiter().GetResult(); } catch { }

            if (session != null && !session.IsExpired(TimeSpan.FromDays(7)))
                return true;

            using var form = new LoginForm();
            return form.ShowDialog() == DialogResult.OK;
        }
    }
}
