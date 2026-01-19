using System.Net.Http.Json;
using LMS.Library.Enums;
using LMS.Library.DTOs;

namespace LMS.CLient.Services
{
    public class AdminAuthService
    {
        private readonly HttpClient _http;

        public AdminAuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> LoginAsync(LoginDto dto)
        {
            var response = await _http.PostAsJsonAsync(
                "api/auth/admin/login-admin",
                dto
            );

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            var response = await _http.PostAsJsonAsync(
                "api/auth/admin/register-admin",
                dto
            );

            return response.IsSuccessStatusCode;
        }
    }
}
