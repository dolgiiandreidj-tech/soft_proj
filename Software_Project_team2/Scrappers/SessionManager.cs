using Microsoft.Playwright;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvertimeScraper.Scrappers
{
    /// <summary>
    /// Handles login and session saving/loading.
    /// </summary>
    public class SessionManager
    {
        private const string SessionFile = "session.json";
        private const string LoginUrl = "https://everytime.kr/login";

        private readonly IBrowser _browser;

        //  A constructor runs when you do new SessionManager(...)
        //  It receives a browser from outside and stores it
        //  This pattern is called dependency injection -- instead of creating the browser inside this class, you pass it in from outside
        //  Why? The caller controls the browser lifetime.SessionManager just uses it, does not own it
        //  The underscore _browser convention signals "this is a class field, not a local variable"
        public SessionManager(IBrowser browser)
        {
            _browser = browser;
        }

        /// <summary>
        /// Logs in and saves session to file. Run once.
        /// </summary>
        public async Task SaveSessionAsync(string userId, string password)
        {
            var context = await _browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync(LoginUrl);
            await page.FillAsync("[name='id']", userId);
            await page.FillAsync("[name='password']", password);
            await page.ClickAsync("[type='submit']");
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            await context.StorageStateAsync(new BrowserContextStorageStateOptions
            {
                Path = SessionFile
            });

            Console.WriteLine("Session saved.");
            await context.CloseAsync();
        }

        /// <summary>
        /// Loads saved session from file and returns a ready context.
        /// </summary>
        public async Task<IBrowserContext> LoadSessionAsync()
        {
            return await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                StorageStatePath = SessionFile
            });
        }
    }
}