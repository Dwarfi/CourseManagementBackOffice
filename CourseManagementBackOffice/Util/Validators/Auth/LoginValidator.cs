using CourseManagementApi.Models.Request.User;

namespace CourseManagementApi.Util.Validators.Auth
{
    public class LoginValidator : AbstractValidator<UserLoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(request => request.Email).NotEmpty();
            RuleFor(request => request.Password).NotEmpty();
        }
    }
}
