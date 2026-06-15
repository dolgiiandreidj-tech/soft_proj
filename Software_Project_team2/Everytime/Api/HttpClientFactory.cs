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
            // WebView2 strips the leading dot from cookie domains (Chrome internals).
            // Without the dot, CookieContainer treats the cookie as host-only and won't
            // send it to api.everytime.kr — only to the exact host it was set for.
            // Restore the leading dot so the cookie is scoped to all subdomains.
            var domain = c.Domain.StartsWith('.') ? c.Domain : "." + c.Domain;
            var cookie = new Cookie(c.Name, c.Value, c.Path ?? "/") { Domain = domain };
            cookies.Add(new Uri($"https://{domain.TrimStart('.')}/"), cookie);
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
