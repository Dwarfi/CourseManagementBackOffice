namespace CourseManagementApi.Services;

public class LessonService : ILessonService
{
    private readonly CourseMgmtContext _context;

    public LessonService(CourseMgmtContext context)
    {
        _context = context;
    }

    public List<Lesson> Get() => _context.Lessons.ToList();

    public Lesson? GetById(int id) => _context.Lessons.SingleOrDefault(s => s.Id == id);

    public HttpStatusCode Delete(int id)
    {
        var record = _context.Lessons.SingleOrDefault(s => s.Id == id);

        if (record is null) return HttpStatusCode.NotFound;

        _context.Lessons.Remove(record);
        _context.SaveChanges();

        return HttpStatusCode.OK;
    }

    public HttpStatusCode Update(Lesson item)
    {
        var record = _context.Lessons.SingleOrDefault(s => s.Id == item.Id);

        if (record is null) return HttpStatusCode.NotFound;

        record.UpdatedDate = DateTime.UtcNow;
        record.CourseId = item.CourseId;
        record.Subject = item.Subject;
        record.Index = item.Index;
        
        _context.SaveChanges();

        return HttpStatusCode.OK;
    }

    public HttpStatusCode Create(Lesson item)
    {
        _context.Lessons.Add(item);
        _context.SaveChanges();

        return HttpStatusCode.Created;
    }
}