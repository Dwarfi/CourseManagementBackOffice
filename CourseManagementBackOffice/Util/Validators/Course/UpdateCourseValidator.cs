using CourseManagementApi.Models.Request.Course;

namespace CourseManagementApi.Util.Validators.Course
{
    public class UpdateCourseValidator : AbstractValidator<UpdateCourseRequest>
    {
        public UpdateCourseValidator()
        {
            RuleFor(s => s.CourseId).GreaterThan(0);
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.Instructor).GreaterThan(0);
        }
    }
}
