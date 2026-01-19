using LMS.API.Data;
using LMS.API.Models;
using LMS.Library.DTOs;

namespace LMS.API.Services
{
    public class StudentAuthService : IStudentAuthService
    {
        private readonly AppDbContext _context;
        public StudentAuthService(AppDbContext context)
        {
            _context=context;
        }
        public void HandleRegister(RegisterDto dto)
        {
           var user=_context.Students.Any(e=>e.Email==dto.Email);
            if (user)
            {
                throw new Exception("Email already registered...");
            }
            var student=new Student
            {
                StudentName=dto.Name,
                Email=dto.Email,
                Password=dto.Password

            };
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public LoginDto HandleLogin(LoginDto dto)
        {
            var email=dto.Email.Trim();
            var password=dto.Password.Trim();
            var user=_context.Students.FirstOrDefault(u=>u.Email.ToLower()==email && u.Password==password);
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