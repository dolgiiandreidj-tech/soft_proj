using System.Net;
using Everytime.Sessions;

namespace Everytime.Api;

public static class HttpClientFactory
{
    public static HttpClient FromSession(Session session)
    {
        var cookies = new CookieContainer();
        foreach (var c in session.Cookies)
        {
            // Use Uri-based Add so the container respects leading-dot domains
            // (.everytime.kr must match api.everytime.kr, not just everytime.kr)
            var cookie = new Cookie(c.Name, c.Value, c.Path ?? "/") { Domain = c.Domain };
            cookies.Add(new Uri($"https://{c.Domain.TrimStart('.')}/"), cookie);
        }

        var handler = new HttpClientHandler
        {
            CookieContainer = cookies,
            UseCookies = true,
            AutomaticDecompression = DecompressionMethods.All
        };

        var client = new HttpClient(handler);
        client.DefaultRequestHeaders.UserAgent.ParseAdd(session.UserAgent);
        foreach (var (name, value) in session.Tokens)
            client.DefaultRequestHeaders.TryAddWithoutValidation(name, value);
        return client;
    }
}
