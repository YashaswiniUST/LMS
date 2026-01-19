using LMS.Library.DTOs;

namespace LMS.API.Services
{
    public interface IStudentAuthService
    {
        public void HandleRegister(RegisterDto dto);
        public LoginDto HandleLogin(LoginDto dto);
    }
}