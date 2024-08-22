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
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
