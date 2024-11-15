using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Products
{
    public class ColorWriteRepository : WriteRepository<ColorCode>, IColorWriteRepository
    {
        public ColorWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
