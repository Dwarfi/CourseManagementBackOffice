using CourseManagementApi.Models.Request.Lesson;

namespace CourseManagementApi.Interfaces;

public interface ILessonService : IBaseInterface<Lesson>
{
    void Create(LessonCreateRequest lesson);
    void Update(LessonUpdateRequest lesson);
}