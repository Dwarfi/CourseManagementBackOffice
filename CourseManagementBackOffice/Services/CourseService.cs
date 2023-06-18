using CourseManagementApi.Models.Request.Course;

namespace CourseManagementApi.Services;

public class CourseService : ICourseService
{
    private readonly CourseMgmtContext _context;

    public CourseService(CourseMgmtContext context)
    {
        _context = context;
    }

    public void Create(CreateCourseRequest request)
    {
        _context.Courses.Add(new Course
        {
            CreatedDate = DateTime.Now,
            Description = request.Description,
            Instructor = request.Instructor,
            Name = request.Name,
            UpdatedDate = DateTime.Now
        });

        _context.SaveChanges();
    }

    public IEnumerable<Course> Get() => _context.Courses.AsEnumerable();

    public Course? GetById(int id) => _context.Courses.SingleOrDefault(c => c.Id == id);

    public void Delete(int id)
    {
        var record = _context.Courses.SingleOrDefault(s => s.Id == id);

        if (record is null) return;
            
        _context.Courses.Remove(record);
        _context.SaveChanges();
    }

    public void Update(UpdateCourseRequest course)
    {
        var record = _context.Courses.SingleOrDefault(s => s.Id == course.CourseId);

        if (record is null) return;

        record.UpdatedDate = DateTime.UtcNow;
        record.Description = course.Description;
        record.Instructor = course.Instructor;
        record.Name = course.Name;

        if (course.Lessons.Any())
        {
            var lessons = _context.Lessons.ToList();
            var courseLessons = course.Lessons;

            foreach (var lesson in courseLessons.Where(lesson => !lessons.Any(s => s.CourseId == lesson.CourseId && s.Id == lesson.Id)))
                _context.Lessons.Add(lesson);
        }

        _context.Courses.Update(record);
        _context.SaveChanges();
    }
}