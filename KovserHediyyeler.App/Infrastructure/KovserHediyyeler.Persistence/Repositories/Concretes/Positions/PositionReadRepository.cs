using KovserHedieyyeler.Application.Repositories.Abstractions.Positions;
using KovserHedieyyeler.Application.Repositories.Interfaces.Positions;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.Positions
{
    public class PositionReadRepository : ReadRepository<Position>, IPositionReadRepository
    {
        public PositionReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
