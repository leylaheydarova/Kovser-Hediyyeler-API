using KovserHedieyyeler.Application.Repositories.Abstractions.WishLists;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.WishLists
{
    public class WishListItemReadRepository : ReadRepository<WishListItem>, IWishListItemReadRepository
    {
        public WishListItemReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
