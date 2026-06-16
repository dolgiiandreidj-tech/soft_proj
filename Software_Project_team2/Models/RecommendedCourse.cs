namespace Software_Project_team2.Models;

public record RecommendedCourse(
    string Code,
    string Name,
    string Professor,
    int Credits,
    double Rating,
    string YearSemester
);
