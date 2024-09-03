using KovserHediyyeler.Core.Entities;
using KovserHediyyeler.Core.Repositories.Abstractions.Categories;
using KovserHediyyeler.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Data.Repositories.Concretes.Categories
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
