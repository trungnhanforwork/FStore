using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace FStore.Presentation.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IServiceManager _service;

    public ProductsController(IServiceManager service)
    {
        _service = service;
    }
    
    [HttpGet("{id:guid}", Name = "ProductById")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var productDto = await _service.ProductService.GetProductByIdAsync(id, trackChanges: false);
        return Ok(productDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _service.ProductService.GetAllProductsAsync(false);
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromForm] ProductForCreationDto? product)
    {
        if (product == null)
        {
            return BadRequest("ProductForCreationDto object is null");
        }
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        var createdProduct = await _service.ProductService.CreateProductAsync(product, trackChanges: false);
        return CreatedAtRoute("ProductById", new { id = createdProduct.Id }, createdProduct);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromForm] ProductForUpdateDto? productForUpdateDto)
    {
        if (productForUpdateDto is null)
            return BadRequest("ProductForCreationDto object is null");
        
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        
        await _service.ProductService.UpdateProductAsync(id, productForUpdateDto, trackChanges: true);
        return NoContent(); 
    }
    

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult>  DeleteProduct(Guid id)
    {
        await _service.ProductService.DeleteProductAsync(id, true);
        return NoContent();
    }
}