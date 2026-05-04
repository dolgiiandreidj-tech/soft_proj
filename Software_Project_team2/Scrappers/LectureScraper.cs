using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using EvertimeScraper.Models;

namespace EvertimeScraper.Scrappers
{
    /// <summary>
    /// Scrapes the 내 강의 list from the lecture page.
    /// </summary>
    public class LectureScraper
    {
        private readonly IPage _page;
        private const string LecturePageUrl = "https://everytime.kr/lecture";

        public LectureScraper(IPage page)
        {
            _page = page;
        }

        /// <summary>
        /// Returns all lectures from the 내 강의 section.
        /// </summary>

        public async Task<List<LectureInfo>> GetMyLecturesAsync()
        {
            await _page.GotoAsync(LecturePageUrl);
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var items = await _page.QuerySelectorAllAsync(".mylecture .lecture");
            var results = new List<LectureInfo>();

            foreach (var item in items)
            {
                var name = await item.QuerySelectorAsync("p.lecturename");
                var professor = await item.QuerySelectorAsync("p.professor");
                var link = await item.QuerySelectorAsync("a.toucharea");

                var href = await link.GetAttributeAsync("href");

                results.Add(new LectureInfo(
                    Name: await name.InnerTextAsync(),
                    Professor: await professor.InnerTextAsync(),
                    Url: "https://everytime.kr" + href
                ));
            }
            return results;
        }
    }
}