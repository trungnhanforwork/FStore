using Entities.Models;

namespace Contracts;

public interface IProductRepository
{
    Task<Product?> GetProductByIdAsync(Guid id, bool trackChanges);
    Task<IEnumerable<Product>> GetProductsByCategoryId(Guid categoryId, bool trackChanges);
    Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges);

    void CreateProduct(Product product);
    void DeleteProduct(Product product);
}