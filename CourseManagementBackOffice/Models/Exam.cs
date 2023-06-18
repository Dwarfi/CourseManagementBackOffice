namespace CourseManagementApi.Models;

public class Exam
{
    public int Id { get; set; }
    public int? CourseId { get; set; }

    public int? MinGrade { get; set; }

    public int? MaxGrade { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public int? CreatedBy { get; set; }

    public virtual Course? Course { get; set; }

    public virtual User? UpdatedByNavigation { get; set; }
}
