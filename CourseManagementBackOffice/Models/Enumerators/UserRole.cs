using System.ComponentModel;

namespace CourseManagementApi.Models.Enumerators;

public enum UserRole
{
    [Description("Admin")]
    Admin,
    [Description("Student")]
    Student
}