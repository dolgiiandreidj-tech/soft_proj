namespace Everytime.Sessions;

public sealed record SessionCookie(
    string Name,
    string Value,
    string Domain,
    string Path,
    DateTimeOffset? Expires);

public sealed class Session
{
    public required IReadOnlyList<SessionCookie> Cookies { get; init; }
    public required string UserAgent { get; init; }
    public Dictionary<string, string> Tokens { get; init; } = new();
    public DateTimeOffset SavedAt { get; init; } = DateTimeOffset.UtcNow;

    /// <summary>TTL-based staleness check; real auth failures trigger re-login at runtime.</summary>
    public bool IsExpired(TimeSpan ttl) => DateTimeOffset.UtcNow - SavedAt > ttl;
}
