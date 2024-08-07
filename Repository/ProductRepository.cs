using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

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

    public async Task<PagedList<Product>> GetAllProductsAsync(bool trackChanges, ProductParameters productParameters)
    {
        var products =  await FindAll(trackChanges)
            .ToListAsync();
        return PagedList<Product>.ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
    }

    public void CreateProduct(Product product) => Create(product);

    public void DeleteProduct(Product product) => Delete(product);
}