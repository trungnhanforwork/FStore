using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<Product?> GetProductByIdAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(p => p.Id == id, trackChanges).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryId(Guid categoryId, bool trackChanges)
    {
        return await FindByCondition(p => p.CategoryId == categoryId, trackChanges).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public void CreateProduct(Product product) => Create(product);

    public void DeleteProduct(Product product) => Delete(product);
}