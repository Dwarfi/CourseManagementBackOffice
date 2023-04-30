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
            return Ok(JsonConvert.SerializeObject(_examService.Get()));
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
            return Ok(JsonConvert.SerializeObject(_examService.GetById(id)));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPost]
    public IActionResult Create(Exam exam)
    {
        try
        {
            return Ok(JsonConvert.SerializeObject(_examService.Create(exam)));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPost]
    public IActionResult Update(Exam exam)
    {
        try
        {
            return Ok(JsonConvert.SerializeObject(_examService.Update(exam)));
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
            return Ok(JsonConvert.SerializeObject(_examService.Delete(id)));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}