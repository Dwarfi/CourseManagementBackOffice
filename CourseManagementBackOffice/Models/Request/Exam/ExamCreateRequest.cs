namespace CourseManagementApi.Models.Request.Exam;

public class ExamCreateRequest
{
    public int? CourseId { get; set; }
    public int? MinGrade { get; set; }
    public int? MaxGrade { get; set; }
}