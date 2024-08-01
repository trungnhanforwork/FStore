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
    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges)
    {
        try
        {
            var categories = await _repository.Category.GetAllCategoriesAsync(trackChanges);
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoriesDto;
        }
        catch (Exception e)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllCategoriesAsync)} service method {e}");
            throw;
        }
    }
    public async Task<CategoryDto> GetCategoryByIdAsync(Guid catergoryId, bool trackChanges)
    {
        var category = await _repository.Category.GetCategoryByIdAsync(catergoryId, trackChanges);
        if (category is null)
        {
            throw new CategoryNotFoundException(catergoryId);
        }

        var categoryDto = _mapper.Map<CategoryDto>(category);
        return categoryDto;
    }
    public async Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto, bool trackChanges)
    {
        
        var existingCategory = await _repository.Category.GetCategoryByNameAsync(categoryForCreationDto.Name!, false);
        if (existingCategory is not null || categoryForCreationDto.Name == "")
        {
            throw new Exception("Invalid name or this name of category have already used in database");
        }
        
        var categoryEntity = _mapper.Map<Category>(categoryForCreationDto);
        _repository.Category.CreateCategory(categoryEntity);
        await _repository.SaveAsync();
        var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);
        return categoryToReturn; 
    }
    public async Task DeleteCategoryAsync(Guid categoryId, bool trackChanges)
    {
        var existingCategory = await _repository.Category.GetCategoryByIdAsync(categoryId, trackChanges);
        if (existingCategory is null)
        {
            throw new CategoryNotFoundException(categoryId);
        }
        _repository.Category.DeleteCategory(existingCategory);
        await _repository.SaveAsync();
    }
    public async Task UpdateCategoryAsync(Guid categoryId, CategoryForUpdateDto categoryForUpdateDto , bool trackChanges)
    {
        var existingCategory = await _repository.Category.GetCategoryByIdAsync(categoryId, trackChanges);
        if (existingCategory is null)
        {
            throw new CategoryNotFoundException(categoryId);
        }

        _mapper.Map(categoryForUpdateDto, existingCategory);
        await _repository.SaveAsync();
    }
}
