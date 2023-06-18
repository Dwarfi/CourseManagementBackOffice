using CourseManagementApi.Models.Request.Lesson;

namespace CourseManagementApi.Util.Validators.Lesson
{
    public class CreateLessonValidator : AbstractValidator<LessonCreateRequest>
    {
        public CreateLessonValidator()
        {
            RuleFor(s => s.CourseId).GreaterThan(0);
            RuleFor(s => s.Title).NotEmpty();
        }
    }
}
