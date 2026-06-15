using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Software_Project_team2.Services
{
    public class KlasService : BrowserService
    {
        public async Task<bool> LoginAsync(string id, string password)
        {
            await InitAsync();
            page.SetDefaultTimeout(15000);

            await page.GotoAsync("https://klas.kw.ac.kr");

            await page.FillAsync("#loginId", id);
            await page.FillAsync("#loginPwd", password);
            await page.ClickAsync("button[type=submit]");

            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            if (page.Url.Contains("Frame.do"))
                return true;
            else
                return false;
        }

        private const string ProgressionPageUrl = "https://klas.kw.ac.kr/std/cps/inqire/AtnlcScreStdPage.do";

        private async Task NavigateToProgressionPageAsync()
        {
            await page.GotoAsync(ProgressionPageUrl);
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        public async Task<(int Major, int General, int Other)> GetProgressionCreditsAsync()
        {
            await NavigateToProgressionPageAsync();

            var targetTable = page.Locator("table.tablegw:has(th:has-text('신청학점'))");

            var majorLocator   = targetTable.Locator("tbody tr td").Nth(0);
            var generalLocator = targetTable.Locator("tbody tr td").Nth(1);
            var otherLocator   = targetTable.Locator("tbody tr td").Nth(2);

            string majorText   = await majorLocator.InnerTextAsync();
            string generalText = await generalLocator.InnerTextAsync();
            string otherText   = await otherLocator.InnerTextAsync();

            return (ParseCreditText(majorText), ParseCreditText(generalText), ParseCreditText(otherText));
        }

        public async Task<string> GetGpaAsync()
        {
            // Page is already on the progression URL from GetProgressionCreditsAsync;
            // only navigate if needed to avoid a redundant round-trip.
            if (!page.Url.Contains("AtnlcScreStdPage"))
                await NavigateToProgressionPageAsync();

            var targetTable = page.Locator("table.tablegw:has(th:has-text('신청학점'))");
            var tds = targetTable.Locator("tbody tr td");
            int count = await tds.CountAsync();

            if (count == 0)
                return "0.00";

            var parsedValues = new List<double>();

            for (int i = 0; i < count; i++)
            {
                var raw = (await tds.Nth(i).InnerTextAsync()) ?? "";
                var cleaned = string.Join("", raw.Split(new[] { '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)).Trim();

                if (string.IsNullOrEmpty(cleaned))
                    continue;

                // Replace comma with dot just in case, then try parse invariant
                cleaned = cleaned.Replace(',', '.');

                if (double.TryParse(cleaned, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out double val))
                {
                    parsedValues.Add(val);
                }
                else
                {
                    // Sometimes the td contains text like "26(0)" — try to extract leading numeric portion
                    var firstToken = cleaned.Split(new[] { ' ', '(' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
                    if (!string.IsNullOrEmpty(firstToken))
                    {
                        firstToken = firstToken.Replace(',', '.');
                        if (double.TryParse(firstToken, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out val))
                        {
                            parsedValues.Add(val);
                        }
                    }
                }
            }

            if (parsedValues.Count == 0)
                return "0.00";

            // The GPA we want is the last numeric value in the row (e.g., the last parsed double before the "조회" button column)
            double lastGpa = parsedValues.Last();

            // Return with two decimal places (e.g., "3.34")
            return lastGpa.ToString("F2", CultureInfo.InvariantCulture);
        }

        private int ParseCreditText(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;

            var parts = text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 0 && int.TryParse(parts[0], out int credit))
            {
                return credit;
            }

            return 0;
        }

        /// <summary>
        /// Fetches the logged-in user's display name from the KLAS top bar.
        /// </summary>
        public async Task<string> GetUserNameAsync()
        {
            // Ensure we are on the klas domain root (the top navigation is present there).
            if (!page.Url.Contains("klas.kw.ac.kr"))
            {
                await page.GotoAsync("https://klas.kw.ac.kr");
            }

            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var anchor = page.Locator("div.col-md-6.navtxt a[href*='MyInfoStdPage.do']");
            int count = await anchor.CountAsync();
            if (count == 0)
                return string.Empty;

            string text = await anchor.Nth(0).InnerTextAsync();
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            text = text.Replace("\r", "").Replace("\n", "").Trim();
            int idx = text.IndexOf('(');
            var name = idx > 0 ? text.Substring(0, idx).Trim() : text.Trim();
            return name;
        }

        /// <summary>
        /// Parses the schedule table found under the KLAS frame (Frame.do).
        /// Returns a list of lessons with day (0=Mon..5=Sat), start slot, duration (in slots), title, location, instructor, and css class token.
        /// </summary>
        public async Task<List<LessonModel>> GetTimetableAsync()
        {
            // Navigate to the frame page which contains the schedule table
            if (!page.Url.Contains("Frame.do"))
            {
                await page.GotoAsync("https://klas.kw.ac.kr/std/cmn/frame/Frame.do");
            }

            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var scheduleRoot = page.Locator("div.schedule table.scheduletb");
            int tableCount = await scheduleRoot.CountAsync();
            var result = new List<LessonModel>();
            if (tableCount == 0) return result;

            var rows = scheduleRoot.Locator("tbody tr");
            int rowCount = await rows.CountAsync();

            for (int r = 0; r < rowCount; r++)
            {
                var row = rows.Nth(r);
                var timeCell = row.Locator("td.time");
                string timeText = (await timeCell.InnerTextAsync()).Trim();
                if (!int.TryParse(timeText, out int slot)) continue;

                var cells = row.Locator("td");
                int cellCount = await cells.CountAsync();
                // first td is time, columns 1..6 correspond to weekdays
                for (int c = 1; c < cellCount; c++)
                {
                    var cell = cells.Nth(c);
                    // check if cell contains a lesson div
                    var lessonDiv = cell.Locator("div");
                    int lessonCount = await lessonDiv.CountAsync();
                    if (lessonCount == 0) continue;

                    // take first div (there should be one)
                    var div = lessonDiv.Nth(0);
                    string divClass = (await div.GetAttributeAsync("class")) ?? "";
                    // try to extract duration from class like lessontime3
                    var m = Regex.Match(divClass, @"lessontime(\d+)");
                    int duration = m.Success ? int.Parse(m.Groups[1].Value) : 1;

                    // extract inner p text
                    var p = div.Locator("p");
                    string ptext = (await p.InnerTextAsync()).Trim();
                    
                    // normalize whitespace and split title and parenthesis
                    ptext = Regex.Replace(ptext, @"\r|\n|\t", " ").Trim();
                    ptext = Regex.Replace(ptext, @"\s{2,}", " ");

                    string title = ptext;
                    string location = "";
                    string instructor = "";

                    // attempt to find trailing "(location / instructor)"
                    var parenMatch = Regex.Match(ptext, @"^(.*?)\s*\((.*?)\)$");
                    if (parenMatch.Success)
                    {
                        title = parenMatch.Groups[1].Value.Trim();
                        var inside = parenMatch.Groups[2].Value.Trim();
                        // split by '/' to location and instructor
                        var parts = inside.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(x => x.Trim()).ToArray();
                        if (parts.Length >= 1) location = parts[0];
                        if (parts.Length >= 2) instructor = parts[1];
                    }

                    // day index (c-1) where 1 => Monday, 6 => Saturday -> normalize to 0..5
                    int dayIndex = c - 1 - 1; // c starts at 1 (time column is 0), subtract 1, then -1 to get 0-based for Mon
                    // Above corrected: since 'cells' includes time cell at index 0, columns are [0=time,1=mon,2=tue,...,6=sat]
                    dayIndex = c - 1; // 0..5 mapping Monday..Saturday

                    var lesson = new LessonModel
                    {
                        Day = Math.Max(0, Math.Min(5, dayIndex)),
                        StartSlot = slot,
                        Duration = duration,
                        Title = title,
                        Location = location,
                        Instructor = instructor,
                        CssClass = divClass
                    };

                    result.Add(lesson);
                }
            }

            return result;
        }

        [Obsolete("Not implemented — use GetProgressionCreditsAsync and GetGpaAsync instead.")]
        public Task<string> GetDashboardAsync() => Task.FromResult(string.Empty);
    }

    public class LessonModel
    {
        // Day: 0=Mon,1=Tue,2=Wed,3=Thu,4=Fri,5=Sat
        public int Day { get; set; }
        public int StartSlot { get; set; }
        public int Duration { get; set; } = 1;
        public string Title { get; set; } = "";
        public string Location { get; set; } = "";
        public string Instructor { get; set; } = "";
        public string CssClass { get; set; } = "";
    }
}