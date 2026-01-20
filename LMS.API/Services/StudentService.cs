
using LMS.API.Data;
using LMS.API.Models;
using LMS.API.Services;
using LMS.Library.DTOs;
using LMS.Library.Enums;
using Microsoft.EntityFrameworkCore;

namespace LMS.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context)
        {
            _context=context;
        }
       public List<BookDto> GetAllBooks()
{
    return _context.Books
        .Select(b => new BookDto
{
    BookId = b.BookId,          
    BookName = b.BookName,
    Author = b.Author,
    ImageUrl = b.ImageUrl,
    Description = b.Description,
    Copies = b.Copies
})
        .ToList();
}


      
public Issue RequestBook(RequestBook dto)
{
    if (dto.BookId <= 0)
        throw new Exception("Invalid BookId");

    var book = _context.Books.FirstOrDefault(b => b.BookId == dto.BookId);
    if (book == null)
        throw new Exception("Book not found");

    var issue = new Issue
    {
        BookId = dto.BookId,
        status = LMS.Library.Enums.Status.Pending
    };

    _context.Issues.Add(issue);
    _context.SaveChanges();
    return issue;
}
public async Task<List<IssueHistoryDto>> GetIssueHistory()
{
    return await (
        from issue in _context.Issues
        join book in _context.Books
            on issue.BookId equals book.BookId
        where issue.status != Status.Pending
        
        select new IssueHistoryDto
        {
            IssueId = issue.IssueId,
            BookId = book.BookId,
            BookName = book.BookName ?? "",
            Author = book.Author ?? "",
            Status = issue.status
           
        }
    ).ToListAsync();
}
public async Task<bool> ReturnBook(int id)
{
    var issue = await _context.Issues.FindAsync(id);
    if (issue == null)
        return false;

    var book = await _context.Books.FindAsync(issue.BookId);
    if (book == null)
        return false;

    book.Copies += 1;

    _context.Issues.Remove(issue);
    await _context.SaveChangesAsync();

    return true;
}



        
    }
}