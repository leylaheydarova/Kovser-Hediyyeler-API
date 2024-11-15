using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Products
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
