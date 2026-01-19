
using LMS.API.Services;
using LMS.Library.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace LMS.API.Controller
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;
        public AdminController(IAdminService _adminService)
        {
            adminService=_adminService;
        }
        [HttpPost("add")]
        public IActionResult AddBook([FromBody] BookDto book)
        {
            var result=adminService.CreateBook(book);
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            var res=await adminService.DeleteBook(id);
            return res switch
            {
                "NOT FOUND"=>NotFound("Book does not exist"),
                "DELETED"=>Ok("Book deleted successfully"),
                "ISSUED"=>BadRequest("book already issued"),
                _ =>StatusCode(500,"unexpected error")

            };
        }
        [HttpPut("edit/{id}")]
        public IActionResult EditBook([FromBody] BookDto book,int id)
        {
            var Editedbook=adminService.EditBook(book,id);
            return Ok(Editedbook);
        }
 [HttpGet("bookByid/{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await adminService.BookById(id);

        if (book == null)
            return NotFound();

        return Ok(book);
    }
   
   [HttpGet("pending-books")]
    public async Task<IActionResult> PendingBook()
    {
        var pendingBooks = await adminService.PendingBook();
        return Ok(pendingBooks);
    }

    [HttpPut("issue/{bookId}")]
    public async Task<IActionResult> IssueBook(int bookId)
    {
        await adminService.IssueBook(bookId);
        return Ok();
    }

    [HttpPut("reject/{bookId}")]
    public async Task<IActionResult> RejectBook(int bookId)
    {
        await adminService.RejectBook(bookId);
        return Ok();
    }
    [HttpGet("issue-history")]
public async Task<IActionResult> IssueHistory()
{
    var history = await adminService.GetIssueHistory();
    return Ok(history);
}

}
}