namespace CourseManagementApi.Models;

public partial class Course
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int? Instructor { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<ExamReference> ExamReferences { get; } = new List<ExamReference>();

    public virtual ICollection<Exam> Exams { get; } = new List<Exam>();

    public virtual User? InstructorNavigation { get; set; }

    public virtual ICollection<Lesson> Lessons { get; } = new List<Lesson>();
}
