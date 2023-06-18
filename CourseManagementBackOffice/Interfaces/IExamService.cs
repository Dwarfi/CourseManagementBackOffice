using CourseManagementApi.Models.Request.Exam;

namespace CourseManagementApi.Interfaces;

public interface IExamService : IBaseInterface<Exam>
{
    void Create(ExamCreateRequest exam);
    void Update(Exam exam);
}