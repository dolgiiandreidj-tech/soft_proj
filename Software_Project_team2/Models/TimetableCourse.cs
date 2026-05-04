// Models/TimetableCourse.cs
namespace EvertimeScraper.Models;

/// <summary>
/// Represents a single course row from the timetable subject list.
/// </summary>
public record TimetableCourse(
    string Category,       // 교필, 교선 etc.
    string CourseCode,     // e.g. 0000-1-6453-01
    string CourseName,
    string Professor,
    string Credits,
    string Schedule,
    double Rating,
    string LectureUrl,
    string EnrolledCount,
    string Notes
);