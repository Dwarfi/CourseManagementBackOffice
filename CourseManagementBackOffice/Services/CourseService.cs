namespace CourseManagementApi.Services;

public class CourseService : ICourseService
{
    private readonly CourseMgmtContext _context;

    public CourseService()
    {
        _context = new CourseMgmtContext();
    }
    public bool Create(Course course)
    {
        _context.Courses.Add(course);
        
        return true;
    }

    public List<Course> GetCourseList() => _context.Courses.ToList();
}