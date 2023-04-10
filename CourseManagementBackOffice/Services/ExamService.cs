namespace CourseManagementApi.Services;

public class ExamService : IExamService
{
    private readonly CourseMgmtContext _context;

    public ExamService()
    {
        _context = new CourseMgmtContext();
    }

    public List<Exam> GetList() => _context.Exams.ToList();
    
    public Exam? GetById(int id) => _context.Exams.SingleOrDefault(x => x.Id == id);

    public void Update(Exam exam)
    {

    }
}