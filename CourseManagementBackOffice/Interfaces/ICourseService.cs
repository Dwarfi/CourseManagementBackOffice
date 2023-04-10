namespace CourseManagementApi.Interfaces;

public interface ICourseService
{
    public bool Create(Course course);
    public List<Course> GetCourseList();
}