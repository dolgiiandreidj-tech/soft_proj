using EvertimeScraper.Models;

namespace EvertimeScraper.Scrappers
{
    // Unused legacy scraper — kept for reference only.
    public class SearchScraper
    {
        public Task<List<LectureInfo>> SearchAsync(string keyword, string condition = "name") =>
            Task.FromResult(new List<LectureInfo>());
    }
}
