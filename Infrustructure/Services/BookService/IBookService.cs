using Infrustructure.Models;

namespace Infrustructure.Services;

public interface IBookService
{
    Task<bool> CreateBookAsync(Books book);
    Task<bool> UpdateBookAsync(Books book);
    Task<bool> DeleteBookAsync(Guid bookId);
    Task<Books> GetBookByIdAsync(Guid bookId);
    Task<IEnumerable<Books>> GetAllBooksAsync();
    Task<IEnumerable<BookAuthorAndCategory>> GetBookAuthorAndCategoryAsync();
    Task<IEnumerable<Books>> GetBooksByAuthorAsync(Guid authorId);
}