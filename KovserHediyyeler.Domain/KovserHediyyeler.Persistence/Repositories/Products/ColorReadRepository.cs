using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Products
{
    public class ColorReadRepository : ReadRepository<ColorCode>, IColorReadRepository
    {
        public ColorReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
