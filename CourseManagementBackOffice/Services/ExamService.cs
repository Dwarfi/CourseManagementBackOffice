namespace CourseManagementApi.Services;

public class ExamService : IExamService
{
    private readonly CourseMgmtContext _context;

    public ExamService()
    {
        _context = new CourseMgmtContext();
    }

    public List<Exam> Get() => _context.Exams.ToList();

    public Exam? GetById(int id) => _context.Exams.SingleOrDefault(x => x.Id == id);

    public HttpStatusCode Update(Exam exam)
    {
        var record = _context.Exams.SingleOrDefault(s => s.Id == exam.Id);

        if (record is null) return HttpStatusCode.NotFound;

        record.UpdatedDate = DateTime.Now;
        record.MaxGrade = exam.MaxGrade;
        record.MinGrade = exam.MinGrade;
        record.CourseId = exam.CourseId;

        _context.SaveChanges();

        return HttpStatusCode.OK;
    }

    public HttpStatusCode Create(Exam item)
    {
        _context.Exams.Add(item);
        _context.SaveChanges();

        return HttpStatusCode.Created;
    }

    public HttpStatusCode Delete(int id)
    {
        var record = _context.Exams.SingleOrDefault(s => s.Id == id);

        if (record is null) return HttpStatusCode.NotFound;
        
        _context.Exams.Remove(record);
        _context.SaveChanges();

        return HttpStatusCode.OK;
    }
}