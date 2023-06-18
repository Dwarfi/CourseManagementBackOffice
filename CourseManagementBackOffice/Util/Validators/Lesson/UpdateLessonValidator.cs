using CourseManagementApi.Models.Request.Lesson;

namespace CourseManagementApi.Util.Validators.Lesson
{
    public class UpdateLessonValidator : AbstractValidator<LessonUpdateRequest>
    {
        public UpdateLessonValidator()
        {
            RuleFor(s => s.LessonId).GreaterThan(0);
            RuleFor(s => s.Title).NotEmpty();
            RuleFor(s => s.CourseId).GreaterThan(0);
        }
    }
}
