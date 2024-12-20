using KovserHediyyeler.Application.Repositories.Orders;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Orders
{
    public class ShippingWriteRepository : WriteRepository<Shipping>, IShippingWriteRepository
    {
        public ShippingWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
