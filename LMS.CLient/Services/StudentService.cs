using System.ComponentModel;
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
       public async Task<List<IssueHistoryDto>> GetIssueHistoriesAsync()
        {
            return await httpClient.GetFromJsonAsync<List<IssueHistoryDto>>("api/student/issued-book");
        }
        public async Task<bool> ReturnBook(int id)
        {
            var response= await httpClient.PutAsync($"api/student/return-book/{id}",null);
            return response.IsSuccessStatusCode;
        }
        
    }
}