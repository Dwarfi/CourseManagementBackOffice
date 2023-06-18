using CourseManagementApi.Models.Request.Lesson;
using CourseManagementApi.Util.Validators.Lesson;

namespace CourseManagementApi.Controllers;

public class LessonController : BaseController
{
    private readonly ILessonService _lessonService;

    public LessonController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        try
        {
            return Ok(_lessonService.Get());
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
            var result = _lessonService.GetById(id);

            return result is null ? NotFound() : Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] LessonCreateRequest lesson)
    {
        try
        {
            new CreateLessonValidator().ValidateAndThrow(lesson);

            _lessonService.Create(lesson);
            
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPut]
    public IActionResult Update([FromBody] LessonUpdateRequest lesson)
    {
        try
        {
            new UpdateLessonValidator().ValidateAndThrow(lesson);

            _lessonService.Update(lesson);

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
            _lessonService.Delete(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}