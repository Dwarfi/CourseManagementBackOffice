using CourseManagementApi.Models.Request;
using CourseManagementApi.Models.Service.QuestionModels;

namespace CourseManagementApi.Interfaces;

public interface IQuestionService : IBaseInterface<ExamQuestion>
{
    public ExamResult CheckAnswers(IEnumerable<QuestionAnswerData> answers);
}