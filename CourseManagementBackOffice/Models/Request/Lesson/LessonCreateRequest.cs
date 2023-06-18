namespace CourseManagementApi.Models.Request.Lesson;

public class LessonCreateRequest
{
    public string Title { get; set; }
    public string? Subject { get; set; }
    public int? Index { get; set; }
    public List<string> FileUrls { get; set; } = new();
    public int? CourseId { get; set; }
}