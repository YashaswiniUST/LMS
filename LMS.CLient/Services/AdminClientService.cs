using System.Net.Http.Json;
using LMS.Library.DTOs;

namespace LMS.CLient.Services
{
    public class AdminClientService
    {
        private readonly HttpClient httpClient;

        public AdminClientService(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public async Task<BookDto> GetBookById(int id)
        {
            var response = await httpClient.GetAsync($"api/admin/bookByid/{id}");

            if (!response.IsSuccessStatusCode)
            {
              
                return new BookDto();
            }

            return await response.Content.ReadFromJsonAsync<BookDto>()
                   ?? new BookDto();
        }

        public async Task<BookDto> EditBookAsync(BookDto dto, int id)
        {
            var response = await httpClient.PutAsJsonAsync(
                $"api/admin/edit/{id}",
                dto
            );

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<BookDto>()
                   ?? dto;
        }

        public async Task<HttpResponseMessage> DeleteBookAsync(int id)
        {
            return await httpClient.DeleteAsync(
                $"api/admin/delete/{id}"
            );

           
        }
        public async Task AddBookAsync(BookDto book)
        {
            var response=await httpClient.PostAsJsonAsync("api/admin/add",book);
            response.EnsureSuccessStatusCode();
        }
        public async Task<List<BookDto>> GetPendingBooksAsync()
        {
            return await httpClient.GetFromJsonAsync<List<BookDto>>(
                "api/admin/pending-books"
            ) ?? new List<BookDto>();
        }

        public async Task IssueBookAsync(int bookId)
        {
            var response = await httpClient.PutAsync(
                $"api/admin/issue/{bookId}", null
            );
            response.EnsureSuccessStatusCode();
        }

        public async Task RejectBookAsync(int bookId)
        {
            var response = await httpClient.PutAsync(
                $"api/admin/reject/{bookId}", null
            );
            response.EnsureSuccessStatusCode();
        }
         public async Task<List<IssueHistoryDto>> GetIssueHistoryAsync()
         {
             return await httpClient.GetFromJsonAsync<List<IssueHistoryDto>>("api/admin/issue-history");
    }
    }
    }

