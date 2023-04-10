using CourseManagementApi.Interfaces;

namespace CourseManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private CourseMgmtContext _context;
    private ICourseService _courseService;

    public CourseController(ICourseService service)
    {
        _context = new CourseMgmtContext();
        _courseService = service;
    }

    [HttpGet]
    [Route("[action]")]
    public void GetCourses()
    {
        var json = JsonConvert.SerializeObject(_courseService.GetCourseList());
    }
}