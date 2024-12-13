using KovserHediyyeler.Application.Repositories.Orders;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Orders
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
