using CourseManagementApi.Models.Request.Course;
using CourseManagementApi.Util.Validators.Course;

namespace CourseManagementApi.Controllers;

public class CourseController : BaseController
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
            return Ok(_courseService.Get());
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

            return result is null ? NotFound() : Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPut]
    public IActionResult Update([FromBody] UpdateCourseRequest course)
    {
        try
        {
            new UpdateCourseValidator().ValidateAndThrow(course);

            _courseService.Update(course);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateCourseRequest request)
    {
        try
        {
            new CreateCourseValidator().ValidateAndThrow(request);
            _courseService.Create(request);

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