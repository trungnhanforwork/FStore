using Entities.Models;
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges);
    Task<ProductDto> GetProductByIdAsync(Guid id, bool trackChanges);
    Task<IEnumerable<ProductDto>> GetProductsByCategory(Guid categoryId, bool trackChanges);
    Task<ProductDto> CreateProductAsync(ProductForCreationDto? productForCreationDto, bool trackChanges);
    Task UpdateProductAsync(Guid id, ProductForUpdateDto? productForUpdateDto, bool trackChanges);
    Task DeleteProductAsync(Guid id, bool trackChanges);
}