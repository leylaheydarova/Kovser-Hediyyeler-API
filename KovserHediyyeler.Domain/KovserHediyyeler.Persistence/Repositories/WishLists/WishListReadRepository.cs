using KovserHediyyeler.Application.Repositories.WishLists;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.WishLists
{
    public class WishListReadRepository : ReadRepository<WishList>, IWishListReadRepository
    {
        public WishListReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
