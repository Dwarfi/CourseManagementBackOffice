namespace CourseManagementApi.Interfaces;

public interface IAuthService
{
    public RegistrationStatus Register(UserDto request);
    public string Login(UserDto request);
}