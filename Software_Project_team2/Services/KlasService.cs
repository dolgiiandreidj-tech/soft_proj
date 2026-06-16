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
        private const string SungjukInfoUrl     = BaseUrl + "/std/cps/inqire/AtnlcScreSungjukInfo.do";
        private const string HakjukInfoUrl      = BaseUrl + "/std/cps/inqire/AtnlcScreHakjukInfo.do";
        private const string ProgramGubunUrl    = BaseUrl + "/std/cps/inqire/AtnlcScreProgramGubun.do";
        private const string ProgressionReferer = BaseUrl + "/std/cps/inqire/AtnlcScreStdPage.do";
        private const string TaskStdListUrl     = BaseUrl + "/std/lis/evltn/TaskStdList.do";
        private const string TaskStdPageReferer = BaseUrl + "/std/lis/evltn/TaskStdPage.do";
        // Material board master ID is a system-wide constant shared across all courses
        private const string MaterialMasterId   = "6972896bfe72408eb72926780e85d041";
        private static readonly string MaterialListUrl     = $"{BaseUrl}/std/lis/sport/{MaterialMasterId}/BoardStdList.do";
        private static readonly string MaterialListReferer = $"{BaseUrl}/std/lis/sport/{MaterialMasterId}/BoardListStdPage.do";

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
        // All taken course names across every semester  (AtnlcScreSungjukInfo.do)
        // ──────────────────────────────────────────────────────────────────

        public async Task<HashSet<string>> GetAllTakenCourseNamesAsync()
        {
            var root = await PostApiJsonAsync(SungjukInfoUrl);
            var result = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            if (root.ValueKind != JsonValueKind.Array) return result;

            foreach (var semester in root.EnumerateArray())
            {
                if (!semester.TryGetProperty("sungjukList", out var list)) continue;
                foreach (var course in list.EnumerateArray())
                {
                    if (course.TryGetProperty("gwamokKname", out var name))
                    {
                        var n = name.GetString();
                        if (!string.IsNullOrEmpty(n))
                            result.Add(n.Replace(" ", ""));
                    }
                }
            }

            return result;
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
                        Subj             = Str("subj"),
                        Bunban           = Str("bunban"),
                        Yearhakgi        = Str("yearhakgi"),
                        SubjLabel        = Str("subjLabel"),
                    });
                }
            }

            return result;
        }

        // ──────────────────────────────────────────────────────────────────
        // All pending assignments across enrolled subjects  (TaskStdList.do)
        // ──────────────────────────────────────────────────────────────────

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            var courseList = await GetCourseListAsync();
            var subjects = courseList.Subjects;

            var subjListPayload = subjects
                .Select(s => new { value = s.Subj, label = s.SubjLabel, name = s.SubjNm })
                .ToArray();

            var all = new List<TaskItem>();

            foreach (var course in subjects)
            {
                var payload = new
                {
                    selectYearhakgi = course.Yearhakgi,
                    selectSubj      = course.Subj,
                    selectChangeYn  = "Y",
                    subjNm          = course.SubjLabel,
                    yearhakgi       = new
                    {
                        value    = course.Yearhakgi,
                        label    = YearhakgiLabel(course.Yearhakgi),
                        subjList = subjListPayload
                    },
                    subj = new { value = course.Subj, label = course.SubjLabel, name = course.SubjNm },
                    currentPage = (object?)null
                };

                var json = System.Text.Json.JsonSerializer.Serialize(payload);

                using var req = new HttpRequestMessage(HttpMethod.Post, TaskStdListUrl);
                req.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
                req.Headers.Referrer = new Uri(TaskStdPageReferer);
                req.Content = new StringContent(json, Encoding.UTF8, "application/json");

                var resp = await _client.SendAsync(req);
                if (!resp.IsSuccessStatusCode) continue;

                var body = await resp.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(body);
                var root = doc.RootElement;

                IEnumerable<JsonElement> items = root.ValueKind == JsonValueKind.Array
                    ? root.EnumerateArray()
                    : Enumerable.Empty<JsonElement>();

                foreach (var item in items)
                {
                    string Str(string key) => item.TryGetProperty(key, out var v) ? v.GetString() ?? "" : "";

                    DateTime? ParseDt(string key)
                    {
                        var s = Str(key);
                        return string.IsNullOrEmpty(s) ? null
                            : DateTime.TryParse(s, out var d) ? d : null;
                    }

                    var expire    = ParseDt("expiredate");
                    var reexpire  = ParseDt("reexpiredate");
                    var effective = reexpire ?? expire;

                    if (effective == null || effective < DateTime.Now) continue;

                    all.Add(new TaskItem
                    {
                        SubjNm      = course.SubjNm,
                        Title       = Str("title"),
                        ExpireDate  = expire,
                        ReExpireDate = reexpire,
                        SubmitYn    = Str("submityn"),
                    });
                }
            }

            return all;
        }

        // ──────────────────────────────────────────────────────────────────
        // All lecture materials across enrolled subjects  (BoardStdList.do)
        // ──────────────────────────────────────────────────────────────────

        public async Task<List<MaterialItem>> GetAllMaterialsAsync()
        {
            var courseList = await GetCourseListAsync();
            var subjects = courseList.Subjects;

            var subjListPayload = subjects
                .Select(s => new { value = s.Subj, label = s.SubjLabel, name = s.SubjNm })
                .ToArray();

            var all = new List<MaterialItem>();

            foreach (var course in subjects)
            {
                var payload = new
                {
                    selectYearhakgi = course.Yearhakgi,
                    selectSubj      = course.Subj,
                    selectChangeYn  = "Y",
                    subjNm          = course.SubjLabel,
                    yearhakgi       = new
                    {
                        value    = course.Yearhakgi,
                        label    = YearhakgiLabel(course.Yearhakgi),
                        subjList = subjListPayload
                    },
                    subj = new { value = course.Subj, label = course.SubjLabel, name = course.SubjNm },
                    currentPage = (object?)null
                };

                var json = JsonSerializer.Serialize(payload);

                using var req = new HttpRequestMessage(HttpMethod.Post, MaterialListUrl);
                req.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
                req.Headers.Referrer = new Uri(MaterialListReferer);
                req.Content = new StringContent(json, Encoding.UTF8, "application/json");

                var resp = await _client.SendAsync(req);
                if (!resp.IsSuccessStatusCode) continue;

                var body = await resp.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(body);
                var root = doc.RootElement;

                if (!root.TryGetProperty("list", out var list)) continue;

                foreach (var item in list.EnumerateArray())
                {
                    string Str(string key) => item.TryGetProperty(key, out var v) ? v.GetString() ?? "" : "";

                    DateTime.TryParse(Str("registDt"), out var dt);

                    all.Add(new MaterialItem
                    {
                        SubjNm   = course.SubjNm,
                        Title    = System.Net.WebUtility.HtmlDecode(Str("title")),
                        UserNm   = Str("userNm"),
                        RegistDt = dt,
                        FileCnt  = item.TryGetProperty("fileCnt", out var fc) && fc.ValueKind == JsonValueKind.Number
                                   ? fc.GetInt32() : 0,
                    });
                }
            }

            // Sort newest first
            all.Sort((a, b) => b.RegistDt.CompareTo(a.RegistDt));
            return all;
        }

        private static string YearhakgiLabel(string value)
        {
            var parts = value.Split(',');
            return parts.Length == 2 ? $"{parts[0]}년도 {parts[1]}학기" : value;
        }

        // ──────────────────────────────────────────────────────────────────
        // Subject notice list  (StdHome.do → subjNotiList)
        // ──────────────────────────────────────────────────────────────────

        public async Task<List<SubjNotiItem>> GetSubjNotiListAsync()
        {
            using var req = new HttpRequestMessage(HttpMethod.Post, StdHomeUrl);
            req.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
            req.Headers.Referrer = new Uri(FrameUrl);
            req.Content = new StringContent("{\"searchYearhakgi\":null}", Encoding.UTF8, "application/json");

            var resp = await _client.SendAsync(req);
            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync();

            var result = new List<SubjNotiItem>();
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            if (!root.TryGetProperty("subjNotiList", out var list)) return result;

            foreach (var item in list.EnumerateArray())
            {
                string Str(string key) => item.TryGetProperty(key, out var v) ? v.GetString() ?? "" : "";
                int GetInt(string key) => item.TryGetProperty(key, out var v) && v.ValueKind == JsonValueKind.Number ? v.GetInt32() : 0;

                DateTime.TryParse(Str("registDt"), out var dt);

                result.Add(new SubjNotiItem
                {
                    Type      = GetInt("type"),
                    TypeNm    = Str("typeNm"),
                    SubjNm    = Str("subjNm"),
                    Title     = Str("title"),
                    RegistDt  = dt,
                    Param     = Str("param"),
                    Subj      = Str("subj"),
                    Bunban    = Str("bunban"),
                    Yearhakgi = Str("yearhakgi"),
                });
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
        public string Subj { get; set; } = "";
        public string Bunban { get; set; } = "";
        public string Yearhakgi { get; set; } = "";
        public string SubjLabel { get; set; } = "";
    }

    public class TaskItem
    {
        public string SubjNm { get; set; } = "";
        public string Title { get; set; } = "";
        public DateTime? ExpireDate { get; set; }
        public DateTime? ReExpireDate { get; set; }
        public string SubmitYn { get; set; } = "N";
    }

    public class MaterialItem
    {
        public string SubjNm { get; set; } = "";
        public string Title { get; set; } = "";
        public string UserNm { get; set; } = "";
        public DateTime RegistDt { get; set; }
        public int FileCnt { get; set; }
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

    public class SubjNotiItem
    {
        public int Type { get; set; }
        public string TypeNm { get; set; } = "";
        public string SubjNm { get; set; } = "";
        public string Title { get; set; } = "";
        public DateTime RegistDt { get; set; }
        public string Param { get; set; } = "";
        public string Subj { get; set; } = "";
        public string Bunban { get; set; } = "";
        public string Yearhakgi { get; set; } = "";
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
