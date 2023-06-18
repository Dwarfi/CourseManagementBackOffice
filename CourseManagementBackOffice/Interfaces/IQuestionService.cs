using CourseManagementApi.Models.Request;
using CourseManagementApi.Models.Request.Question;
using CourseManagementApi.Models.Service.QuestionModels;

namespace CourseManagementApi.Interfaces;

public interface IQuestionService : IBaseInterface<ExamQuestion>
{
    ExamResult CheckAnswers(IEnumerable<QuestionAnswerData> answers);
    void Update(QuestionUpdateRequest question);
    void Create (QuestionCreateRequest question);
}