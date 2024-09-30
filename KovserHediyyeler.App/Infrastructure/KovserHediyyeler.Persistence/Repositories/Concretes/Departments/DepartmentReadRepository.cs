using KovserHedieyyeler.Application.Repositories.Abstractions.Departments;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.Departments
{
    public class DepartmentReadRepository : ReadRepository<Department>, IDepartmentReadRepository
    {
        public DepartmentReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
