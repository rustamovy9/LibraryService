using Dapper;
using Infrustructure.Models;
using Npgsql;

namespace Infrustructure.Services.CategoryService;

public class CategoryService:ICategoryService
{
    public async Task<bool> CreateCategoryAsync(Categories category)
    {
        try
        {
            using (NpgsqlConnection conn = new(SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SqlCommand.createCategory,category)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateCategoryAsync(Categories category)
    {
        try
        {
            using (NpgsqlConnection conn = new(SqlCommand.updateCategory))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SqlCommand.updateCategory,category)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteCategoryAsync(Guid categoryId)
    {
        try
        {
            using (NpgsqlConnection conn = new(SqlCommand.deleteCategory))
            {
                await conn.OpenAsync();
                return await conn.ExecuteAsync(SqlCommand.deleteCategory, new {Id=categoryId })>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Categories?> GetCategoryByIdAsync(Guid categoryId)
    {
        try
        {
            using (NpgsqlConnection conn = new (SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Categories>(SqlCommand.getCategoryById, new { Id = categoryId });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Categories>> GetAllCategoriesAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new (SqlCommand.connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Categories>(SqlCommand.getAllCategories);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}