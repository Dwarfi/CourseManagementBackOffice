using CourseManagementApi.Models.Request.User;

namespace CourseManagementApi.Interfaces;

public interface IAuthService
{
    public RegistrationStatus Register(UserRegisterRequest registerRequest);
    public string Login(UserLoginRequest registerRequest);
}