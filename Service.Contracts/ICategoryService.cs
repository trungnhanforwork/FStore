using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges);
    Task<CategoryDto> GetCategoryByIdAsync(Guid catergoryId, bool trackChanges);
    Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto category, bool trackChanges);
    Task DeleteCategoryAsync(Guid catergoryId, bool trackChanges);
    Task UpdateCategoryAsync(Guid categoryId, CategoryForUpdateDto categoryForUpdateDto, bool trackChanges);
}