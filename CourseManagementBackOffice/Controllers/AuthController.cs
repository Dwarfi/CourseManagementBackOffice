namespace CourseManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {

        }
    }
}
