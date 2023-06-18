using CourseManagementApi.Models.Request;
using CourseManagementApi.Models.Request.Question;
using CourseManagementApi.Models.Service.QuestionModels;

namespace CourseManagementApi.Services;

public class QuestionService : IQuestionService
{
    private readonly CourseMgmtContext _context;

    public QuestionService(CourseMgmtContext context)
    {
        _context = context;
    }

    public IEnumerable<ExamQuestion> Get() => _context.ExamQuestions.AsEnumerable();

    public ExamQuestion? GetById(int id) => _context.ExamQuestions.SingleOrDefault(x => x.Id == id);

    public void Delete(int id)
    {
        var record = _context.ExamQuestions.SingleOrDefault(x => x.Id == id);

        if (record is null) return;
        
        _context.ExamQuestions.Remove(record);
        _context.SaveChanges();
    }

    public void Update(QuestionUpdateRequest question)
    {
        var record = _context.ExamQuestions.SingleOrDefault(s => s.Id == question.QuestionId);

        if (record is null) return;

        record.UpdatedDate = DateTime.Now;
        record.Answer = question.Answer;
        record.Text = question.Text;
        record.Value = question.Value;

        _context.ExamQuestions.Update(record);
        _context.SaveChanges();
    }

    public void Create(QuestionCreateRequest question)
    {
        _context.ExamQuestions.Add(new ExamQuestion
        {
            Answer = question.Answer,
            Text = question.Text,
            Value = question.Value,
            CreatedDate = DateTime.Now
        });

        _context.SaveChanges();
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

    private static double CalculateMark(IEnumerable<QuestionAnswerValue> data)
    {
        var maxMark = data.Sum(s => s.Value);
        var actualMark = data.Where(s => s.Correct).Sum(s => s.Value);

        return actualMark / maxMark * 100;
    }
}