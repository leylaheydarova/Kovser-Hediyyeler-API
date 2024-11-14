using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Brands
{
    public class BrandReadRepository : ReadRepository<Brand>, IBrandReadRepository
    {
        public BrandReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
