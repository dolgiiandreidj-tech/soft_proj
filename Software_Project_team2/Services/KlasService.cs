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

        [Obsolete("Not implemented — use GetProgressionCreditsAsync and GetGpaAsync instead.")]
        public Task<string> GetDashboardAsync() => Task.FromResult(string.Empty);
    }
}