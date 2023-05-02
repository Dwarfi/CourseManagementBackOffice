namespace CourseManagementApi.Models.Service.QuestionModels;

public class ExamResult
{
    public ExamResult(double mark, IEnumerable<QuestionAnswerValue> answers)
    {
        Mark = mark;
        Answers = answers.Select(s => new { s.Id, s.Correct }).ToDictionary(s => s.Id, s => s.Correct);
    }

    public double Mark { get; set; }
    public Dictionary<int, bool> Answers { get; set; }
}