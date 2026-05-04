// Scrapers/TimetableScraper.cs
using Microsoft.Playwright;
using EvertimeScraper.Models;

namespace EvertimeScraper.Scrapers;

/// <summary>
/// Scrapes the course list from the timetable page.
/// </summary>
public class TimetableScraper
{
    private readonly IPage _page;
    private const string TimetableUrl = "https://everytime.kr/timetable";

    public TimetableScraper(IPage page)
    {
        _page = page;
    }

    /// <summary>
    /// Opens the subject list and returns all course rows.
    /// </summary>
    public async Task<List<TimetableCourse>> GetCourseListAsync()
    {
        await _page.GotoAsync(TimetableUrl);
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        // click the button to reveal the subject list div
        await _page.ClickAsync("li.button.search");

        // wait for the table to appear inside the div
        await _page.WaitForSelectorAsync("#subjects tbody tr");

        var rows = await _page.QuerySelectorAllAsync("#subjects tbody tr");
        var results = new List<TimetableCourse>();

        foreach (var row in rows)
        {
            var cells = await row.QuerySelectorAllAsync("td");
            if (cells.Count < 8) continue;

            // rating is stored in the title attribute of a.star -- already a number string
            var starLink = await row.QuerySelectorAsync("a.star");
            var ratingTitle = starLink != null
                ? await starLink.GetAttributeAsync("title")
                : "0";
            var href = starLink != null
                ? await starLink.GetAttributeAsync("href")
                : "";

            double.TryParse(ratingTitle,
                System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture,
                out double rating);

            results.Add(new TimetableCourse(
                Category: (await cells[0].InnerTextAsync()).Trim(),
                CourseCode: (await cells[1].InnerTextAsync()).Trim(),
                CourseName: (await cells[2].InnerTextAsync()).Trim(),
                Professor: (await cells[3].InnerTextAsync()).Trim(),
                Credits: (await cells[4].InnerTextAsync()).Trim(),
                Schedule: (await cells[5].InnerTextAsync()).Trim(),
                Rating: rating,
                LectureUrl: "https://everytime.kr" + href,
                EnrolledCount: (await cells[7].InnerTextAsync()).Trim(),
                Notes: (await cells[8].InnerTextAsync()).Trim()
            ));
        }

        return results;
    }
}