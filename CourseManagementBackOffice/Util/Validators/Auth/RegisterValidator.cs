using System.Text.RegularExpressions;
using CourseManagementApi.Models.Request.User;

namespace CourseManagementApi.Util.Validators.Auth
{
    public class RegisterValidator : AbstractValidator<UserRegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(request => request.FirstName).NotEmpty();
            RuleFor(request => request.LastName).NotEmpty();
            RuleFor(request => request.Email).EmailAddress();
            RuleFor(request => request.Password).Matches(
                new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")
            );
            RuleFor(request => request.Role).IsInEnum();
        }
    }
}
