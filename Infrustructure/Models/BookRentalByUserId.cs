namespace Infrustructure.Models;

public class BookRentalByUserId
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public string Title { get; set; } = null!;
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public DateTime CreatedAt { get; set; }
}