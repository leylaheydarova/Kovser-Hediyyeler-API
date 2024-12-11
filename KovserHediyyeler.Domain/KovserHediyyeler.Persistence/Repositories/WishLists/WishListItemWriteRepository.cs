using KovserHediyyeler.Application.Repositories.WishLists;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.WishLists
{
    public class WishListItemWriteRepository : WriteRepository<WishListItem>, IWishListItemWriteRepository
    {
        public WishListItemWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
