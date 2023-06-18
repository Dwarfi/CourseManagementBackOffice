namespace CourseManagementApi.Util.Validators.User
{
    public class UserValidator : AbstractValidator<Models.User>
    {
        public UserValidator()
        {
            RuleFor(s => s.Email).EmailAddress();
            RuleFor(s => s.Id).GreaterThan(0);
            RuleFor(s => s.Role).IsInEnum();
        }
    }
}
