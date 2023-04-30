namespace CourseManagementApi.Services;

public class CourseService : ICourseService
{
    private readonly CourseMgmtContext _context;

    public CourseService(CourseMgmtContext context)
    {
        _context =  context;
    }

    public HttpStatusCode Create(Course item)
    {
        _context.Courses.Add(item);
        _context.SaveChanges();

        return HttpStatusCode.Created;
    }

    public List<Course> Get() => _context.Courses.ToList();

    public Course? GetById(int id) => _context.Courses.SingleOrDefault(c => c.Id == id);

    public HttpStatusCode Delete(int id)
    {
        var record = _context.Courses.SingleOrDefault(s => s.Id == id);

        if (record is null) return HttpStatusCode.NotFound;
            
        _context.Courses.Remove(record);
        _context.SaveChanges();

        return HttpStatusCode.OK;
    }

    public HttpStatusCode Update(Course course)
    {
        var record = _context.Courses.SingleOrDefault(s => s.Id == course.Id);

        if (record is null) return HttpStatusCode.NotFound;

        record.UpdatedDate = DateTime.UtcNow;
        record.Description = course.Description;
        record.Instructor = course.Instructor;

        var lessons = _context.Lessons.ToList();
        var courseLessons = course.Lessons;

        foreach (var lesson in courseLessons)
            if (!lessons.Any(s => s.CourseId == lesson.CourseId && s.Id == lesson.Id)) _context.Lessons.Add(lesson);

        _context.Courses.Update(record);
        _context.SaveChanges();

        return HttpStatusCode.OK;
    }
}