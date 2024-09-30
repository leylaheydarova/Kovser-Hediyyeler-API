using KovserHedieyyeler.Application.Repositories.Abstractions.Shops;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.Shops
{
    public class ShopWriteRepository : WriteRepository<Shop>, IShopWriteRepository
    {
        public ShopWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
