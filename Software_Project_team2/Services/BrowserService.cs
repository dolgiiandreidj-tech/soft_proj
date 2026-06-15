using Everytime.Sessions;
using System.Net;

namespace Software_Project_team2.Services
{
    // Builds an HttpClient pre-loaded with KLAS session cookies saved by the WebView2 login form.
    public static class KlasHttpClientFactory
    {
        public static HttpClient FromSession(Session session)
        {
            var jar = new CookieContainer();
            foreach (var c in session.Cookies)
            {
                var cookie = new Cookie(c.Name, c.Value, c.Path ?? "/") { Domain = c.Domain };
                jar.Add(new Uri($"https://{c.Domain.TrimStart('.')}/"), cookie);
            }

            var handler = new HttpClientHandler
            {
                CookieContainer = jar,
                UseCookies = true,
                AutomaticDecompression = DecompressionMethods.All,
                AllowAutoRedirect = true
            };

            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.UserAgent.ParseAdd(session.UserAgent);
            client.DefaultRequestHeaders.Add("Referer", "https://klas.kw.ac.kr/");
            return client;
        }
    }
}
