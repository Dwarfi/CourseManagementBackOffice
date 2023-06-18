namespace CourseManagementApi.Models.Request.Lesson;

public class LessonUpdateRequest : LessonCreateRequest
{
    public int LessonId { get; set; }
}