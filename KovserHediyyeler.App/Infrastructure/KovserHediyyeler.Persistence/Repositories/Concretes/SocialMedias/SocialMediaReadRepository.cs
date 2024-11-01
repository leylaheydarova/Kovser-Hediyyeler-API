using KovserHedieyyeler.Application.Repositories.Abstractions.SocialMedias;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.SocialMedias
{
    public class SocialMediaReadRepository : ReadRepository<SocialMedia>, ISocialMediaReadRepository
    {
        public SocialMediaReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
