using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Products
{
    public class ProductSizeWriteRepository : WriteRepository<ProductSize>, IProductSizeWriteRepository
    {
        public ProductSizeWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
