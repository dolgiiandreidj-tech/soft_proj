using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using Everytime.Models;

namespace Everytime.Api;

public sealed class SessionExpiredException()
    : Exception("Session expired. Run: dotnet run --project ConsoleApp3 -- set-cookies \"x-et-device=xxx; etsid=xxx\"");

public sealed class EverytimeClient(HttpClient client)
{
    private static readonly StringContent EmptyForm =
        new("", Encoding.UTF8, "application/x-www-form-urlencoded");

    private static void EnsureNotExpired(HttpResponseMessage resp)
    {
        if (resp.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            throw new SessionExpiredException();
        resp.EnsureSuccessStatusCode();
    }

    public async Task<List<Lecture>> GetMyLecturesAsync(CancellationToken ct = default)
    {
        using var resp = await client.PostAsync(
            "https://api.everytime.kr/v2/find/lecture/list/mine", EmptyForm, ct);
        EnsureNotExpired(resp);
        return ParseLectures(await resp.Content.ReadAsStringAsync(ct));
    }

    public async Task<List<Review>> GetAllReviewsAsync(int lectureId, CancellationToken ct = default)
    {
        var all = new List<Review>();
        const int limit = 20;
        var offset = 0;
        while (true)
        {
            using var body = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["lectureId"] = lectureId.ToString(),
                ["limit"] = limit.ToString(),
                ["offset"] = offset.ToString(),
                ["sort"] = "id"
            });
            using var resp = await client.PostAsync(
                "https://api.everytime.kr/find/lecture/article/list", body, ct);
            EnsureNotExpired(resp);
            var page = ParseReviews(await resp.Content.ReadAsStringAsync(ct));
            all.AddRange(page);
            if (page.Count < limit) break;
            offset += limit;
        }
        return all;
    }

    public static List<Lecture> ParseLectures(string json)
    {
        using var doc = JsonDocument.Parse(json);
        return doc.RootElement
            .GetProperty("result")
            .GetProperty("lectures")
            .EnumerateArray()
            .Select(l => new Lecture
            {
                Id = l.GetProperty("id").GetInt32(),
                Name = l.GetProperty("name").GetString(),
                Professor = l.GetProperty("professor").GetString(),
                Code = l.GetProperty("class").GetProperty("code").GetString()
            })
            .ToList();
    }

    public async Task<List<Subject>> GetAllSubjectsAsync(
        int campusId, int year, string semester,
        string keyword = "", string condition = "name",
        CancellationToken ct = default)
    {
        var all = new List<Subject>();
        const int limit = 50;
        var start = 0;
        while (true)
        {
            var fields = new Dictionary<string, string>
            {
                ["campusId"] = campusId.ToString(),
                ["year"] = year.ToString(),
                ["semester"] = semester,
                ["keyword"] = keyword,
                ["condition"] = condition,
                ["limitNum"] = limit.ToString(),
                ["startNum"] = start.ToString()
            };
            using var body = new FormUrlEncodedContent(fields);
            using var resp = await client.PostAsync(
                "https://api.everytime.kr/find/timetable/subject/list", body, ct);
            EnsureNotExpired(resp);
            var page = ParseSubjects(await resp.Content.ReadAsStringAsync(ct));
            all.AddRange(page);
            if (page.Count < limit) break;
            start += limit;
        }
        return all;
    }

    public static List<Subject> ParseSubjects(string xml)
    {
        var doc = XDocument.Parse(xml);
        return doc.Root!.Elements("subject")
            .Select(s => new Subject
            {
                Id = s.Attribute("id")?.Value,
                Code = s.Attribute("code")?.Value,
                Name = s.Attribute("name")?.Value,
                Professor = s.Attribute("professor")?.Value,
                Type = s.Attribute("type")?.Value,
                Credit = int.TryParse(s.Attribute("credit")?.Value, out var cr) ? cr : 0,
                Popular = int.TryParse(s.Attribute("popular")?.Value, out var pop) ? pop : 0,
                Notice = s.Attribute("notice")?.Value,
                LectureId = s.Attribute("lectureId")?.Value,
                LectureRate = double.TryParse(s.Attribute("lectureRate")?.Value,
                    NumberStyles.Any, CultureInfo.InvariantCulture, out var rate) ? rate : 0,
                TimePlaces = s.Elements("timeplace")
                    .Select(tp => new TimePlace
                    {
                        Day = int.TryParse(tp.Attribute("day")?.Value, out var d) ? d : 0,
                        Start = int.TryParse(tp.Attribute("start")?.Value, out var st) ? st : 0,
                        End = int.TryParse(tp.Attribute("end")?.Value, out var en) ? en : 0,
                        Place = tp.Attribute("place")?.Value
                    }).ToList()
            }).ToList();
    }

    public static List<Review> ParseReviews(string json)
    {
        using var doc = JsonDocument.Parse(json);
        return doc.RootElement
            .GetProperty("result")
            .GetProperty("articles")
            .EnumerateArray()
            .Select(a => new Review
            {
                Id = a.GetProperty("id").GetInt32(),
                Year = a.GetProperty("year").GetInt32(),
                Semester = a.GetProperty("semester").GetString(),
                Text = a.GetProperty("text").GetString(),
                Rate = a.GetProperty("rate").GetDouble(),
                PosVote = a.GetProperty("posvote").GetInt32()
            })
            .ToList();
    }
}
