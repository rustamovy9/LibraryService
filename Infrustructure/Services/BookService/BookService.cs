using Dapper;
using Infrustructure.Models;
using Npgsql;

namespace Infrustructure.Services;

public class BookService:IBookService
{
    public async Task<bool> CreateBookAsync(Books book)
    {
        try
        {
            using (NpgsqlConnection conn = new(SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SqlCommand.createBook, book)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateBookAsync(Books book)
    {
        try
        {
            using (NpgsqlConnection conn = new(SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SqlCommand.updateBook, book)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteBookAsync(Guid bookId)
    {
        try
        {
            using (NpgsqlConnection conn = new(SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SqlCommand.deleteBook,new {bookId})>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Books> GetBookByIdAsync(Guid bookId)
    {
        try
        {
            using (NpgsqlConnection conn = new(SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Books>(SqlCommand.getBookById,new {Id=bookId});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Books>> GetAllBooksAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new(SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Books>(SqlCommand.getAllBooks);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<BookAuthorAndCategory>> GetBookAuthorAndCategoryAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new(SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<BookAuthorAndCategory>(SqlCommand.getBookAutohorAndCategory);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Books>> GetBooksByAuthorAsync(Guid authorId)
    {
        try
        {
            using (NpgsqlConnection conn = new(SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Books>(SqlCommand.getBookByAuthor, new {AuthorId=authorId});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}