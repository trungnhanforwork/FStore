using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Service.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<ICategoryService> _categoryService;
    private readonly Lazy<IProductService> _productService;
    private readonly Lazy<IAuthenticationService> _authenticationService;

    
    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, IFileManager fileManager, UserManager<User> userManager, IConfiguration configuration)
    {
        _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, logger, mapper));
        _productService = new Lazy<IProductService>(() => new ProductSevice(repositoryManager, fileManager, logger, mapper));
        _authenticationService =
            new Lazy<IAuthenticationService>(
                () => new AuthenticationService(logger, mapper, userManager, configuration));
    }

    public ICategoryService CategoryService => _categoryService.Value;
    public IProductService ProductService => _productService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}