using LMS.API.Data;
using LMS.API.Models;
using LMS.API.Services;
using LMS.Library.DTOs;

namespace LMS.API.Services
{
    public class AdminAuthService : IAdminAuthService
    {
        private readonly AppDbContext _context;
        public AdminAuthService(AppDbContext context)
        {
            _context=context;
        }
        public void HandleRegister(RegisterDto dto)
        {
           var user=_context.Admins.Any(e=>e.Email.ToLower()==dto.Email.ToLower());
            if (user)
            {
                throw new Exception("Email already registered...");
            }
            var admin=new Admin
            {
                Name=dto.Name,
                Email=dto.Email,
                Password=dto.Password

            };
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }

        public LoginDto HandleLogin(LoginDto dto)
        {
            var email=dto.Email.Trim();
            var password=dto.Password.Trim();
            var user=_context.Admins.FirstOrDefault(u=>u.Email.ToLower()==email && u.Password==password);
            if(user==null)
            {
                return null;
            }
            return new LoginDto
            {
                Email=dto.Email,
                Password=dto.Password
            };
        }
    }
}