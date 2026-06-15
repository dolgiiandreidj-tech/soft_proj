using EvertimeScraper.Models;

namespace EvertimeScraper.Scrapers
{
    // Unused legacy scraper — kept for reference only.
    public class ReviewScraper
    {
        public Task<List<ReviewInfo>> GetReviewsAsync(string lectureUrl, string? semesterFilter = null) =>
            Task.FromResult(new List<ReviewInfo>());
    }
}
