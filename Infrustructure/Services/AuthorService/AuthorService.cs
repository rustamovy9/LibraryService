using Dapper;
using Infrustructure.Models;
using Npgsql;

namespace Infrustructure.Services.AuthorService;

public class AuthorService:IAuthorService
{
    public async Task<bool> CreateAuthorAsync(Authors authors)
    {
        try
        {
            using (NpgsqlConnection conn = new(SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SqlCommand.createAuhtor,authors) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateAuthorAsync(Authors authors)
    {
        try
        {
            using (NpgsqlConnection conn = new(SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SqlCommand.updateAuthor,authors) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteAuthorAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection conn = new(SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SqlCommand.deleteAuthor,new {Id=id}) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Authors> GetAuthorByIdAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection conn = new(SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Authors>(SqlCommand.createAuhtor,new {Id=id});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Authors>> GetAuthors()
    {
        try
        {
            using (NpgsqlConnection conn = new(SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Authors>(SqlCommand.getAllAuthors);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}