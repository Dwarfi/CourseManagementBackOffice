using CourseManagementApi.Util.Validators.User;

namespace CourseManagementApi.Controllers;

public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        try
        {
            return Ok(_userService.Get());
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
            return Ok(_userService.GetById(id));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPut]
    public IActionResult Update([FromBody] User user)
    {
        try
        {
            new UserValidator().ValidateAndThrow(user);

            _userService.Update(user);

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
            _userService.Delete(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}