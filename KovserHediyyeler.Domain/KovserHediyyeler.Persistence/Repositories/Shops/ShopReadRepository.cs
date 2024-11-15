using KovserHediyyeler.Application.Repositories.Shops;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Shops
{
    public class ShopReadRepository : ReadRepository<Shop>, IShopReadRepository
    {
        public ShopReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
