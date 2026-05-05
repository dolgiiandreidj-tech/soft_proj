namespace EvertimeScraper.Models;

/// <summary>
/// Groups a lecture together with its reviews.
/// </summary>
public record LectureWithReviews(
    string Name,
    string Professor,
    string Url,
    List<ReviewInfo> Reviews
);