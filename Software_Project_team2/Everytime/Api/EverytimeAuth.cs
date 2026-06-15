using Everytime.Sessions;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Everytime.Api;

public sealed class LoginFailedException(string message) : Exception(message);

public static class EverytimeAuth
{
    private const string LoginPageUrl = "https://account.everytime.kr/login";
    private const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:139.0) Gecko/20100101 Firefox/139.0";

    public static async Task<Session> LoginAsync(string id, string password, CancellationToken ct = default)
    {
        var cookieContainer = new CookieContainer();
        var handler = new HttpClientHandler
        {
            CookieContainer = cookieContainer,
            UseCookies = true,
            AllowAutoRedirect = true,
            AutomaticDecompression = DecompressionMethods.All
        };

        using var client = new HttpClient(handler);
        client.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);

        // Step 1: GET login page to collect cookies and CSRF token
        var getResp = await client.GetAsync(LoginPageUrl, ct);
        var html = await getResp.Content.ReadAsStringAsync(ct);

        // Extract hidden _token field (Laravel/common CSRF pattern)
        var token = ExtractHiddenInput(html, "_token")
                    ?? ExtractMetaContent(html, "csrf-token");

        // Step 2: POST credentials
        var fields = new Dictionary<string, string>
        {
            ["id"] = id,
            ["password"] = password
        };
        if (token != null)
            fields["_token"] = token;

        using var body = new FormUrlEncodedContent(fields);

        var postReq = new HttpRequestMessage(HttpMethod.Post, LoginPageUrl) { Content = body };
        postReq.Headers.Referrer = new Uri(LoginPageUrl);
        postReq.Headers.TryAddWithoutValidation("Origin", "https://account.everytime.kr");
        postReq.Headers.TryAddWithoutValidation("X-Requested-With", "XMLHttpRequest");

        using var resp = await client.SendAsync(postReq, ct);
        var raw = await resp.Content.ReadAsStringAsync(ct);

        if (!resp.IsSuccessStatusCode)
            throw new LoginFailedException($"HTTP {(int)resp.StatusCode}: {raw[..Math.Min(200, raw.Length)]}");

        JsonElement root;
        try
        {
            using var doc = JsonDocument.Parse(raw);
            root = doc.RootElement.Clone();
        }
        catch
        {
            throw new LoginFailedException($"서버 응답 오류 (JSON 아님):\n{raw[..Math.Min(400, raw.Length)]}");
        }

        if (root.TryGetProperty("status", out var statusProp) && statusProp.GetInt32() != 200)
        {
            var msg = root.TryGetProperty("message", out var m) ? m.GetString() : "로그인 실패";
            throw new LoginFailedException(msg ?? "로그인 실패");
        }

        var cookies = cookieContainer.GetAllCookies()
            .Select(c => new SessionCookie(
                c.Name,
                c.Value,
                string.IsNullOrEmpty(c.Domain) ? ".everytime.kr" : c.Domain,
                string.IsNullOrEmpty(c.Path) ? "/" : c.Path,
                c.Expires == DateTime.MinValue ? null : (DateTimeOffset?)c.Expires))
            .ToList();

        if (!cookies.Any(c => c.Name == "etsid"))
            throw new LoginFailedException("세션 쿠키를 받지 못했습니다. 아이디 또는 비밀번호를 확인하세요.");

        return new Session
        {
            Cookies = cookies,
            UserAgent = UserAgent
        };
    }

    private static string? ExtractHiddenInput(string html, string name)
    {
        var m = Regex.Match(html,
            $@"<input[^>]+name=[""']{Regex.Escape(name)}[""'][^>]+value=[""']([^""']*)[""']",
            RegexOptions.IgnoreCase);
        if (m.Success) return m.Groups[1].Value;

        // Also try value before name
        m = Regex.Match(html,
            $@"<input[^>]+value=[""']([^""']*)[""'][^>]+name=[""']{Regex.Escape(name)}[""']",
            RegexOptions.IgnoreCase);
        return m.Success ? m.Groups[1].Value : null;
    }

    private static string? ExtractMetaContent(string html, string name)
    {
        var m = Regex.Match(html,
            $@"<meta[^>]+name=[""']{Regex.Escape(name)}[""'][^>]+content=[""']([^""']*)[""']",
            RegexOptions.IgnoreCase);
        return m.Success ? m.Groups[1].Value : null;
    }
}
