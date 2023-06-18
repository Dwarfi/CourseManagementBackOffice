namespace CourseManagementApi.Models;

public class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public UserRole Role { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();

    public virtual ICollection<ExamReference> ExamReferences { get; } = new List<ExamReference>();

    public virtual ICollection<Exam> Exams { get; } = new List<Exam>();

    public virtual ICollection<Lesson> Lessons { get; } = new List<Lesson>();
}
