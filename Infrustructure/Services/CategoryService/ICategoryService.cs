using Infrustructure.Models;

namespace Infrustructure.Services.CategoryService;

public interface ICategoryService
{
    Task<bool> CreateCategoryAsync(Categories category);
    Task<bool> UpdateCategoryAsync(Categories category);
    Task<bool> DeleteCategoryAsync(Guid categoryId);
    Task<Categories?> GetCategoryByIdAsync(Guid categoryId);
    Task<IEnumerable<Categories>> GetAllCategoriesAsync();
}