using CourseManagementApi.Models.Request.User;
using CourseManagementApi.Util.Validators.Auth;

namespace CourseManagementApi.Controllers
{

    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterRequest request)
        {
            try
            {
                new RegisterValidator().ValidateAndThrow(request);

                return _authService.Register(request) switch
                {
                    RegistrationStatus.Success => Ok(),
                    _ => BadRequest("User with this E-mail already exists")
                };
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            try
            {
                new LoginValidator().ValidateAndThrow(request);

                var token = _authService.Login(request);

                if (!string.IsNullOrEmpty(token))
                {
                    _logger.LogInformation($"User {request.Email} logged in");
                    return Ok(token);
                }

                _logger.LogInformation($"User {request.Email} does not exist");

                return BadRequest("Invalid credentials");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
