using CourseManagementApi.Models.Request;
using CourseManagementApi.Models.Service.QuestionModels;

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

    public ExamResult CheckAnswers(IEnumerable<QuestionAnswerData> answers)
    {
        var questions = _context.ExamQuestions
            .Where(question => answers.Select(s => s.QuestionId)
                .Contains(question.Id))
            .Select(s => new { s.Id, s.Answer, s.Value, s.Text }).ToList();

        var correctAnswers = questions
            .Where(question =>
                answers
                    .Single(s => s.QuestionId == question.Id).QuestionAnswer == question.Answer)
            .ToList();

        var answerWithValues = new List<QuestionAnswerValue>();

        answerWithValues.AddRange(correctAnswers.Select(s => new QuestionAnswerValue(s.Id, s.Value, true)));
        answerWithValues.AddRange(questions.ExceptBy(correctAnswers.Select(s => s.Id), s => s.Id)
            .Select(s => new QuestionAnswerValue(s.Id, s.Value, false)));

        return new ExamResult(CalculateMark(answerWithValues), answerWithValues);
    }

    private double CalculateMark(List<QuestionAnswerValue> data)
    {
        var maxMark = data.Sum(s => s.Value);
        var actualMark = data.Where(s => s.Correct).Sum(s => s.Value);

        return (actualMark / maxMark) * 100;
    }
}