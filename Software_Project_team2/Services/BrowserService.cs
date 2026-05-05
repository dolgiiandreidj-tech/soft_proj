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
        public static BrowserService? Instance { get; private set; }

        protected IBrowser browser = null!;
        protected IBrowserContext context = null!;
        protected IPage page = null!;

        public async Task InitAsync()
        {
            var playwright = await Playwright.CreateAsync();

            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();
            Instance = this;
        }

        public async Task<IPage> NewPageAsync() => await context.NewPageAsync();
    }
}
