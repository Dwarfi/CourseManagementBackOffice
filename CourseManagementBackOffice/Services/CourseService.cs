namespace CourseManagementApi.Services;

public class CourseService : ICourseService
{
    private readonly CourseMgmtContext _context;

    public CourseService()
    {
        _context = new CourseMgmtContext();
    }

    public void Create(Course course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();
    }

    public List<Course> Get() => _context.Courses.ToList();

    public Course? GetById(int id) => _context.Courses.SingleOrDefault(c => c.Id == id);

    public void Delete(int id)
    {
        var record = _context.Courses.SingleOrDefault(s => s.Id == id);

        if (record != null) _context.Courses.Remove(record);
        
        _context.SaveChanges();
    }

    public void Update(Course course)
    {
        var record = _context.Courses.SingleOrDefault(s => s.Id == course.Id);

        if (record == null) return;

        record.UpdatedDate = DateTime.Now;
        record.Description = course.Description;
        record.Instructor = course.Instructor;

        var lessons = _context.Lessons.ToList();
        var courseLessons = course.Lessons;

        foreach (var lesson in courseLessons)
            if (!lessons.Any(s => s.CourseId == lesson.CourseId && s.Id == lesson.Id))
                _context.Lessons.Add(lesson);

        _context.SaveChanges();
    }
}