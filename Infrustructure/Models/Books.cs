using System.Runtime;

namespace Infrustructure.Models;

public class Books
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ISBN { get; set; }
    public DateTime PublishedDate { get; set; }
    public Guid AuthorId { get; set; }
    public Guid CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
}