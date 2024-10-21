using KovserHedieyyeler.Application.Repositories.Abstractions.Products;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.Products
{
    public class ProductPropertyWriteRepository : WriteRepository<ProductProperty>, IProductPropertyWriteRepository
    {
        public ProductPropertyWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
