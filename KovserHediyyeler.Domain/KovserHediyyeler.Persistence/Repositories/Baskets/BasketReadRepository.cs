using KovserHediyyeler.Application.Repositories.Baskets;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Baskets
{
    public class BasketReadRepository : ReadRepository<Basket>, IBasketReadRepository
    {
        public BasketReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
