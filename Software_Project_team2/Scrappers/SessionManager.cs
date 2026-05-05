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

            await page.GotoAsync(LoginUrl, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });

            // wait until the login form actually renders (everytime sometimes shows a splash/redirect first)
            var idLocator = page.Locator("input[name='id']");
            await idLocator.WaitForAsync(new LocatorWaitForOptions { Timeout = 60000 });

            await idLocator.FillAsync(userId);
            await page.Locator("input[name='password']").FillAsync(password);

            // submit + wait for the redirect chain (account.everytime.kr -> everytime.kr) to settle
            await Task.WhenAll(
                page.WaitForURLAsync(u => !u.Contains("/login"), new PageWaitForURLOptions { Timeout = 30000 }),
                page.Locator("[type='submit']").ClickAsync()
            );
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            // make sure cookies for the main everytime.kr domain are actually set before saving
            await page.GotoAsync("https://everytime.kr/", new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            // sanity check: if we are still on a login page, the credentials were rejected
            if (page.Url.Contains("/login"))
                throw new Exception("로그인 실패: 아이디 또는 비밀번호가 올바르지 않습니다.");

            await context.StorageStateAsync(new BrowserContextStorageStateOptions
            {
                Path = SessionFile
            });

            Console.WriteLine("Session saved.");
            await context.CloseAsync();
        }

        /// <summary>
        /// Loads saved session from file and returns a ready context.
        /// Overrides user-agent so headless Chromium isn't fingerprinted as a bot.
        /// </summary>
        public async Task<IBrowserContext> LoadSessionAsync()
        {
            var context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                StorageStatePath = SessionFile,
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36",
                ViewportSize = new ViewportSize { Width = 1280, Height = 800 },
                Locale = "ko-KR"
            });

            // hide webdriver flag before any page script runs
            await context.AddInitScriptAsync(@"Object.defineProperty(navigator, 'webdriver', { get: () => undefined });");

            return context;
        }
    }
}