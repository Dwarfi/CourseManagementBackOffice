namespace CourseManagementApi.Models;

public partial class UserCourse
{
    public int? UserId { get; set; }

    public int? CourseId { get; set; }

    public int? Status { get; set; }

    public int? Lesson { get; set; }

    public virtual Course? Course { get; set; }
}
