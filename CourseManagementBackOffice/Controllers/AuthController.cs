namespace CourseManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserDto request)
        {
            switch (_authService.Register(request))
            {
                case RegistrationStatus.Success:
                    return Ok();
                default:
                    return BadRequest("User with this E-mail already exists");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto request)
        {
            var token = _authService.Login(request);
            
            return !string.IsNullOrEmpty(token) ? Ok(token) : BadRequest("Invalid credentials");
        }
    }
}
