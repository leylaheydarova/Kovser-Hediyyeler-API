using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Brands
{
    public class BrandWriteRepository : WriteRepository<Brand>, IBrandWriteRepository
    {
        public BrandWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
