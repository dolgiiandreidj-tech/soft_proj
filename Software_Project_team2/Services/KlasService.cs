using Everytime.Sessions;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace Software_Project_team2.Services
{
    public class KlasService
    {
        private const string BaseUrl = "https://klas.kw.ac.kr";
        private const string FrameUrl   = BaseUrl + "/std/cmn/frame/Frame.do";
        private const string StdHomeUrl = BaseUrl + "/std/cmn/frame/StdHome.do";

        // JSON API endpoints (all accept empty-body POST, return JSON)
        private const string SungjukTotUrl      = BaseUrl + "/std/cps/inqire/AtnlcScreSungjukTot.do";
        private const string HakjukInfoUrl      = BaseUrl + "/std/cps/inqire/AtnlcScreHakjukInfo.do";
        private const string ProgramGubunUrl    = BaseUrl + "/std/cps/inqire/AtnlcScreProgramGubun.do";
        private const string ProgressionReferer = BaseUrl + "/std/cps/inqire/AtnlcScreStdPage.do";

        private readonly HttpClient _client;

        public KlasService(Session session)
        {
            _client = KlasHttpClientFactory.FromSession(session);
        }

        // ──────────────────────────────────────────────────────────────────
        // Progression credits  (majorChidukHakjum / cultureChidukHakjum / etcChidukHakjum)
        // ──────────────────────────────────────────────────────────────────

        public async Task<(int Major, int General, int Other)> GetProgressionCreditsAsync()
        {
            var root = await PostApiJsonAsync(SungjukTotUrl);
            int major   = root.GetProperty("majorChidukHakjum").GetInt32();
            int culture = root.GetProperty("cultureChidukHakjum").GetInt32();
            int etc     = root.GetProperty("etcChidukHakjum").GetInt32();
            return (major, culture, etc);
        }

        // ──────────────────────────────────────────────────────────────────
        // GPA  (hwakinScoresum)
        // ──────────────────────────────────────────────────────────────────

        public async Task<string> GetGpaAsync()
        {
            var root = await PostApiJsonAsync(SungjukTotUrl);
            double gpa = root.GetProperty("hwakinScoresum").GetDouble();
            return gpa.ToString("F2", CultureInfo.InvariantCulture);
        }

        // ──────────────────────────────────────────────────────────────────
        // User name  (kname from AtnlcScreHakjukInfo)
        // ──────────────────────────────────────────────────────────────────

        public async Task<string> GetUserNameAsync()
        {
            var root = await PostApiJsonAsync(HakjukInfoUrl);
            return root.TryGetProperty("kname", out var kname)
                ? kname.GetString() ?? string.Empty
                : string.Empty;
        }

        // ──────────────────────────────────────────────────────────────────
        // Full student / hakjuk info  (AtnlcScreHakjukInfo.do)
        // ──────────────────────────────────────────────────────────────────

        public async Task<HakjukInfo> GetHakjukInfoAsync()
        {
            var root = await PostApiJsonAsync(HakjukInfoUrl);
            string Str(string key) => root.TryGetProperty(key, out var v) ? v.GetString() ?? "" : "";
            return new HakjukInfo
            {
                KName       = Str("kname"),
                Hakgwa      = Str("hakgwa"),
                Hakbun      = Str("hakbun"),
                HakjukStatu = Str("hakjukStatu"),
                JidoName    = Str("jidoName"),
                Email       = Str("email"),
            };
        }

        // ──────────────────────────────────────────────────────────────────
        // Full credit / GPA totals  (AtnlcScreSungjukTot.do)
        // ──────────────────────────────────────────────────────────────────

        public async Task<SungjukTot> GetSungjukTotAsync()
        {
            var root = await PostApiJsonAsync(SungjukTotUrl);
            int    GetInt(string key) => root.TryGetProperty(key, out var v) ? v.GetInt32()    : 0;
            double GetDbl(string key) => root.TryGetProperty(key, out var v) ? v.GetDouble()   : 0;
            return new SungjukTot
            {
                ApplyHakjum         = GetInt("applyHakjum"),
                MajorApplyHakjum    = GetInt("majorApplyHakjum"),
                CultureApplyHakjum  = GetInt("cultureApplyHakjum"),
                EtcApplyHakjum      = GetInt("etcApplyHakjum"),
                ChidukHakjum        = GetInt("chidukHakjum"),
                MajorChidukHakjum   = GetInt("majorChidukHakjum"),
                CultureChidukHakjum = GetInt("cultureChidukHakjum"),
                EtcChidukHakjum     = GetInt("etcChidukHakjum"),
                DelHakjum           = GetInt("delHakjum"),
                MajorDelHakjum      = GetInt("majorDelHakjum"),
                CultureDelHakjum    = GetInt("cultureDelHakjum"),
                EtcDelHakjum        = GetInt("etcDelHakjum"),
                HwakinScoresum      = GetDbl("hwakinScoresum"),
                JaechulScoresum     = GetDbl("jaechulScoresum"),
            };
        }

        // ──────────────────────────────────────────────────────────────────
        // Program (degree track) info  (AtnlcScreProgramGubun.do)
        // ──────────────────────────────────────────────────────────────────

        public async Task<(string PgmName, string CertOpt)> GetProgramGubunAsync()
        {
            var root = await PostApiJsonAsync(ProgramGubunUrl);
            string Str(string key) => root.TryGetProperty(key, out var v) ? v.GetString() ?? "" : "";
            return (Str("pgmName"), Str("certOpt"));
        }

        // ──────────────────────────────────────────────────────────────────
        // Course list for current semester  (StdHome.do)
        // ──────────────────────────────────────────────────────────────────

        public async Task<CourseListResult> GetCourseListAsync()
        {
            using var req = new HttpRequestMessage(HttpMethod.Post, StdHomeUrl);
            req.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
            req.Headers.Referrer = new Uri(FrameUrl);
            req.Content = new StringContent("{\"searchYearhakgi\":null}", Encoding.UTF8, "application/json");

            var resp = await _client.SendAsync(req);
            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync();

            var result = new CourseListResult();
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            if (root.TryGetProperty("yearhakgi", out var yp))
                result.Yearhakgi = yp.GetString() ?? "";

            if (root.TryGetProperty("atnlcSbjectList", out var list))
            {
                foreach (var item in list.EnumerateArray())
                {
                    string Str(string key) => item.TryGetProperty(key, out var v) ? v.GetString() ?? "" : "";
                    result.Subjects.Add(new CourseInfo
                    {
                        SubjNm           = Str("subjNm"),
                        Hakjungno        = Str("hakjungno"),
                        ProfNm           = Str("profNm"),
                        LctrumSchdulInfo = Str("lctrumSchdulInfo"),
                        OpenOrganCodeNm  = Str("openOrganCodeNm"),
                    });
                }
            }

            return result;
        }

        // ──────────────────────────────────────────────────────────────────
        // Helpers
        // ──────────────────────────────────────────────────────────────────

        private async Task<JsonElement> PostApiJsonAsync(string url)
        {
            using var req = new HttpRequestMessage(HttpMethod.Post, url);
            req.Headers.TryAddWithoutValidation("Accept", "application/json");
            req.Headers.Referrer = new Uri(ProgressionReferer);
            req.Content = new ByteArrayContent(Array.Empty<byte>());
            req.Content.Headers.ContentLength = 0;

            var resp = await _client.SendAsync(req);
            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            return doc.RootElement.Clone();
        }
    }

    public class CourseInfo
    {
        public string SubjNm { get; set; } = "";
        public string Hakjungno { get; set; } = "";
        public string ProfNm { get; set; } = "";
        public string LctrumSchdulInfo { get; set; } = "";
        public string OpenOrganCodeNm { get; set; } = "";
    }

    public class CourseListResult
    {
        public string Yearhakgi { get; set; } = "";
        public List<CourseInfo> Subjects { get; set; } = new();
    }

    public class HakjukInfo
    {
        public string KName { get; set; } = "";
        public string Hakgwa { get; set; } = "";
        public string Hakbun { get; set; } = "";
        public string HakjukStatu { get; set; } = "";
        public string JidoName { get; set; } = "";
        public string Email { get; set; } = "";
    }

    public class SungjukTot
    {
        public int ApplyHakjum { get; set; }
        public int MajorApplyHakjum { get; set; }
        public int CultureApplyHakjum { get; set; }
        public int EtcApplyHakjum { get; set; }
        public int ChidukHakjum { get; set; }
        public int MajorChidukHakjum { get; set; }
        public int CultureChidukHakjum { get; set; }
        public int EtcChidukHakjum { get; set; }
        public int DelHakjum { get; set; }
        public int MajorDelHakjum { get; set; }
        public int CultureDelHakjum { get; set; }
        public int EtcDelHakjum { get; set; }
        public double HwakinScoresum { get; set; }
        public double JaechulScoresum { get; set; }
    }
}
