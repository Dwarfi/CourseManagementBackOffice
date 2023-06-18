using CourseManagementApi.Models.Request.Course;

namespace CourseManagementApi.Interfaces;

public interface ICourseService : IBaseInterface<Course>
{
    void Create(CreateCourseRequest request);
    void Update(UpdateCourseRequest request);
}