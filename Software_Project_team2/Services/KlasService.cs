using Microsoft.Playwright;
using System;
using System.Collections.Generic;
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

        private int ParseCreditText(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;

            // Split by newline to separate the main credit from the parenthesized part
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