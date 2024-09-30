using KovserHedieyyeler.Application.Repositories.Abstractions.SocialMedias;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.SocialMedias
{
    public class SocialMediaWriteRepository : WriteRepository<SocialMedia>, ISocialMediaWriteRepository
    {
        public SocialMediaWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
