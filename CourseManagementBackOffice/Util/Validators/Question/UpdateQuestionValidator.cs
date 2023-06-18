using CourseManagementApi.Models.Request.Question;

namespace CourseManagementApi.Util.Validators.Question
{
    public class UpdateQuestionValidator : AbstractValidator<QuestionUpdateRequest>
    {
        public UpdateQuestionValidator()
        {
            RuleFor(s => s.QuestionId).GreaterThan(0);
            RuleFor(s => s.ExamId).GreaterThan(0);
            RuleFor(s => s.Value).GreaterThan(0).LessThan(100);
            RuleFor(s => s.Answer).NotEmpty();
            RuleFor(s => s.Text).MinimumLength(10);
        }
    }
}
