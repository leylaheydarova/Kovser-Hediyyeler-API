using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Products
{
    public class ProductPropertyReadRepository : ReadRepository<ProductProperty>, IProductPropertyReadRepository
    {
        public ProductPropertyReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
