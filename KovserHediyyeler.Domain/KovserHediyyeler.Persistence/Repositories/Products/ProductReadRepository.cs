using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Products
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
