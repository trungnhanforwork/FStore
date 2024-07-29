using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Services;


internal sealed class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public CategoryService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    public IEnumerable<CategoryDto> GetAllCategories(bool trackChanges)
    {
        try
        {
            var categories = _repository.Category.GetAllCategories(trackChanges);
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoriesDto;
        }
        catch (Exception e)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllCategories)} service method {e}");
            throw;
        }
    }
    public CategoryDto GetCategoryById(Guid catergoryId, bool trackChanges)
    {
        var category = _repository.Category.GetCategoryById(catergoryId, trackChanges);
        if (category is null)
        {
            throw new CategoryNotFoundException(catergoryId);
        }

        var categoryDto = _mapper.Map<CategoryDto>(category);
        return categoryDto;
    }
    public CategoryDto CreateCategory(CategoryForCreationDto categoryForCreationDto, bool trackChanges)
    {
        var existingCategory = _repository.Category.GetCategoryByName(categoryForCreationDto.Name, false);
        if (existingCategory is not null || categoryForCreationDto.Name == "")
        {
            throw new Exception("Invalid name or this name of category have already used in database");
        }
        
        var categoryEntity = _mapper.Map<Category>(categoryForCreationDto);
        _repository.Category.CreateCategory(categoryEntity);
        _repository.Save();
        var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);
        return categoryToReturn; 
    }
    public void DeleteCategory(Guid categoryId, bool trackChanges)
    {
        var existingCategory = _repository.Category.GetCategoryById(categoryId, trackChanges);
        if (existingCategory is null)
        {
            throw new CategoryNotFoundException(categoryId);
        }
        _repository.Category.DeleteCategory(existingCategory);
        _repository.Save();
    }
    public void UpdateCategory(Guid categoryId, CategoryForUpdateDto categoryForUpdateDto , bool trackChanges)
    {
        var existingCategory = _repository.Category.GetCategoryById(categoryId, trackChanges);
        if (existingCategory is null)
        {
            throw new CategoryNotFoundException(categoryId);
        }

        _mapper.Map(categoryForUpdateDto, existingCategory);
        _repository.Save();
    }
}
