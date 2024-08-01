using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace FStore.Presentation.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IServiceManager _service;

    public CategoriesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _service.CategoryService.GetAllCategoriesAsync(trackChanges: false);
        return Ok(categories);
    }
    
    [HttpGet("{id:guid}", Name = "CategoryById")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var categories = await _service.CategoryService.GetCategoryByIdAsync(id, trackChanges: false);
        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto? categoryForCreationDto)
    {
        if (categoryForCreationDto is null)
            return BadRequest("CategoryForCreationDto object is null");
        
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var newCategory = await _service.CategoryService.CreateCategoryAsync(categoryForCreationDto, trackChanges: false);
        return CreatedAtRoute("CategoryById", new { id = newCategory.Id }, newCategory);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        await _service.CategoryService.DeleteCategoryAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryForUpdateDto? categoryForUpdateDto)
    {
        if (categoryForUpdateDto is null)
            return BadRequest("CategoryForCreationDto object is null");
        
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        
        await _service.CategoryService.UpdateCategoryAsync(id, categoryForUpdateDto, true);
        return NoContent();
    }
}