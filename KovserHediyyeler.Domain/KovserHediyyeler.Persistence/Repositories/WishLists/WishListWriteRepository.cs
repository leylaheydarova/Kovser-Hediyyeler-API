using KovserHediyyeler.Application.Repositories.WishLists;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.WishLists
{
    public class WishListWriteRepository : WriteRepository<WishList>, IWishListWriteRepository
    {
        public WishListWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
