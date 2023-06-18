using CourseManagementApi.Models.Request;
using CourseManagementApi.Models.Request.Question;
using CourseManagementApi.Util.Validators.Question;

namespace CourseManagementApi.Controllers;

public class QuestionController : BaseController
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        try
        {
            return Ok(_questionService.Get());
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
            var result = _questionService.GetById(id);

            return result is null ? NotFound() : Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] QuestionCreateRequest question)
    {
        try
        {
            new CreateQuestionValidator().ValidateAndThrow(question);

            _questionService.Create(question);
            
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPut]
    public IActionResult Update([FromBody] QuestionUpdateRequest question)
    {
        try
        {
            new UpdateQuestionValidator().ValidateAndThrow(question);

            _questionService.Update(question);

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
            _questionService.Delete(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPost]
    public IActionResult AnswerQuestions([FromBody] QuestionAnswerRequest request)
    {
        try
        {
            new AnswerQuestionValidator().ValidateAndThrow(request);

            return Ok(_questionService.CheckAnswers(request.Answers));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}