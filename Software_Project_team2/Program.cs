using Everytime.Sessions;

namespace Software_Project_team2
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            SaveEverytimeSession().GetAwaiter().GetResult();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        private static async Task SaveEverytimeSession()
        {
            var cookies = new List<SessionCookie>
            {
                new("etsid", "s%3AfnED1WohjWvpcHACq2XNm1ZRyJkSDxoS.6mLzXeEhuro44V1vl371HOT47Xc360zbIrmlfxkLDDE", ".everytime.kr", "/", null),
                new("x-et-device", "10788770", ".everytime.kr", "/", null),
            };

            var session = new Session
            {
                Cookies = cookies,
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:139.0) Gecko/20100101 Firefox/139.0"
            };

            var store = new SessionStore(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "everytime.session.json"));
            await store.SaveAsync(session);
        }
    }
}
