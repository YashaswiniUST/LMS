using System.Net.Http.Json;
using LMS.Library.Enums;
using LMS.Library.DTOs;

namespace LMS.CLient.Services
{
    public class StudentAuthService
    {
        private readonly HttpClient _http;

        public StudentAuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> LoginAsync(LoginDto dto)
        {
            var response = await _http.PostAsJsonAsync(
                "api/auth/student/login-student",
                dto
            );

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            var response = await _http.PostAsJsonAsync(
                "api/auth/student/register-student",
                dto
            );

            return response.IsSuccessStatusCode;
        }
    }
}
