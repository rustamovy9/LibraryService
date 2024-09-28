using Dapper;
using Infrustructure.Models;
using Npgsql;

namespace Infrustructure.Services.UserService;

public class UserService:IUserService
{
    public async Task<bool> CreateUserAsync(Users user)
    {
        try
        {
            using(NpgsqlConnection conn = new (SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SqlCommand.createUser,user)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateUserAsync(Users user)
    {
        try
        {
            using(NpgsqlConnection conn = new (SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SqlCommand.updateUser,user)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
        try
        {
            using(NpgsqlConnection conn = new (SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SqlCommand.deleteUser, new { id = userId })>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Users>? GetUserByIdAsync(Guid userId)
    {
        try
        {
            using(NpgsqlConnection conn = new (SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Users>(SqlCommand.getUserById, new { id = userId });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Users>> GetUsersAsync()
    {
        try
        {
            using(NpgsqlConnection conn = new (SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Users>(SqlCommand.getAllUsers);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}