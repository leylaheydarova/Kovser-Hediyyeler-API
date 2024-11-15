using KovserHediyyeler.Application.Repositories.Positions;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Positions
{
    public class PositionReadRepository : ReadRepository<Position>, IPositionReadRepository
    {
        public PositionReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
