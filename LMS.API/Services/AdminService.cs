using LMS.API.Data;
using LMS.API.Models;
using LMS.Library.DTOs;
using LMS.Library.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.API.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _context;
        public AdminService(AppDbContext context)
        {
            _context=context;
        }

        public Book CreateBook(BookDto dto)
        {
           var book=new Book
           {
            BookId=dto.BookId,
               BookName=dto.BookName,
               ImageUrl=dto.ImageUrl,
               Author=dto.Author,
               Description=dto.Description,
               Copies=dto.Copies
           };
           _context.Books.Add(book);
           _context.SaveChanges();
           return book;
        }


public async Task<string> DeleteBook(int bookid)
{
    var book = _context.Books.FirstOrDefault(e => e.BookId == bookid);

    if (book == null)
        return "NOT FOUND";

    bool hasIssues = _context.Issues.Any(i => i.BookId == bookid);
    if (hasIssues)
        return "ISSUED";

    _context.Books.Remove(book);
   await _context.SaveChangesAsync();

    return "DELETED";
}


        public Book EditBook(BookDto dto,int id)
        {
            var book=_context.Books.Find(id);
               
                book.BookName=dto.BookName;
                book.Author=dto.Author;
                book.Description=dto.Description;
                book.ImageUrl=dto.ImageUrl;
                book.Copies=dto.Copies;
                
            _context.SaveChanges();
            return book;
        }
[HttpPut("issue")]

public async Task<BookDto?> BookById(int id)
{
    return await _context.Books
        .Where(b => b.BookId == id)
        .Select(b => new BookDto
        {
            BookId = b.BookId,
            BookName = b.BookName ?? "",
            ImageUrl = b.ImageUrl ?? "",
            Author = b.Author ?? "",
            Description = b.Description ?? "",
            Copies = b.Copies
        })
        .FirstOrDefaultAsync();
}
public async Task<List<BookDto>> PendingBook()
{
    return await (
        from issue in _context.Issues
        join book in _context.Books
            on issue.BookId equals book.BookId
        where issue.status == Status.Pending
        select new BookDto
        {
            BookId = book.BookId,
            BookName = book.BookName ?? "",
            ImageUrl = book.ImageUrl ?? "",
            Author = book.Author ?? "",
            Description = book.Description ?? "",
            Copies = book.Copies
        }
    ).ToListAsync();
}

public async Task IssueBook(int bookId)
{
    var book=await _context.Books.FindAsync(bookId);
    var issue = await _context.Issues
        .FirstOrDefaultAsync(i =>
            i.BookId == bookId &&
            i.status == Status.Pending);
     
    if (issue == null)
        return;

    issue.status = Status.Issued;
    book.Copies=book.Copies-1;
    await _context.SaveChangesAsync();
}


public async Task RejectBook(int bookId)
{
    var issue = await _context.Issues
        .FirstOrDefaultAsync(i =>
            i.BookId == bookId &&
            i.status == Status.Pending);

    if (issue == null)
        return;

    issue.status = Status.Returned;
    await _context.SaveChangesAsync();
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


    }
}