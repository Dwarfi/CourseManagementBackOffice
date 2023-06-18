namespace CourseManagementApi.Models.Request.Course;

public class UpdateCourseRequest : CreateCourseRequest
{
    public int CourseId { get; set; }
    public List<Models.Lesson> Lessons { get; set; }
}