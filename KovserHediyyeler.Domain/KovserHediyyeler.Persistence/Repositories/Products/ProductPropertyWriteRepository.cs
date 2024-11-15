using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Products
{
    internal class ProductPropertyWriteRepository : WriteRepository<ProductProperty>, IProductPropertyWriteRepository
    {
        public ProductPropertyWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
