using CourseManagementApi.Models.Request;

namespace CourseManagementApi.Interfaces;

public interface IAuthService
{
    public RegistrationStatus Register(UserRequest request);
    public string Login(UserRequest request);
}