namespace CourseManagementApi.Models.Request.User;

public class UserRegisterRequest : UserLoginRequest
{
    public UserRole Role { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}