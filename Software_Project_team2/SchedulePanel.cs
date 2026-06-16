using Everytime.Api;
using Everytime.Models;
using Everytime.Sessions;
using EvertimeScraper.Models;
using Software_Project_team2.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Project_team2
{
    public partial class SchedulePanel : Form
    {
        private bool _searching;
        private int _detailRequest;
        private List<LectureInfo> _byProf = new();
        private List<LectureInfo> _byClass = new();
        private List<ReviewInfo> _lastReviews = new();

        // Everytime API client — initialised lazily on first search
        private EverytimeClient? _client;
        private HttpClient? _httpClient;
        private const int CampusId = 11;

        // KLAS API client for syllabus — reuses the saved KLAS session
        private HttpClient? _klasHttpClient;

        // Syllabus grid — built in constructor and added to panelSyllabus
        private readonly DataGridView _syllabusGrid;

        private static (int year, string semester) CurrentSemester()
        {
            var now = DateTime.Now;
            return now.Month >= 9 ? (now.Year, "2") : (now.Year, "1");
        }

        public SchedulePanel()
        {
            InitializeComponent();

            // Build syllabus DataGridView and attach it to panelSyllabus
            int gridW = panelSyllabus.Width - 42;
            int gridH = panelSyllabus.Height - 55;
            _syllabusGrid = new DataGridView
            {
                Location  = new Point(20, 52),
                Size      = new Size(gridW, gridH),
                Anchor    = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                ReadOnly  = true,
                AllowUserToAddRows     = false,
                AllowUserToDeleteRows  = false,
                AllowUserToResizeRows  = false,
                ColumnHeadersVisible   = false,   // no header row — saves ~25 px
                RowHeadersVisible      = false,
                BackgroundColor        = Color.FromArgb(252, 252, 252),
                BorderStyle            = BorderStyle.None,
                GridColor              = Color.FromArgb(230, 232, 238),
                Font                   = new Font("Segoe UI", 9F),
                AutoSizeColumnsMode    = DataGridViewAutoSizeColumnsMode.None,
                SelectionMode          = DataGridViewSelectionMode.FullRowSelect,
            };
            _syllabusGrid.DefaultCellStyle.BackColor          = Color.FromArgb(252, 252, 252);
            _syllabusGrid.DefaultCellStyle.ForeColor          = Color.FromArgb(30, 35, 45);
            _syllabusGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 218, 240);
            _syllabusGrid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 35, 45);
            _syllabusGrid.DefaultCellStyle.Padding            = new Padding(2, 0, 2, 0);

            _syllabusGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Width = 38,
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    ForeColor = Color.FromArgb(130, 80, 180),
                    Font      = new Font("Segoe UI", 8.5F, FontStyle.Bold)
                }
            });
            _syllabusGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Width = gridW - 38 - 2
            });
            _syllabusGrid.RowTemplate.Height = 18;   // compact — 15 rows ≈ 270 px

            panelSyllabus.Controls.Add(_syllabusGrid);

            btnGo.Click += async (_, _) => await RunSearchAsync();
            txtSearch.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    await RunSearchAsync();
                }
            };
            lstByProf.SelectedIndexChanged += async (_, _) => await OnSelectionChanged(lstByProf, _byProf);
            lstByClass.SelectedIndexChanged += async (_, _) => await OnSelectionChanged(lstByClass, _byClass);
        }

        private async Task RunSearchAsync()
        {
            if (_searching) return;
            var keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                lblStatus.Text = "키워드를 입력하세요";
                return;
            }

            _searching = true;
            SetControlsEnabled(false);
            lblStatus.Text = "검색 중...";
            lstByProf.Items.Clear();
            lstByClass.Items.Clear();
            ClearDetail();

            try
            {
                if (!await EnsureClientAsync()) return;

                lblStatus.Text = "검색 중...";
                var (year, sem) = CurrentSemester();

                var byNameTask = _client!.GetAllSubjectsAsync(CampusId, year, sem, keyword, "name");
                var byProfTask = _client!.GetAllSubjectsAsync(CampusId, year, sem, keyword, "professor");
                await Task.WhenAll(byNameTask, byProfTask);

                _byClass = byNameTask.Result
                    .Where(s => s.Name?.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false)
                    .Select(s => new LectureInfo(s.Name ?? "", s.Professor ?? "", "", int.TryParse(s.LectureId, out var id) ? id : 0, s.Code ?? "", s.Id ?? ""))
                    .ToList();

                _byProf = byProfTask.Result
                    .Where(s => s.Professor?.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false)
                    .Select(s => new LectureInfo(s.Name ?? "", s.Professor ?? "", "", int.TryParse(s.LectureId, out var id) ? id : 0, s.Code ?? "", s.Id ?? ""))
                    .ToList();

                foreach (var l in _byProf)
                    lstByProf.Items.Add($"{l.Professor} — {l.Name}");
                foreach (var l in _byClass)
                    lstByClass.Items.Add($"{l.Name} — {l.Professor}");

                lblStatus.Text = $"강의명 {_byClass.Count}건 / 교수명 {_byProf.Count}건";
            }
            catch (SessionExpiredException)
            {
                ResetSession();
                lblStatus.Text = "세션 만료 — 쿠키를 다시 입력하세요";
                using var dlg = new LoginForm();
                if (dlg.ShowDialog() == DialogResult.OK)
                    await RunSearchAsync();
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"오류: {ex.Message}";
            }
            finally
            {
                SetControlsEnabled(true);
                _searching = false;
            }
        }

        private void ResetSession()
        {
            _client = null;
            _httpClient?.Dispose();
            _httpClient = null;
        }

        private async Task<bool> EnsureClientAsync()
        {
            if (_client != null) return true;

            var sessionPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "everytime.session.json");
            var store = new SessionStore(sessionPath);
            var session = await store.LoadAsync();
            if (session == null)
            {
                using var loginForm = new LoginForm();
                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    lblStatus.Text = "세션 없음";
                    return false;
                }
                session = await store.LoadAsync();
                if (session == null) return false;
            }

            _httpClient = HttpClientFactory.FromSession(session);
            _httpClient.DefaultRequestHeaders.Add("Referer", "https://everytime.kr/");
            _httpClient.DefaultRequestHeaders.Add("Origin", "https://everytime.kr");
            _client = new EverytimeClient(_httpClient);
            return true;
        }

        private void SetControlsEnabled(bool enabled)
        {
            btnGo.Enabled = enabled;
            txtSearch.Enabled = enabled;
            rbProf.Enabled = enabled;
            rbClass.Enabled = enabled;
        }

        private async Task OnSelectionChanged(ListBox list, List<LectureInfo> source)
        {
            var idx = list.SelectedIndex;
            if (idx < 0 || idx >= source.Count) return;
            await LoadDetailAsync(source[idx]);
        }

        private async Task LoadDetailAsync(LectureInfo info)
        {
            int myRequest = Interlocked.Increment(ref _detailRequest);

            lblDetailName.Text = info.Name;
            lblDetailProfessor.Text = $"교수: {(string.IsNullOrEmpty(info.Professor) ? "-" : info.Professor)}";
            lblDetailCode.Text = $"학수번호: {(string.IsNullOrEmpty(info.Code) ? "-" : info.Code)}";
            lblDetailRating.Text = "★ -";
            lblDetailReviews.Text = "강의평 -";
            lblDetailStatus.Text = "불러오는 중...";

            try
            {
                if (info.LectureId == 0)
                {
                    lblDetailStatus.Text = "강의평 없음";
                    return;
                }

                var apiReviews = await _client!.GetAllReviewsAsync(info.LectureId);

                if (myRequest != Volatile.Read(ref _detailRequest)) return;

                var reviews = apiReviews
                    .Select(r => new ReviewInfo(r.Rate, $"{r.Year}년 {r.Semester}학기", r.Text ?? ""))
                    .ToList();

                double avgRating = reviews.Count > 0 ? Math.Round(reviews.Average(r => r.Rating), 1) : 0;

                lblDetailRating.Text = reviews.Count > 0 ? $"★ {avgRating:F1}" : "★ -";
                lblDetailReviews.Text = $"강의평 {reviews.Count}개";
                lblDetailStatus.Text = "";

                _lastReviews = reviews;
                ShowReviews(reviews);

                // Load syllabus in parallel (independent from reviews)
                _ = LoadSyllabusAsync(info, myRequest);
            }
            catch (SessionExpiredException)
            {
                if (myRequest != Volatile.Read(ref _detailRequest)) return;
                ResetSession();
                lblDetailStatus.Text = "세션 만료 — 쿠키를 다시 입력하세요";
                using var dlg = new LoginForm();
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                if (myRequest != Volatile.Read(ref _detailRequest)) return;
                lblDetailStatus.Text = $"오류: {ex.Message}";
            }
        }

        private async Task LoadSyllabusAsync(LectureInfo info, int requestToken)
        {
            lblSyllabusHeader.Text = "강의계획서 불러오는 중...";
            _syllabusGrid.Rows.Clear();

            try
            {
                if (!await EnsureKlasClientAsync())
                {
                    lblSyllabusHeader.Text = "강의계획서 — KLAS 세션 없음";
                    return;
                }

                var (year, sem) = CurrentSemester();
                var selectSubj = await FindKlasSubjectIdAsync(info.Name, info.Professor, year, sem);

                if (requestToken != Volatile.Read(ref _detailRequest)) return;

                if (string.IsNullOrEmpty(selectSubj))
                {
                    lblSyllabusHeader.Text = "강의계획서 — KLAS에서 강의를 찾을 수 없음";
                    return;
                }

                var json  = await PostSyllabusAsync(selectSubj, year, sem);
                var weeks = ParseSyllabus(json);

                if (requestToken != Volatile.Read(ref _detailRequest)) return;

                foreach (var (week, topic) in weeks)
                    _syllabusGrid.Rows.Add($"W{week}", topic);

                lblSyllabusHeader.Text = weeks.Count > 0
                    ? $"강의계획서 ({weeks.Count}주)"
                    : "강의계획서 — 내용 없음";
            }
            catch (Exception ex)
            {
                if (requestToken != Volatile.Read(ref _detailRequest)) return;
                lblSyllabusHeader.Text = $"강의계획서 오류: {ex.Message}";
            }
        }

        private async Task<string?> FindKlasSubjectIdAsync(string subjectName, string professor, int year, string semester)
        {
            // Pass 1: search by subject name, match professor locally.
            var byName = await SearchKlasLectrePlanAsync(subjectName, "", year, semester);
            var id = PickBestKlasSubjectId(byName, subjectName, professor);
            if (!string.IsNullOrEmpty(id)) return id;

            // Pass 2: name search found nothing usable — retry by professor.
            if (!string.IsNullOrEmpty(professor))
            {
                var byProf = await SearchKlasLectrePlanAsync("", professor, year, semester);
                id = PickBestKlasSubjectId(byProf, subjectName, professor);
                if (!string.IsNullOrEmpty(id)) return id;
            }

            return null;
        }

        private async Task<string> SearchKlasLectrePlanAsync(string selectText, string selectProfsr, int year, string semester)
        {
            const string listUrl = "https://klas.kw.ac.kr/std/cps/atnlc/LectrePlanStdList.do";

            var body = JsonSerializer.Serialize(new
            {
                list          = Array.Empty<object>(),
                selectSubj    = "",
                selectYear    = year.ToString(),
                selecthakgi   = semester,
                isSearch      = "Y",
                randomNum     = new Random().Next(1000, 9999),
                numText       = "",
                selectYearList = new[] { new { value = year, text = $"{year}년" } },
                selectRadio   = "all",
                selectText    = selectText,
                selectProfsr  = selectProfsr,
                cmmnGamok     = "",
                selectCmGamokList  = Array.Empty<object>(),
                selecthakgwa  = "",
                selectHwaGwakList  = Array.Empty<object>(),
                selectMajor   = "",
                selectMajorList    = Array.Empty<object>(),
                stopFlag      = "N",
            });

            using var req = new HttpRequestMessage(HttpMethod.Post, listUrl);
            req.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
            req.Headers.TryAddWithoutValidation("Referer", "https://klas.kw.ac.kr/std/cps/atnlc/LectrePlanStdPage.do");
            req.Content = new StringContent(body, Encoding.UTF8, "application/json");

            var resp = await _klasHttpClient!.SendAsync(req);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadAsStringAsync();
        }

        // The LectrePlanStdList.do response has NO selectSubj field — the id is
        // built from component fields:
        //   "U" + thisYear + hakgi + openGwamokNo + openMajorCode + bunbanNo + openGrade
        // e.g. "U"+"2026"+"1"+"4969"+"0000"+"01"+"2" = "U2026149690000012".
        private static string? PickBestKlasSubjectId(string json, string subjectName, string professor)
        {
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            // Response is a bare array; also tolerate an object wrapping a "list".
            IEnumerable<JsonElement> items;
            if (root.ValueKind == JsonValueKind.Array)
                items = root.EnumerateArray();
            else if (root.TryGetProperty("list", out var listEl) && listEl.ValueKind == JsonValueKind.Array)
                items = listEl.EnumerateArray();
            else
                return null;

            var rows = items.ToList();
            if (rows.Count == 0) return null;

            string wantName = Normalize(subjectName);
            string wantProf = Normalize(professor);

            string? bestByName = null;
            string? bestByProf = null;
            string? firstAny   = null;

            foreach (var row in rows)
            {
                var id = BuildSelectSubj(row);
                if (string.IsNullOrEmpty(id)) continue;

                firstAny ??= id;

                string kname  = Normalize(Field(row, "gwamokKname"));
                string member = Normalize(Field(row, "memberName"));

                bool nameOk = wantName.Length > 0 && kname.Length > 0
                           && (kname.Contains(wantName) || wantName.Contains(kname));
                bool profOk = wantProf.Length > 0 && member.Length > 0
                           && (member.Contains(wantProf) || wantProf.Contains(member));

                if (nameOk && profOk) return id;   // exact match — stop immediately
                if (nameOk) bestByName ??= id;
                if (profOk) bestByProf ??= id;
            }

            // name-only → professor-only → first row with a valid id
            return bestByName ?? bestByProf ?? firstAny;
        }

        // Concatenate the KLAS subject id from a list row's component fields.
        private static string BuildSelectSubj(JsonElement row)
        {
            string thisYear     = Field(row, "thisYear");
            string hakgi        = Field(row, "hakgi");
            string openGwamokNo = Field(row, "openGwamokNo");
            string openMajorCd  = Field(row, "openMajorCode");
            string bunbanNo     = Field(row, "bunbanNo");
            string openGrade    = Field(row, "openGrade");

            if (thisYear.Length == 0 || hakgi.Length == 0 || openGwamokNo.Length == 0
                || openMajorCd.Length == 0 || bunbanNo.Length == 0 || openGrade.Length == 0)
                return "";

            return "U" + thisYear + hakgi + openGwamokNo + openMajorCd + bunbanNo + openGrade;
        }

        // Read a row field as a string whether KLAS returns it as a JSON string or number.
        private static string Field(JsonElement row, string key)
        {
            if (!row.TryGetProperty(key, out var v)) return "";
            return v.ValueKind switch
            {
                JsonValueKind.String => v.GetString() ?? "",
                JsonValueKind.Number => v.ToString(),
                _ => ""
            };
        }

        private static string Normalize(string s) =>
            string.IsNullOrEmpty(s) ? "" : s.Replace(" ", "").Trim();

        private async Task<bool> EnsureKlasClientAsync()
        {
            if (_klasHttpClient != null) return true;
            var store = new SessionStore(Form1.SessionPath);
            var session = await store.LoadAsync();
            if (session == null) return false;
            _klasHttpClient = KlasHttpClientFactory.FromSession(session);
            return true;
        }

        private async Task<string> PostSyllabusAsync(string selectSubj, int year, string semester)
        {
            const string url = "https://klas.kw.ac.kr/std/cps/atnlc/LectrePlanData.do";
            var referer = $"https://klas.kw.ac.kr/std/cps/atnlc/popup/LectrePlanStdView.do?selectSubj={selectSubj}";

            var body = BuildSyllabusBody(selectSubj, year, semester);
            using var req = new HttpRequestMessage(HttpMethod.Post, url);
            req.Headers.TryAddWithoutValidation("Accept", "application/json, text/plain, */*");
            req.Headers.TryAddWithoutValidation("Referer", referer);
            req.Content = new StringContent(body, Encoding.UTF8, "application/json");

            var resp = await _klasHttpClient!.SendAsync(req);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadAsStringAsync();
        }

        private static string BuildSyllabusBody(string selectSubj, int year, string semester) =>
            JsonSerializer.Serialize(new
            {
                info = "", selectSubj, selectGrcode = "N000003",
                selectYear = year.ToString(), selecthakgi = semester, selectRadio = "",
                selectText = "", selectProfsr = "", gwamokKname = "",
                openCode = "", incLc = "popup",
                times = (string?)null, teamName = (string?)null,
                teamEmail = (string?)null, astntName = (string?)null,
                astntEmail = (string?)null,
                perCheck = 0, gitaDetail = "",
                engOptCheck = "", frnOptCheck = "", foreignOpt = "",
                recOptCheck = "", engOpt = "", beforData = "",
                LrnRsltList = "", experimentPlan = "",
                experimentPlanList = Array.Empty<object>(),
                getScore1 = "", getScore2 = "", getScore3 = "",
                exmPlan = "", target = "", analysis = "",
                manufacture = "", test = "", evaluation = "",
                composition = "", compositionEtc = "",
                economic = "", environment = "", social = "",
                ethics = "", esthetic = "", safety = "",
                production = "", durability = "", standard = "",
                actualEtc = "",
                pa1 = "", pa2 = "", pa3 = "", pa4 = "",
                pa5 = "", pa6 = "", pa7 = "",
                attendBiyul = "", middleBiyul = "", lastBiyul = "",
                reportBiyul = "", learnBiyul = "", quizBiyul = "", gitaBiyul = "",
                attendExpect = "", middleExpect = "", lastExpect = "",
                reportExpect = "", learnExpect = "", quizExpect = "", gitaExpect = "",
                tblOpt = "", pblOpt = "", seminarOpt = "", onlineOpt = "",
                typeSmall = "", typeWork = "", typeTeam = "", typeFusion = "",
                typeElearn = "", typeBlended = "", typeForeigner = "",
                typeExperiment = "", typeJibjung = "", typeFlipped = "",
                lectureOpt = "", discussionOpt = "", reportOpt = "",
                testOpt = "", practiceOpt = "", computerOpt = "",
                projectOpt = "", vtrOpt = "",
                face100Opt = "", faceliveOpt = "", live100Opt = "",
                facerecOpt = "", recliveOpt = "", rec100Opt = "",
                faceliverecOpt = "",
                recVideo = "", recReport = "", recQuiz = "",
                recQna = "", recEtc = "", recEtcDetail = "",
                jointLectureOpt = "", fieldTripOpt = "",
                internshipOpt = "", invitationSeminarOpt = "",
                outsideEvaluationOpt = "", etcOpt = "", evaluationOpt = "",
                weekLecture = Array.Empty<object>(),
                weekSubs    = Array.Empty<object>(),
                weekBigo    = Array.Empty<object>(),
                stopFlag = ""
            });

        private static List<(int Week, string Topic)> ParseSyllabus(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            // KLAS wraps the response in a JSON array — unwrap first element
            var obj = root.ValueKind == JsonValueKind.Array
                ? root.EnumerateArray().FirstOrDefault()
                : root;

            if (obj.ValueKind != JsonValueKind.Object)
                return new();

            var result = new List<(int, string)>();
            for (int i = 1; i <= 15; i++)
            {
                if (obj.TryGetProperty($"week{i}Lecture", out var val))
                {
                    var text = val.GetString()?.Trim() ?? "";
                    if (!string.IsNullOrEmpty(text))
                        result.Add((i, text));
                }
            }
            return result;
        }

        private void ShowReviews(List<ReviewInfo> reviews)
        {
            var recent = reviews.Where(r => IsRecent(r.Semester)).ToList();

            flowReviews.SuspendLayout();
            flowReviews.Controls.Clear();

            int cardWidth = flowReviews.ClientSize.Width - 4;

            foreach (var r in recent)
            {
                var card = new Panel
                {
                    BackColor = Color.FromArgb(38, 41, 52),
                    Padding = new Padding(12),
                    Margin = new Padding(0, 0, 0, 8),
                    Width = cardWidth
                };

                var lblMeta = new Label
                {
                    AutoSize = true,
                    BackColor = Color.Transparent,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(255, 200, 90),
                    Location = new Point(12, 10),
                    Text = $"{r.Semester}   ★ {r.Rating:F1}"
                };

                var lblText = new Label
                {
                    AutoSize = true,
                    BackColor = Color.Transparent,
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.FromArgb(220, 222, 230),
                    Location = new Point(12, 34),
                    MaximumSize = new Size(cardWidth - 24, 0),
                    Text = r.Text
                };

                card.Controls.Add(lblMeta);
                card.Controls.Add(lblText);
                card.Height = lblText.Bottom + 12;

                flowReviews.Controls.Add(card);
            }

            flowReviews.ResumeLayout();

            lblReviewsHeader.Text = recent.Count > 0
                ? $"최근 강의평 ({recent.Count}개, 최근 2년)"
                : "최근 강의평 — 최근 2년 내 강의평 없음";
        }

        private static bool IsRecent(string semester)
        {
            int currentYear = DateTime.Now.Year;
            var match = Regex.Match(semester, @"(\d{4})년");
            if (!match.Success) return false;
            int reviewYear = int.Parse(match.Groups[1].Value);
            return reviewYear >= currentYear - 1;
        }

        private void ClearDetail()
        {
            Interlocked.Increment(ref _detailRequest);
            lblDetailName.Text = "";
            lblDetailProfessor.Text = "";
            lblDetailCode.Text = "";
            lblDetailRating.Text = "";
            lblDetailReviews.Text = "";
            lblDetailStatus.Text = "";
            flowReviews.Controls.Clear();
            lblReviewsHeader.Text = "최근 강의평";
            _lastReviews.Clear();
            _syllabusGrid.Rows.Clear();
            lblSyllabusHeader.Text = "강의계획서";
        }
    }
}
