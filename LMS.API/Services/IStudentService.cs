using LMS.API.Models;
using LMS.Library.DTOs;

namespace LMS.API.Services
{
    public interface IStudentService
    {
        public List<BookDto> GetAllBooks();
        public Issue RequestBook(RequestBook dto);
         Task<List<IssueHistoryDto>> GetIssueHistory();
         public Task<bool> ReturnBook(int id);
    }

}