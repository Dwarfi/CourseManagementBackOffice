namespace CourseManagementApi.Services;

public class QuestionService : IQuestionService
{
    private readonly CourseMgmtContext _context;

    public QuestionService(CourseMgmtContext context)
    {
        _context = context;
    }

    public List<ExamQuestion> Get() => _context.ExamQuestions.ToList();

    public ExamQuestion? GetById(int id) => _context.ExamQuestions.SingleOrDefault(x => x.Id == id);

    public HttpStatusCode Delete(int id)
    {
        var record = _context.ExamQuestions.SingleOrDefault(x => x.Id == id);

        if(record is null) return HttpStatusCode.NotFound;
        
        _context.ExamQuestions.Remove(record);
        _context.SaveChanges();

        return HttpStatusCode.OK;
    }

    public HttpStatusCode Update(ExamQuestion item)
    {
        var record = _context.ExamQuestions.SingleOrDefault(s => s.Id == item.Id);

        if (record is null) return HttpStatusCode.NotFound;

        record.UpdatedDate = DateTime.UtcNow;
        record.Answer = item.Answer;
        record.Text = item.Text;
        record.Value = item.Value;

        _context.ExamQuestions.Update(record);
        _context.SaveChanges();

        return HttpStatusCode.OK;
    }

    public HttpStatusCode Create(ExamQuestion item)
    {
        _context.ExamQuestions.Add(item);
        _context.SaveChanges();

        return HttpStatusCode.Created;
    }
}