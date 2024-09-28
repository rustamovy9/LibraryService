using Infrustructure.Models;

namespace Infrustructure.Services.AuthorService;

public interface IAuthorService
{
    Task<bool> CreateAuthorAsync(Authors authors);
    Task<bool> UpdateAuthorAsync(Authors authors);
    Task<bool> DeleteAuthorAsync(Guid id);
    Task<Authors> GetAuthorByIdAsync(Guid id);
    Task<IEnumerable<Authors>> GetAuthors();
}