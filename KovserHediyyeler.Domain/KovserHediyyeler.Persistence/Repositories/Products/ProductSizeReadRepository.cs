using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Products
{
    public class ProductSizeReadRepository : ReadRepository<ProductSize>, IProductSizeReadRepository
    {
        public ProductSizeReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
