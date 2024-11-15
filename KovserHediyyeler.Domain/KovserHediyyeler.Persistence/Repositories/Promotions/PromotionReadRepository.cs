using KovserHediyyeler.Application.Repositories.Promotions;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Promotions
{
    public class PromotionReadRepository : ReadRepository<Promotion>, IPromotionReadRepository
    {
        public PromotionReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
