using KovserHediyyeler.Application.Repositories.SocialMedias;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.SocialMedias
{
    public class SocialMediaWriteRepository : WriteRepository<SocialMedia>, ISocialMediaWriteRepository
    {
        public SocialMediaWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
