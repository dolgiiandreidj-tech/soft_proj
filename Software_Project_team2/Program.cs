using Everytime.Sessions;

namespace Software_Project_team2
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            EnsureEverytimeSession().GetAwaiter().GetResult();
            Application.Run(new Form1());
        }

        private static async Task EnsureEverytimeSession()
        {
            var store = new SessionStore(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "everytime.session.json"));

            var session = await store.LoadAsync();
            if (session != null && !session.IsExpired(TimeSpan.FromDays(7)))
                return;

            var form = new LoginForm();
            if (form.ShowDialog() != DialogResult.OK)
                Environment.Exit(0);
        }
    }
}
