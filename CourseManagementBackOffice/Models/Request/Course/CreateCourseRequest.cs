namespace CourseManagementApi.Models.Request.Course;

public class CreateCourseRequest
{
    public int Instructor { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}