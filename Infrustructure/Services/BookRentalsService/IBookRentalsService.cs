using Infrustructure.Models;

namespace Infrustructure.Services.BookRentalsService;

public interface IBookRentalsService
{
    Task<bool> CreateBookRentalsAsync(BookRentals bookRental);
    Task<bool> DeleteBookRentalsAsync(Guid id);
    Task<BookRentals> GetBookRentalsByIdAsync(Guid id);
    Task<IEnumerable<BookRentals>> GetBookRentalsAsync();
    Task<bool> UpdateBookRentalsAsync(BookRentals bookRental);
    Task<IEnumerable<BookRentalByUserId>> GetBookRentalsByUserIdAsync(Guid userId);
}