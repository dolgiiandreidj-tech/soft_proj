namespace Everytime.Models;

public sealed class Review
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string? Semester { get; set; }
    public string? Text { get; set; }
    public double Rate { get; set; }
    public int PosVote { get; set; }
}
