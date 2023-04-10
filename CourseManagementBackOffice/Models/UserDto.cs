namespace CourseManagementApi.Models;

public class UserDto
{
    public required string Password { get; set; }
    public required string Email { get; set; }
    public UserRole Role { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}