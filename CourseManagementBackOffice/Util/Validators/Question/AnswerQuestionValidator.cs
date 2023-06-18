using CourseManagementApi.Models.Request;

namespace CourseManagementApi.Util.Validators.Question
{
    public class AnswerQuestionValidator : AbstractValidator<QuestionAnswerRequest>
    {
        public AnswerQuestionValidator()
        {
            RuleFor(s => s.Answers).ForEach(s => s.SetValidator(new QuestionAnswerDataValidator()));
        }
    }
}
