using hr_management_backend.DTOs.Auth;
using hr_management_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace hr_management_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
        {
            var result = await _authService.Login(userLogin.Email, userLogin.Password);

            if (result == null)
                return Unauthorized(new { message = "Invalid credentials" });


            return Ok(new { result });
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegister)
        {
            var result = await _authService.Register(userRegister.Name, userRegister.Email, userRegister.Password);

            if (result == null)
                return BadRequest(new { message = "Email already exists" });

            return Ok(new { result });
        }
    }
}
