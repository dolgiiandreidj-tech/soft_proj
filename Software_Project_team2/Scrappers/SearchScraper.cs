using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using EvertimeScraper.Models;

namespace EvertimeScraper.Scrappers
{
    public class SearchScraper
    {
        private readonly IPage _page;
        private const string SearchUrl = "https://everytime.kr/lecture/search";

        public SearchScraper(IPage page)
        {
            _page = page;
        }

        /// <summary>
        /// Searches lectures by keyword.
        /// condition: "name" for course name, "professor" for professor name.
        /// </summary>

        public async Task<List<LectureInfo>> SearchAsync(string keyword, string condition = "name")
        {
            // build the search URL directly -- no need to click filters
            var url = $"{SearchUrl}?keyword={Uri.EscapeDataString(keyword)}&condition={condition}";

            await _page.GotoAsync(url);
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var cards = await _page.QuerySelectorAllAsync("a.lecture");
            var results = new List<LectureInfo>();

            foreach (var card in cards)
            {
                var nameEl = await card.QuerySelectorAsync("div.name");
                var professorEl = await card.QuerySelectorAsync("div.professor");
                var href = await card.GetAttributeAsync("href");

                // professor can be missing in some cards -- handle null safely
                var name = nameEl != null ? (await nameEl.InnerTextAsync()).Trim() : "";
                var professor = professorEl != null ? (await professorEl.InnerTextAsync()).Trim() : "";

                results.Add(new LectureInfo(
                    Name: name,
                    Professor: professor,
                    Url: "https://everytime.kr" + href
                ));
            }
            return results;
        }
    }
}