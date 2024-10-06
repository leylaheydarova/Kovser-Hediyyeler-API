using KovserHedieyyeler.Application.Repositories.Abstractions.Positions;
using KovserHedieyyeler.Application.Repositories.Interfaces.Positions;
using KovserHedieyyeler.Application.Repositories.Interfaces.Promotions;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.Promotions
{
    public class PromotionReadRepository : ReadRepository<Promotion>, IPromotionReadRepository
    {
        public PromotionReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
