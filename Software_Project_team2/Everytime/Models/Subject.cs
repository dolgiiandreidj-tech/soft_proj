namespace Everytime.Models;

public sealed class Subject
{
    public string? Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Professor { get; set; }
    public string? Type { get; set; }
    public int Credit { get; set; }
    public int Popular { get; set; }
    public string? Notice { get; set; }
    public string? LectureId { get; set; }
    public double LectureRate { get; set; }
    public List<TimePlace> TimePlaces { get; set; } = new();
}

public sealed class TimePlace
{
    public int Day { get; set; }
    public int Start { get; set; }
    public int End { get; set; }
    public string? Place { get; set; }
}
