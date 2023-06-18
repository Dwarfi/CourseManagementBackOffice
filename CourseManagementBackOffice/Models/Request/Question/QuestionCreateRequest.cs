namespace CourseManagementApi.Models.Request.Question;

public class QuestionCreateRequest
{
    public int ExamId { get; set; }
    public string? Text { get; set; }
    public int Value { get; set; }
    public string? Answer { get; set; }
}