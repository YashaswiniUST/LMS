using LMS.API.Models;
using LMS.Library.DTOs;

namespace LMS.API.Services
{
    public interface IStudentService
    {
        public List<BookDto> GetAllBooks();
        public Issue RequestBook(RequestBook dto);
       
    }
}