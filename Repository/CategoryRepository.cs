using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class CategoryRepository: RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
    }
    public async Task<Category?> GetCategoryByIdAsync(Guid categoryId, bool trackChanges)
    {
        return await FindByCondition(c => c.Id == categoryId, trackChanges).SingleOrDefaultAsync();
    }
    public Task<Category?> GetCategoryByNameAsync(string name, bool trackChanges)
    {
        return FindByCondition(c => c.Name == name, trackChanges).SingleOrDefaultAsync();
    }

    public void CreateCategory(Category category) => Create(category);

    public void DeleteCategory(Category category) => Delete(category);
    
}