using Entities.Models;

namespace Contracts;

public interface ICategoryRepository
{
    IEnumerable<Category> GetAllCategories(bool trackChanges);
    Category? GetCategoryById(Guid categoryId, bool trackChanges);
    
    Category? GetCategoryByName(string name, bool trackChanges);

    void CreateCategory(Category category);

    void DeleteCategory(Category category);
}