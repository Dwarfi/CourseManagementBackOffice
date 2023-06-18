namespace CourseManagementApi.Models;

public class QuestionAnswer
{
    public int Id { get; set; }

    public string? AnswerValue { get; set; }

    public bool? CorrectAnswer { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public int? CreatedBy { get; set; }

    public int? QuestionId { get; set; }

    public virtual ExamQuestion? Question { get; set; }
}
