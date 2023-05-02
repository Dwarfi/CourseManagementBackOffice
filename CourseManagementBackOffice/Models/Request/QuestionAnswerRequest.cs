namespace CourseManagementApi.Models.Request;

public class QuestionAnswerRequest
{
    public List<QuestionAnswerData> Answers { get; set; }
}

public record QuestionAnswerData
{
    public int QuestionId { get; set; }
    public string QuestionAnswer { get; set; }
}