using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace Helper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryForCreationDto, Category>();
        CreateMap<CategoryForUpdateDto, Category>();
        CreateMap<Product, ProductDto>();
        CreateMap<ProductForUpdateDto, Product>();
        CreateMap<ProductForCreationDto, Product>();
        CreateMap<UserForRegistrationDto, User>();
    }
}