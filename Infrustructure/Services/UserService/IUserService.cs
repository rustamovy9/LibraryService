using Infrustructure.Models;

namespace Infrustructure.Services.UserService;

public interface IUserService
{
    Task<bool> CreateUserAsync(Users user);
    Task<bool> UpdateUserAsync(Users user);
    Task<bool> DeleteUserAsync(Guid userId);
    Task<Users>? GetUserByIdAsync(Guid userId);
    Task<IEnumerable<Users>> GetUsersAsync();
}