using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Project_team2.Services
{
    public class EverytimeService : BrowserService
    {
        public async Task<bool> LoginAsync(string id, string password)
        {
            await InitAsync();

            await page.GotoAsync("https://everytime.kr/login");

            await page.FillAsync("input[name='id']", id);
            await page.FillAsync("input[name='password']", password);
            await page.ClickAsync("input[type='submit']");

            try
            {
                await page.WaitForSelectorAsync("a[href='/user/logout']", new()
                {
                    Timeout = 5000
                });

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> GetLectureReviews(string keyword)
        {
            return $"Reviews for {keyword}...";
        }
    }
}
