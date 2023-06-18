using CourseManagementApi.Models.Request.Lesson;

namespace CourseManagementApi.Services;

public class LessonService : ILessonService
{
    private readonly CourseMgmtContext _context;

    public LessonService(CourseMgmtContext context)
    {
        _context = context;
    }

    public IEnumerable<Lesson> Get() => _context.Lessons.OrderBy(s => s.Index).AsEnumerable();

    public Lesson? GetById(int id) => _context.Lessons.SingleOrDefault(s => s.Id == id);

    public void Delete(int id)
    {
        var record = _context.Lessons.SingleOrDefault(s => s.Id == id);

        if (record is null) return;

        _context.Lessons.Remove(record);
        _context.SaveChanges();
    }

    public void Update(LessonUpdateRequest lesson)
    {
        var record = _context.Lessons.SingleOrDefault(s => s.Id == lesson.LessonId);

        if (record is null) return;

        record.Title = lesson.Title;
        record.UpdatedDate = DateTime.Now;
        record.CourseId = lesson.CourseId;
        record.Subject = lesson.Subject;
        record.Index = lesson.Index;
        record.FileUrls = string.Join("|", lesson.FileUrls);
        record.Course = _context.Courses.SingleOrDefault(s => s.Id == record.CourseId);

        _context.SaveChanges();
    }

    public void Create(LessonCreateRequest lesson)
    {
        _context.Lessons.Add(new Lesson
        {
            Title = lesson.Title,
            Course = _context.Courses.SingleOrDefault(s => s.Id == lesson.CourseId),
            Subject = lesson.Subject,
            Index = lesson.Index,
            CourseId = lesson.CourseId,
            CreatedDate = DateTime.Now,
            FileUrls = string.Join("|", lesson.FileUrls)
        });

        _context.SaveChanges();
    }
}