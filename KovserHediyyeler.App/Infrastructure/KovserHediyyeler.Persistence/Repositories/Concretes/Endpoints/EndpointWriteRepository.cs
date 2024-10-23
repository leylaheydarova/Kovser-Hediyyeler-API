using KovserHedieyyeler.Application.Repositories.Interfaces.Endpoints;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.Endpoints
{
    public class EndpointWriteRepository : WriteRepository<Endpoint>, IEndpointWriteRepository
    {
        public EndpointWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
