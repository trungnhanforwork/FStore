using Contracts;
using Entities.Models;

namespace Repository;

public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
{
    public OrderDetailRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateOrderDetail(OrderDetail orderDetail) => Create(orderDetail);
}