namespace CourseManagementApi.Models.Request.Question;

public class QuestionUpdateRequest : QuestionCreateRequest
{
    public int QuestionId { get; set; }
}