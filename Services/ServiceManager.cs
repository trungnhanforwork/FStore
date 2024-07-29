using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<ICategoryService> _categoryService;
    private readonly Lazy<IProductService> _productService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, logger, mapper));
        _productService = new Lazy<IProductService>(() => new ProductSevice(repositoryManager, logger, mapper));
    }

    public ICategoryService CategoryService => _categoryService.Value;
    public IProductService ProductService => _productService.Value;
}