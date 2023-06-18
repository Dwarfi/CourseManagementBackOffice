namespace CourseManagementApi.Models;

public class Media
{
    public int? Key { get; set; }

    public int? MediaType { get; set; }

    public int? LessonId { get; set; }

    public virtual Lesson? Lesson { get; set; }
}
