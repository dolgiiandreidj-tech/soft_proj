using System.Text.Json;

namespace Everytime.Sessions;

public sealed class SessionStore
{
    private readonly string _path;
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    public SessionStore(string path) => _path = path;

    public async Task SaveAsync(Session session, CancellationToken ct = default)
    {
        var dir = Path.GetDirectoryName(_path);
        if (!string.IsNullOrEmpty(dir))
            Directory.CreateDirectory(dir);
        await using var stream = File.Create(_path);
        await JsonSerializer.SerializeAsync(stream, session, Options, ct);
    }

    public async Task<Session?> LoadAsync(CancellationToken ct = default)
    {
        if (!File.Exists(_path))
            return null;
        await using var stream = File.OpenRead(_path);
        return await JsonSerializer.DeserializeAsync<Session>(stream, Options, ct);
    }

    public void Delete()
    {
        if (File.Exists(_path))
            File.Delete(_path);
    }
}
