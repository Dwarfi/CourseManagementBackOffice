using CourseManagementApi.Models.Request;

namespace CourseManagementApi.Util.Validators.Question
{
    public class QuestionAnswerDataValidator : AbstractValidator<QuestionAnswerData>
    {
        public QuestionAnswerDataValidator()
        {
            RuleFor(s => s.QuestionId).GreaterThan(0);
            RuleFor(s => s.QuestionAnswer).NotEmpty();
        }
    }
}
