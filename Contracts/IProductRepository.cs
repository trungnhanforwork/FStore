using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IProductRepository
{
    Task<Product?> GetProductByIdAsync(Guid id, bool trackChanges);
    Task<IEnumerable<Product>> GetProductsByCategoryId(Guid categoryId, bool trackChanges);
    Task<PagedList<Product>> GetAllProductsAsync(bool trackChanges, ProductParameters productParameters);

    void CreateProduct(Product product);
    void DeleteProduct(Product product);
}