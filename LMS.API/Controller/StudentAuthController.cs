
using LMS.API.Services;
using LMS.Library.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controller
{
    [ApiController]
    [Route("api/auth/student")]
    public class StudentAuthController : ControllerBase
    {
        private readonly IStudentAuthService _authService;

        public StudentAuthController(IStudentAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register-student")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            _authService.HandleRegister(dto);
            return Ok("Registration successful");
        }

        [HttpPost("login-student")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var result = _authService.HandleLogin(dto);
            return Ok(result);
        }
    }
}
