
using LMS.API.Data;
using LMS.API.Models;
using LMS.API.Services;
using LMS.Library.DTOs;
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

        
    }
}