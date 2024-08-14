using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
    public async Task<Order?> GetOrderByIdAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(o => o.Id == id, trackChanges).SingleOrDefaultAsync();
    }
    public void CreateOrder(Order order) => Create(order);
}