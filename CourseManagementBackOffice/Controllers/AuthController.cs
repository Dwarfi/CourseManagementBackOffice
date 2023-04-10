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
            return _authService.Register(request) switch
            {
                RegistrationStatus.Success => Ok(),
                _ => BadRequest("User with this E-mail already exists")
            };
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto request)
        {
            var token = _authService.Login(request);
            
            return !string.IsNullOrEmpty(token) ? Ok(token) : BadRequest("Invalid credentials");
        }
    }
}
