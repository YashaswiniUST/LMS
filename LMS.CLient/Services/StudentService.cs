using System.Net.Http.Json;
using LMS.CLient.Pages;
using LMS.Library.DTOs;

namespace LMS.CLient.Services
{
    public class StudentService
    {
        private readonly HttpClient httpClient;
        public StudentService(HttpClient _httpClient)
        {
            httpClient=_httpClient;
        }
        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            return await httpClient.GetFromJsonAsync<List<BookDto>>("api/student/all-books")??new List<BookDto>();
        }
        public async Task RequestBookAsync(RequestBook dto)
        {
            var response=await httpClient.PostAsJsonAsync("api/student/request-book",dto);
            response.EnsureSuccessStatusCode();
        }
      

        
    }
}