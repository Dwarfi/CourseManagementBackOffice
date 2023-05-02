namespace CourseManagementApi.Models.Service.QuestionModels;

public class QuestionAnswerValue
{
    public QuestionAnswerValue(int id, int? value, bool correct)
    {
        Id = id;
        Value = value ?? 0;
        Correct = correct;
    }

    public int Id { get; set; }
    public int Value { get; set; }
    public bool Correct { get; set; }

}