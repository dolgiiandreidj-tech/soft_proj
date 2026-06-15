using Everytime.Sessions;
using HtmlAgilityPack;
using System.Globalization;
using System.Text.RegularExpressions;
using HtmlDoc = HtmlAgilityPack.HtmlDocument;

namespace Software_Project_team2.Services
{
    public class KlasService
    {
        private const string BaseUrl = "https://klas.kw.ac.kr";
        private const string ProgressionUrl = BaseUrl + "/std/cps/inqire/AtnlcScreStdPage.do";
        private const string FrameUrl = BaseUrl + "/std/cmn/frame/Frame.do";

        private readonly HttpClient _client;

        public KlasService(Session session)
        {
            _client = KlasHttpClientFactory.FromSession(session);
        }

        // ──────────────────────────────────────────────────────────────────
        // Progression credits
        // ──────────────────────────────────────────────────────────────────

        public async Task<(int Major, int General, int Other)> GetProgressionCreditsAsync()
        {
            var doc = await GetDocAsync(ProgressionUrl);
            var table = FindTableWithHeader(doc, "신청학점");
            if (table == null) return (0, 0, 0);

            var tds = table.SelectNodes(".//tbody/tr/td");
            if (tds == null || tds.Count < 3) return (0, 0, 0);

            return (ParseCredit(tds[0].InnerText),
                    ParseCredit(tds[1].InnerText),
                    ParseCredit(tds[2].InnerText));
        }

        public async Task<string> GetGpaAsync()
        {
            var doc = await GetDocAsync(ProgressionUrl);
            var table = FindTableWithHeader(doc, "신청학점");
            if (table == null) return "0.00";

            var tds = table.SelectNodes(".//tbody/tr/td");
            if (tds == null || tds.Count == 0) return "0.00";

            var parsed = new List<double>();
            foreach (var td in tds)
            {
                var raw = Regex.Replace(td.InnerText, @"\s+", "").Replace(',', '.');
                // Strip trailing parenthesized parts like "26(0)"
                var token = raw.Split('(')[0];
                if (double.TryParse(token, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                        CultureInfo.InvariantCulture, out double v))
                    parsed.Add(v);
            }

            return parsed.Count == 0 ? "0.00" : parsed.Last().ToString("F2", CultureInfo.InvariantCulture);
        }

        // ──────────────────────────────────────────────────────────────────
        // User name from top navigation
        // ──────────────────────────────────────────────────────────────────

        public async Task<string> GetUserNameAsync()
        {
            var doc = await GetDocAsync(BaseUrl);
            var anchor = doc.DocumentNode.SelectSingleNode(
                "//div[contains(@class,'navtxt')]//a[contains(@href,'MyInfoStdPage')]");
            if (anchor == null) return string.Empty;

            var text = HtmlEntity.DeEntitize(anchor.InnerText)
                .Replace("\r", "").Replace("\n", "").Trim();
            var idx = text.IndexOf('(');
            return idx > 0 ? text[..idx].Trim() : text;
        }

        // ──────────────────────────────────────────────────────────────────
        // Timetable
        // ──────────────────────────────────────────────────────────────────

        public async Task<List<LessonModel>> GetTimetableAsync()
        {
            var doc = await GetDocAsync(FrameUrl);

            var table = doc.DocumentNode.SelectSingleNode(
                "//div[contains(@class,'schedule')]//table[contains(@class,'scheduletb')]");

            var result = new List<LessonModel>();
            if (table == null) return result;

            var rows = table.SelectNodes(".//tbody/tr");
            if (rows == null) return result;

            foreach (var row in rows)
            {
                // First td with class "time" holds the period number
                var timeCell = row.SelectSingleNode(".//td[contains(@class,'time')]");
                if (timeCell == null) continue;
                if (!int.TryParse(timeCell.InnerText.Trim(), out int slot)) continue;

                var cells = row.SelectNodes("td");
                if (cells == null) continue;

                // cells[0] = time, cells[1..] = Mon,Tue,Wed,Thu,Fri,Sat
                for (int c = 1; c < cells.Count; c++)
                {
                    var cell = cells[c];
                    var div = cell.SelectSingleNode("div");
                    if (div == null) continue;

                    var divClass = div.GetAttributeValue("class", "");
                    var m = Regex.Match(divClass, @"lessontime(\d+)");
                    int duration = m.Success ? int.Parse(m.Groups[1].Value) : 1;

                    var pNode = div.SelectSingleNode("p");
                    string ptext = pNode != null
                        ? HtmlEntity.DeEntitize(pNode.InnerText)
                        : HtmlEntity.DeEntitize(div.InnerText);

                    ptext = Regex.Replace(ptext, @"\r|\n|\t", " ").Trim();
                    ptext = Regex.Replace(ptext, @"\s{2,}", " ");

                    string title = ptext, location = "", instructor = "";

                    var parenMatch = Regex.Match(ptext, @"^(.*?)\s*\((.*?)\)$");
                    if (parenMatch.Success)
                    {
                        title = parenMatch.Groups[1].Value.Trim();
                        var parts = parenMatch.Groups[2].Value
                            .Split('/', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length >= 1) location = parts[0];
                        if (parts.Length >= 2) instructor = parts[1];
                    }

                    result.Add(new LessonModel
                    {
                        Day = c - 1,        // 0=Mon … 5=Sat
                        StartSlot = slot,
                        Duration = duration,
                        Title = title,
                        Location = location,
                        Instructor = instructor,
                        CssClass = divClass
                    });
                }
            }

            return result;
        }

        // ──────────────────────────────────────────────────────────────────
        // Helpers
        // ──────────────────────────────────────────────────────────────────

        private async Task<HtmlDoc> GetDocAsync(string url)
        {
            var html = await _client.GetStringAsync(url);
            var doc = new HtmlDoc();
            doc.LoadHtml(html);
            return doc;
        }

        private static HtmlNode? FindTableWithHeader(HtmlDoc doc, string headerText)
        {
            var tables = doc.DocumentNode.SelectNodes("//table[contains(@class,'tablegw')]");
            if (tables == null) return null;
            return tables.FirstOrDefault(t => t.InnerText.Contains(headerText));
        }

        private static int ParseCredit(string text)
        {
            var clean = Regex.Replace(text, @"\s+", "");
            if (int.TryParse(clean.Split('\n', '\r')[0], out int v)) return v;
            return 0;
        }
    }

    // ──────────────────────────────────────────────────────────────────
    // Data model (shared with Timetable.cs)
    // ──────────────────────────────────────────────────────────────────

    public class LessonModel
    {
        public int Day { get; set; }          // 0=Mon … 5=Sat
        public int StartSlot { get; set; }
        public int Duration { get; set; } = 1;
        public string Title { get; set; } = "";
        public string Location { get; set; } = "";
        public string Instructor { get; set; } = "";
        public string CssClass { get; set; } = "";
    }
}
