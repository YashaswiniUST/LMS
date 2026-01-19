using LMS.API.Models;
using LMS.Library.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Services
{
    public interface IAdminService
    {
        Book CreateBook(BookDto dto);
        Book EditBook(BookDto book, int id);
        Task<string> DeleteBook(int bookid);
        Task<BookDto?> BookById(int id);
        Task<List<BookDto>> PendingBook();
        Task IssueBook(int bookId);
        Task RejectBook(int bookId);
        Task<List<IssueHistoryDto>> GetIssueHistory();
    }
}
