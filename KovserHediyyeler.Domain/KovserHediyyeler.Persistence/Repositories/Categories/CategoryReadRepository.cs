using KovserHediyyeler.Application.Repositories.Categories;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Categories
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
