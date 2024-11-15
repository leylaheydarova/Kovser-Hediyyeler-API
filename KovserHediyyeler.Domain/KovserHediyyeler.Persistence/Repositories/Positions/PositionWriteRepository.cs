using KovserHediyyeler.Application.Repositories.Positions;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Positions
{
    public class PositionWriteRepository : WriteRepository<Position>, IPositionWriteRepository
    {
        public PositionWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
