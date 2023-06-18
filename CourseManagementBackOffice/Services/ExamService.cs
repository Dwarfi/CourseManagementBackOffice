using CourseManagementApi.Models.Request.Exam;

namespace CourseManagementApi.Services;

public class ExamService : IExamService
{
    private readonly CourseMgmtContext _context;

    public ExamService()
    {
        _context = new CourseMgmtContext();
    }

    public IEnumerable<Exam> Get() => _context.Exams.AsEnumerable();

    public Exam? GetById(int id) => _context.Exams.SingleOrDefault(x => x.Id == id);

    public void Update(Exam exam)
    {
        var record = _context.Exams.SingleOrDefault(s => s.Id == exam.Id);

        if (record is null) return;

        record.UpdatedDate = DateTime.Now;
        record.MaxGrade = exam.MaxGrade;
        record.MinGrade = exam.MinGrade;
        record.CourseId = exam.CourseId;

        _context.SaveChanges();
    }

    public void Create(ExamCreateRequest exam)
    {
        _context.Exams.Add(new Exam
        {
            Course = _context.Courses.SingleOrDefault(s => s.Id == exam.CourseId),
            CourseId = exam.CourseId,
            CreatedDate = DateTime.Now,
            MaxGrade = exam.MaxGrade,
            MinGrade = exam.MinGrade,
        });
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var record = _context.Exams.SingleOrDefault(s => s.Id == id);

        if (record is null) return;
        
        _context.Exams.Remove(record);
        _context.SaveChanges();
    }
}