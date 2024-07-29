using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICategoryService
{
    IEnumerable<CategoryDto> GetAllCategories(bool trackChanges);
    CategoryDto GetCategoryById(Guid catergoryId, bool trackChanges);
    CategoryDto CreateCategory(CategoryForCreationDto category, bool trackChanges);
    void DeleteCategory(Guid catergoryId, bool trackChanges);
    void UpdateCategory(Guid categoryId, CategoryForUpdateDto categoryForUpdateDto, bool trackChanges);
}