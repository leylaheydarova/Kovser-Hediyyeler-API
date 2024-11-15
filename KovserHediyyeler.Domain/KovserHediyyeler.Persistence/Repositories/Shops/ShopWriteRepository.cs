using KovserHediyyeler.Application.Repositories.Shops;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Shops
{
    public class ShopWriteRepository : WriteRepository<Shop>, IShopWriteRepository
    {
        public ShopWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
