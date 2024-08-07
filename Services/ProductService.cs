using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Services;


internal sealed class ProductSevice : IProductService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IFileManager _fileManager;
    public ProductSevice(IRepositoryManager repository, IFileManager fileManager, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _fileManager = fileManager;
    }
    
    public async Task<(IEnumerable<ProductDto> productDtos, MetaData metaData)> GetAllProductsAsync(bool trackChanges, ProductParameters productParameters)
    {
        var productsWithMetaData = await _repository.Product.GetAllProductsAsync(trackChanges: trackChanges, productParameters: productParameters);
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(productsWithMetaData);
        return (productDtos, productsWithMetaData.MetaData);
    }

    public async Task<ProductDto> GetProductByIdAsync(Guid id, bool trackChanges)
    {
        var product = await _repository.Product.GetProductByIdAsync(id, trackChanges);
        if (product is null)
        {
            throw new ProductNotFoundException(id);
        }
        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByCategory(Guid categoryId, bool trackChanges)
    {
        var products = await _repository.Product.GetProductsByCategoryId(categoryId, trackChanges);
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        return productDtos;
    }

    public async Task<ProductDto> CreateProductAsync(ProductForCreationDto? productForCreationDto, bool trackChanges)
    {
        string imageName = null;
        try
        {
            // Check if the category exists
            var existingCategory = await _repository.Category.GetCategoryByIdAsync(productForCreationDto!.CategoryId, trackChanges);
            if (existingCategory == null)
            {
                throw new CategoryNotFoundException(productForCreationDto.CategoryId);
            }
            
            // Save image
            imageName = await _fileManager.SaveFileAsync(productForCreationDto.Thumbnail);
            var productEntity = _mapper.Map<Product>(productForCreationDto);
            productEntity.Thumbnail = imageName;
            productEntity.CreatedAt = DateTime.UtcNow;
            productEntity.UpdatedAt = DateTime.UtcNow;
            
            // Create the product and save to database
            _repository.Product.CreateProduct(productEntity);
            await _repository.SaveAsync();
            
            var productToReturn = _mapper.Map<ProductDto>(productEntity);
            return productToReturn;
        }
        catch
        {
            if (imageName != null)
            {
                await _fileManager.DeleteFileAsync(imageName);
            }
            throw;
        }
    }
    public async Task UpdateProductAsync(Guid id, ProductForUpdateDto? productForUpdateDto, bool trackChanges)
    {
        // Retrieve the existing product from the repository
        var existingProduct = await _repository.Product.GetProductByIdAsync(id, trackChanges);
        
        if (existingProduct is null)
        {
            throw new ProductNotFoundException(id);
        }
        var oldThumnail = existingProduct.Thumbnail;
        // Map the updated fields from the DTO to the existing product
        _mapper.Map(productForUpdateDto, existingProduct);
        
        // Handle file upload for the thumbnail if provided
        if (productForUpdateDto.Thumbnail != null)
        {
            // Delete the old thumbnail file if it exists
            if (!string.IsNullOrEmpty(existingProduct.Thumbnail))
            {
                await _fileManager.DeleteFileAsync(existingProduct.Thumbnail);
            }

            // Save the new thumbnail file
            var newThumbnailName = await _fileManager.SaveFileAsync(productForUpdateDto.Thumbnail);
            existingProduct.Thumbnail = newThumbnailName;
        }
        else
        {
            existingProduct.Thumbnail = oldThumnail;
        }
        existingProduct.UpdatedAt = DateTime.UtcNow;
        // Save changes to the database
        await _repository.SaveAsync();
    }
    

    public async Task DeleteProductAsync(Guid id, bool trackChanges)
    {
        var existingProduct = await _repository.Product.GetProductByIdAsync(id, trackChanges);
        if (existingProduct is null)
        {
            throw new ProductNotFoundException(id);
        }
        _repository.Product.DeleteProduct(existingProduct);
        await _repository.SaveAsync();
    }
}
