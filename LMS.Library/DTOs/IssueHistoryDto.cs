using LMS.Library.Enums;

namespace LMS.Library.DTOs
{
    public class IssueHistoryDto
{
    public int IssueId { get; set; }
    public int BookId { get; set; }
    public string BookName { get; set; } = "";
    public string Author { get; set; } = "";
    public Status Status { get; set; }
}

}