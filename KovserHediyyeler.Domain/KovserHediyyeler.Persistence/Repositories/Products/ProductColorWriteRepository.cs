using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Products
{
    public class ProductColorWriteRepository : WriteRepository<ProductColor>, IProductColorWriteRepository
    {
        public ProductColorWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
