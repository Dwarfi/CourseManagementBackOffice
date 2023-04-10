namespace CourseManagementApi.Models;

public partial class QuestionAnswer
{
    public int Id { get; set; }

    public string? AnswerValue { get; set; }

    public bool? RightAnswer { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public int? CreatedBy { get; set; }

    public int? QuestionId { get; set; }

    public virtual ExamQuestion? Question { get; set; }
}
