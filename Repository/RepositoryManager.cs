using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<ICategoryRepository> _categoryRepository;
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<IOrderRepository> _orderRepository;
    private readonly Lazy<IOrderDetailRepository> _orderDetailRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _categoryRepository = new Lazy<ICategoryRepository>(() => new
            CategoryRepository(repositoryContext));
        _productRepository = new Lazy<IProductRepository>(() => new
            ProductRepository(repositoryContext));
        _orderDetailRepository = new Lazy<IOrderDetailRepository>(() => new 
            OrderDetailRepository(repositoryContext));
        _orderRepository = new Lazy<IOrderRepository>(() => new
            OrderRepository(repositoryContext));
    }
    public IProductRepository Product => _productRepository.Value;
    public ICategoryRepository Category => _categoryRepository.Value;
    public IOrderRepository Order => _orderRepository.Value;
    public IOrderDetailRepository OrderDetail => _orderDetailRepository.Value;
    public void Save() => _repositoryContext.SaveChanges();
    public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
}