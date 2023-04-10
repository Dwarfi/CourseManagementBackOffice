namespace CourseManagementApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Produces("application/json")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService service)
    {
        _courseService = service;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        try
        {
            return Ok(JsonConvert.SerializeObject(_courseService.Get()));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet]
    public IActionResult GetById(int id)
    {
        try
        {
            var result = _courseService.GetById(id);

            return result is null ? NotFound() : Ok(JsonConvert.SerializeObject(result));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPost]
    public IActionResult Update(Course course)
    {
        try
        {
            _courseService.Update(course);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpDelete]
    public IActionResult DeleteById(int id)
    {
        try
        {
            _courseService.Delete(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}