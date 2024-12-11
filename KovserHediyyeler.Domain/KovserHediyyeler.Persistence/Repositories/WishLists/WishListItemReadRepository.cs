using KovserHediyyeler.Application.Repositories.WishLists;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.WishLists
{
    public class WishListItemReadRepository : ReadRepository<WishListItem>, IWishListItemReadRepository
    {
        public WishListItemReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
