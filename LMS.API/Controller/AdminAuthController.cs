using LMS.API.Services;
using LMS.Library.Enums;
using LMS.Library.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controller
{
    [ApiController]
    [Route("api/auth/admin")]
    public class AdminAuthController:ControllerBase
    {
        private readonly IAdminAuthService authService;
        public AdminAuthController(IAdminAuthService _authService)
        {
            authService=_authService;
        }
        [HttpPost("register-admin")]
        public IActionResult HandleRegister([FromBody] RegisterDto dto)
        {
            authService.HandleRegister(dto);
            return Ok("Registration successfullyy..!");
        }
        [HttpPost("login-admin")]
        public IActionResult HandleLogin([FromBody] LoginDto dto)
        {
            var login=authService.HandleLogin(dto);
            return Ok(login);
        }
    }
}