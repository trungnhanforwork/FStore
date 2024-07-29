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
    public IActionResult GetCategories()
    {
        var categories = _service.CategoryService.GetAllCategories(trackChanges: false);
        return Ok(categories);
    }
    
    [HttpGet("{id:guid}", Name = "CategoryById")]
    public IActionResult GetCategoryById(Guid id)
    {
        var categories = _service.CategoryService.GetCategoryById(id, trackChanges: false);
        return Ok(categories);
    }

    [HttpPost]
    public IActionResult CreateCategory([FromBody] CategoryForCreationDto? categoryForCreationDto)
    {
        if (categoryForCreationDto is null)
            return BadRequest("CategoryForCreationDto object is null");
        
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var newCategory = _service.CategoryService.CreateCategory(categoryForCreationDto, trackChanges: false);
        return CreatedAtRoute("CategoryById", new { id = newCategory.Id }, newCategory);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCategory(Guid id)
    {
        _service.CategoryService.DeleteCategory(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateCategory(Guid id, [FromBody] CategoryForUpdateDto? categoryForUpdateDto)
    {
        if (categoryForUpdateDto is null)
            return BadRequest("CategoryForCreationDto object is null");
        
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        
        _service.CategoryService.UpdateCategory(id, categoryForUpdateDto, true);
        return NoContent();
    }
}