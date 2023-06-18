using CourseManagementApi.Models.Request.Course;

namespace CourseManagementApi.Util.Validators.Course
{
    public class CreateCourseValidator : AbstractValidator<CreateCourseRequest>
    {
        public CreateCourseValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Instructor).GreaterThan(0);
        }
    }
}
