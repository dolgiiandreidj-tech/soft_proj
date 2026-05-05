using Microsoft.Playwright;
using EvertimeScraper.Models;

namespace EvertimeScraper.Scrapers;

/// <summary>
/// Scrapes reviews for a given lecture URL.
/// </summary>
public class ReviewScraper
{
    private readonly IPage _page;

    public ReviewScraper(IPage page)
    {
        _page = page;
    }

    /// <summary>
    /// Returns reviews from a lecture page.
    /// Optionally filter by semester e.g. "25년 1학기".
    /// </summary>
    public async Task<List<ReviewInfo>> GetReviewsAsync(string lectureUrl, string? semesterFilter = null)
    {
        // navigate directly to the full reviews tab instead of the default page
        await _page.GotoAsync(lectureUrl + "?tab=article");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        // scroll until no new reviews load
        int previousCount = 0;
        while (true)
        {
            // count currently loaded reviews
            var current = await _page.QuerySelectorAllAsync("div.article");

            // stop if count did not change since last scroll -- all reviews loaded
            if (current.Count == previousCount) break;

            previousCount = current.Count;

            // scroll the articles container instead of window
            await _page.EvaluateAsync("document.querySelector('div.articles').scrollTop += 10000");

            // wait for new content to load
            await Task.Delay(1500);
        }

        // now scrape all loaded reviews
        var articles = await _page.QuerySelectorAllAsync("div.article");
        var results = new List<ReviewInfo>();

        foreach (var article in articles)
        {
            var rateEl = await article.QuerySelectorAsync("span.on");
            var text = await article.QuerySelectorAsync("div.text");

            // call ParseRating to get the numeric value
            var rating = rateEl != null
                ? ParseRating(await rateEl.GetAttributeAsync("style"))
                : 0.0;

            // extract semester from span.semester instead of the whole div.info
            var semesterSpan = await article.QuerySelectorAsync("span.semester");
            var semester = semesterSpan != null
                ? (await semesterSpan.InnerTextAsync()).Trim()
                : "unknown";

            // skip this review if it does not match the filter
            if (semesterFilter != null && !semester.Contains(semesterFilter))
                continue;

            results.Add(new ReviewInfo(
                Rating: rating,
                Semester: semester,
                Text: await text.InnerTextAsync()
            ));
        }

        return results;
    }

    /// <summary>
    /// Extracts numeric rating from style string.
    /// Input:  "width: 86.6%"
    /// Output: 4.33
    /// </summary>
    private static double ParseRating(string? style)
    {
        if (string.IsNullOrEmpty(style)) return 0.0;

        // remove "width:", "%", and ";" to get the raw number
        var cleaned = style.Replace("width:", "").Replace("%", "").Replace(";", "").Trim();

        if (!double.TryParse(cleaned, System.Globalization.NumberStyles.Float,
            System.Globalization.CultureInfo.InvariantCulture, out double width))
            return 0.0;

        return Math.Round(width / 100.0 * 5.0, 2);
    }
}