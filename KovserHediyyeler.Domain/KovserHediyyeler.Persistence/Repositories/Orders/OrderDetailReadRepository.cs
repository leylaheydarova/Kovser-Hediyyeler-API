using KovserHediyyeler.Application.Repositories.Orders;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Orders
{
    public class OrderDetailReadRepository : ReadRepository<OrderDetail>, IOrderDetailReadRepository
    {
        public OrderDetailReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
