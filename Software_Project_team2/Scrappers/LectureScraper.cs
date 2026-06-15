using EvertimeScraper.Models;

namespace EvertimeScraper.Scrappers
{
    // Unused legacy scraper — kept for reference only.
    public class LectureScraper
    {
        public Task<List<LectureInfo>> GetMyLecturesAsync() =>
            Task.FromResult(new List<LectureInfo>());
    }
}
