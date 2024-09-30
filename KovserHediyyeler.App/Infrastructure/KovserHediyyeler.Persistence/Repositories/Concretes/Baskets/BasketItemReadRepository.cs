using KovserHedieyyeler.Application.Repositories.Abstractions.Baskets;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.Baskets
{
    public class BasketItemReadRepository : ReadRepository<BasketItem>, IBasketItemReadRepository
    {
        public BasketItemReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
