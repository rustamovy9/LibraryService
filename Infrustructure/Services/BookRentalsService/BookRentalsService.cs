using Dapper;
using Infrustructure.Models;
using Npgsql;

namespace Infrustructure.Services.BookRentalsService;

public class BookRentalsService:IBookRentalsService
{
    public async Task<bool> CreateBookRentalsAsync(BookRentals bookRentals)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommand.createBookRental, bookRentals) > 0;
        }
    }

    public async Task<bool> UpdateBookRentalsAsync(BookRentals bookRentals)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommand.updateBookRental, bookRentals) > 0;
        }
    }

    public async Task<IEnumerable<BookRentalByUserId>> GetBookRentalsByUserIdAsync(Guid userId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<BookRentalByUserId>(SqlCommand.getBookRentalsByUserId, new {UserId=userId});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteBookRentalsAsync(Guid id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommand.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommand.deleteBookRental, new {Id=id}) > 0;
        }
    }

    public async Task<BookRentals> GetBookRentalsByIdAsync(Guid id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.connectionString))
        {
            await connection.OpenAsync();
            return await connection.QuerySingleOrDefaultAsync<BookRentals>(SqlCommand.getBookRentalById, new {Id=id});
        }
    }

    public async Task<IEnumerable<BookRentals>> GetBookRentalsAsync()
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(SqlCommand.connectionString))
        {
            await conn.OpenAsync();
            return await conn.QueryAsync<BookRentals>(SqlCommand.getAllBookRentals);
        }
    }
}