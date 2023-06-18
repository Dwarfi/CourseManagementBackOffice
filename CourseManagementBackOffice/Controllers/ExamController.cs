using CourseManagementApi.Models.Request.Exam;
using CourseManagementApi.Util.Validators.Exam;

namespace CourseManagementApi.Controllers;

public class ExamController : BaseController
{
    private readonly IExamService _examService;

    public ExamController(IExamService examService)
    {
        _examService = examService;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        try
        {
            return Ok(_examService.Get());
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
            return Ok(_examService.GetById(id));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] ExamCreateRequest exam)
    {
        try
        {
            new CreateExamValidator().ValidateAndThrow(exam);

            _examService.Create(exam);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPut]
    public IActionResult Update([FromBody] Exam exam)
    {
        try
        {
            new UpdateExamValidator().ValidateAndThrow(exam);

            _examService.Update(exam);

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
            _examService.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}