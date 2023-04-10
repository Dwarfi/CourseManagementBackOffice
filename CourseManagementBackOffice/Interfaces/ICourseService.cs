namespace CourseManagementApi.Interfaces;

public interface ICourseService
{
    public void Create(Course course);
    public List<Course> Get();
    public void Delete(int id);
    public void Update(Course course);
    public Course? GetById(int id);
}