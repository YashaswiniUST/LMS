using LMS.API.Services;
using LMS.Library.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controller
{
    [ApiController]
    [Route("api/student")]
    public class StudentController:ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService=studentService;
        }
        [HttpGet("all-books")]

        public IActionResult GetAllBooks()
        {
            var books=_studentService.GetAllBooks();
            return Ok(books);
        }
        [HttpPost("request-book")]
        public IActionResult RequestBook(RequestBook dto)
        {
            _studentService.RequestBook(dto);
            return Ok("Request submitted successfullyy..!");
        }
        [HttpGet("issued-book")]
       public async Task<IActionResult> IssueHistory()
       {
        var history = await _studentService.GetIssueHistory();
        return Ok(history);
        }
        [HttpPut("return-book/{id}")]
public async Task<IActionResult> ReturnBooks(int id)
{
    var result = await _studentService.ReturnBook(id);

    if (!result)
        return NotFound("Issue record or book not found");

    return Ok("Book returned successfully");
}

        
    }
}