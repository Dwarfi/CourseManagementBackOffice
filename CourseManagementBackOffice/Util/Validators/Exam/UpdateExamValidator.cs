namespace CourseManagementApi.Util.Validators.Exam
{
    public class UpdateExamValidator : AbstractValidator<Models.Exam>
    {
        public UpdateExamValidator()
        {
            RuleFor(s => s.Id).GreaterThan(0);
            RuleFor(s => s.CourseId).GreaterThan(0);
            RuleFor(s=>s.MinGrade).GreaterThan(0);
            RuleFor(s => s.MaxGrade).LessThanOrEqualTo(100);
        }
    }
}
