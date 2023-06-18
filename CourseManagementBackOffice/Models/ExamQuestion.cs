namespace CourseManagementApi.Models;

public class ExamQuestion
{
    public int Id { get; set; }

    public int? ExamId { get; set; }

    public string? Text { get; set; }

    public int? Value { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public int? CreatedBy { get; set; }

    public string? Answer { get; set; }

    public virtual ICollection<QuestionAnswer> QuestionAnswers { get; } = new List<QuestionAnswer>();
}
