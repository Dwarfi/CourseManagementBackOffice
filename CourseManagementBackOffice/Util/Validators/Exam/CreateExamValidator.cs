using CourseManagementApi.Models.Request.Exam;

namespace CourseManagementApi.Util.Validators.Exam
{
    public class CreateExamValidator : AbstractValidator<ExamCreateRequest>
    {
        public CreateExamValidator()
        {
            RuleFor(s => s.CourseId).GreaterThan(0);
            RuleFor(s=>s.MinGrade).GreaterThan(0);
            RuleFor(s => s.MaxGrade).LessThanOrEqualTo(100);
        }
    }
}
