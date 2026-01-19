using LMS.API.Services;
using LMS.Library.DTOs;

namespace LMS.API.Services
{
    public interface IAdminAuthService
    {
        public void HandleRegister(RegisterDto dto);
        public LoginDto HandleLogin(LoginDto dto);
    }
}