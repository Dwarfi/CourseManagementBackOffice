using System.Net;

namespace CourseManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
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
    public IActionResult GetCourses()
    {
        var json = JsonConvert.SerializeObject(_courseService.GetCourseList());
        return Ok(json);
    }
}