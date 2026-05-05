using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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

        // Add this method to fetch and parse the progression credits
        public async Task<(int Major, int General, int Other)> GetProgressionCreditsAsync()
        {
            // Navigate to the progression page if needed before trying to parse
            await page.GotoAsync("https://klas.kw.ac.kr/std/cps/inqire/AtnlcScreStdPage.do");
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            // CHANGED HERE: Use a more specific locator to find the table that actually contains the text "신청학점"
            var targetTable = page.Locator("table.tablegw:has(th:has-text('신청학점'))");

            // Locate the first 3 <td> elements inside that specific table
            var majorLocator = targetTable.Locator("tbody tr td").Nth(0);
            var generalLocator = targetTable.Locator("tbody tr td").Nth(1);
            var otherLocator = targetTable.Locator("tbody tr td").Nth(2);

            string majorText = await majorLocator.InnerTextAsync();
            string generalText = await generalLocator.InnerTextAsync();
            string otherText = await otherLocator.InnerTextAsync();

            int major = ParseCreditText(majorText);
            int general = ParseCreditText(generalText);
            int other = ParseCreditText(otherText);

            return (major, general, other);
        }

        // Improved: fetch the GPA by scanning TDs for the last parsable numeric value and return with two decimals
        public async Task<string> GetGpaAsync()
        {
            await page.GotoAsync("https://klas.kw.ac.kr/std/cps/inqire/AtnlcScreStdPage.do");
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

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

        public async Task<string> GetDashboardAsync()
        {
            // Fake data for now
            return "GPA: 4.0\nCredits: 18\nSchedule: ...";
        }
    }
}