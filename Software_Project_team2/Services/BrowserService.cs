using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Software_Project_team2.Services
{
    public class BrowserService
    {
        protected IBrowser browser;
        protected IBrowserContext context;
        protected IPage page;

        public async Task InitAsync()
        {
            var playwright = await Playwright.CreateAsync();

            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();
        }
    }
}
