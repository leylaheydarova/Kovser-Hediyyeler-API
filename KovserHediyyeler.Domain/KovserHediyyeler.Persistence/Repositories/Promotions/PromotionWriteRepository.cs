using KovserHediyyeler.Application.Repositories.Promotions;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Promotions
{
    public class PromotionWriteRepository : WriteRepository<Promotion>, IPromotionWriteRepository
    {
        public PromotionWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
