namespace LMS.API.Models
{
    public class Book
    {
        public int BookId{get;set;}
        public string BookName{get;set;}
        public string ImageUrl { get; set; }
        public string Author{get;set;}
        public string Description{get;set;}
        public int Copies{get;set;}
    }
}