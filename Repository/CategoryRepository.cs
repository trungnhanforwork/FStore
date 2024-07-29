using Contracts;
using Entities.Models;

namespace Repository;

public class CategoryRepository: RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Category> GetAllCategories(bool trackChanges)
    {
        return FindAll(trackChanges).OrderBy(c => c.Name).ToList();
    }

    public Category? GetCategoryById(Guid categoryId, bool trackChanges)
    {
        return FindByCondition(c => c.Id == categoryId, trackChanges).SingleOrDefault();
    }
    
    public Category? GetCategoryByName(string name, bool trackChanges)
    {
        return FindByCondition(c => c.Name == name, trackChanges).SingleOrDefault();
    }
    

    public void CreateCategory(Category category) => Create(category);

    public void DeleteCategory(Category category) => Delete(category);
    
}