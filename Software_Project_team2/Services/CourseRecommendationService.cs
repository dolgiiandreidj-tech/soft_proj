using Everytime.Api;
using Everytime.Sessions;
using Software_Project_team2.Models;

namespace Software_Project_team2.Services;

public class CourseRecommendationService
{
    // Kwangwoon University campus ID on Everytime — same constant used by SchedulePanel
    private const int KwangwoonCampusId = 11;

    private static readonly (string YearSem, string Name, int Credits)[] Curriculum =
    [
        ("1-1", "공학설계입문", 3),
        ("1-1", "C프로그래밍", 3),
        ("1-2", "컴퓨터개론", 3),
        ("1-2", "고급C프로그래밍및설계", 3),
        ("2-1", "리눅스활용실습", 2),
        ("2-1", "디지털논리", 3),
        ("2-1", "고급프로그래밍", 3),
        ("2-1", "웹프로그래밍", 3),
        ("2-2", "시스템소프트웨어실습", 2),
        ("2-2", "자료구조", 3),
        ("2-2", "객체지향프로그래밍", 3),
        ("2-2", "시스템소프트웨어", 3),
        ("3-1", "응용소프트웨어실습", 3),
        ("3-1", "운영체제", 3),
        ("3-1", "데이터베이스", 3),
        ("3-1", "컴퓨터구조", 3),
        ("3-1", "데이터통신", 3),
        ("3-1", "휴먼컴퓨터인터페이스", 3),
        ("3-1", "알고리즘", 3),
        ("3-2", "프로그래밍언어론", 3),
        ("3-2", "임베디드운영체제", 3),
        ("3-2", "인공지능", 3),
        ("3-2", "빅데이터처리및응용", 3),
        ("3-2", "심화전공실습1", 3),
        ("3-2", "컴퓨터그래픽스", 3),
        ("3-2", "컴퓨터네트워크", 3),
        ("3-2", "소프트웨어설계및구조", 3),
        ("3-2", "디지털영상처리", 3),
        ("4-1", "컴파일러", 3),
        ("4-1", "산학연계캡스톤설계1", 3),
        ("4-1", "심화전공실습2", 2),
        ("4-1", "컴퓨터애니메이션", 3),
        ("4-1", "네트워크보안", 3),
        ("4-1", "무선네트워크", 3),
        ("4-1", "소프트웨어공학", 3),
        ("4-2", "산학연계캡스톤설계2", 3),
        ("4-2", "최신정보보안이론", 3),
        ("4-2", "차세대네트워크응용", 3),
        ("4-2", "가상현실", 3),
        ("4-2", "게임설계", 3),
    ];

    private readonly KlasService _klasService;
    private readonly EverytimeClient _etClient;

    public CourseRecommendationService(KlasService klasService, Session etSession)
    {
        _klasService = klasService;

        // Build the Everytime HTTP client with the same Referer/Origin headers SchedulePanel uses
        var httpClient = HttpClientFactory.FromSession(etSession);
        httpClient.DefaultRequestHeaders.Add("Referer", "https://everytime.kr/");
        httpClient.DefaultRequestHeaders.Add("Origin", "https://everytime.kr");
        _etClient = new EverytimeClient(httpClient);
    }

    public async Task<List<RecommendedCourse>> GetRecommendationsAsync()
    {
        // Get every course the student has ever taken from KLAS (all semesters)
        HashSet<string> takenNames;
        try
        {
            takenNames = await _klasService.GetAllTakenCourseNamesAsync();
        }
        catch
        {
            takenNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        // Determine study year from enrollment year in student number (Hakbun: YYYYXXXXXX)
        int studyYear = 3; // safe default
        try
        {
            var hakjuk = await _klasService.GetHakjukInfoAsync();
            if (hakjuk.Hakbun.Length >= 4 && int.TryParse(hakjuk.Hakbun[..4], out var enrollYear))
                studyYear = Math.Clamp(DateTime.Now.Year - enrollYear + 1, 1, 4);
        }
        catch { }

        // Filter curriculum: not yet taken, year ≤ current study year
        var eligible = Curriculum
            .Where(c =>
            {
                int year = int.Parse(c.YearSem.Split('-')[0]);
                return year <= studyYear && !takenNames.Contains(c.Name.Replace(" ", ""));
            })
            .ToList();

        int currentYear = DateTime.Now.Year;
        string semester = DateTime.Now.Month <= 6 ? "1" : "2";

        // Search Everytime in parallel for each eligible course — same approach as SchedulePanel
        var tasks = eligible.Select(async c =>
        {
            try
            {
                var subjects = await _etClient.GetAllSubjectsAsync(
                    KwangwoonCampusId, currentYear, semester, c.Name, "name");

                // Pick the highest-rated result whose name actually matches
                var best = subjects
                    .Where(s => !string.IsNullOrEmpty(s.Name) &&
                                (s.Name.Contains(c.Name, StringComparison.OrdinalIgnoreCase) ||
                                 c.Name.Contains(s.Name, StringComparison.OrdinalIgnoreCase)))
                    .OrderByDescending(s => s.LectureRate)
                    .FirstOrDefault();

                if (best != null)
                    return new RecommendedCourse(
                        Code: best.Code ?? "",
                        Name: best.Name!,
                        Professor: best.Professor ?? "",
                        Credits: c.Credits,
                        Rating: best.LectureRate,
                        YearSemester: c.YearSem);
            }
            catch { }

            return new RecommendedCourse("", c.Name, "", c.Credits, 0.0, c.YearSem);
        });

        var results = await Task.WhenAll(tasks);
        return [.. results.OrderByDescending(r => r.Rating)];
    }
}
