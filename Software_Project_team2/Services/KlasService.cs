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

        public async Task<string> GetDashboardAsync()
        {
            // Fake data for now
            return "GPA: 4.0\nCredits: 18\nSchedule: ...";
        }
    }
}
