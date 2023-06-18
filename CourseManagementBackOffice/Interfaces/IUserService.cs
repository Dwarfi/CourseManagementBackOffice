namespace CourseManagementApi.Interfaces;

public interface IUserService : IBaseInterface<User>
{
    void Update(User user);
}