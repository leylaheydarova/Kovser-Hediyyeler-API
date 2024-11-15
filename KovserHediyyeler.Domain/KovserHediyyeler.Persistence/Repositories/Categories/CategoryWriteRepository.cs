using KovserHediyyeler.Application.Repositories.Categories;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Categories
{
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
