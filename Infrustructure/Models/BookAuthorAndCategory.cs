namespace Infrustructure.Models;

public class BookAuthorAndCategory
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string AuthorName { get; set; } = null!;
    public DateTime AuthorDateOfBirth { get; set; }
    public string Biography { get; set; } = null!;
    public string CategoryName { get; set; }
}