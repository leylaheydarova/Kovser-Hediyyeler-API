using KovserHediyyeler.Application.Repositories.Baskets;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Baskets
{
    public class BasketWriteRepository : WriteRepository<Basket>, IBasketWriteRepository
    {
        public BasketWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
