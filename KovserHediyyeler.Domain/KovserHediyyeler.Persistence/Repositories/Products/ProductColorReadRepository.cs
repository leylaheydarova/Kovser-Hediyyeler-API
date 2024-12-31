using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Products
{
    public class ProductColorReadRepository : ReadRepository<ProductColor>, IProductColorReadRepository
    {
        public ProductColorReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
