using KovserHediyyeler.Application.Repositories.Baskets;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Baskets
{
    public class BasketItemReadRepository : ReadRepository<BasketItem>, IBasketItemReadRepository
    {
        public BasketItemReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
