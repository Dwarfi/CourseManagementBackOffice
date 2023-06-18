namespace CourseManagementApi.Models;

public class ExamReference
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? CourseId { get; set; }

    public int? Grade { get; set; }

    public DateTime? EvalDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual User? User { get; set; }
}
