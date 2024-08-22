using KovserHediyyeler.Core.Entities;
using KovserHediyyeler.Core.Repositories.Abstractions.Departments;
using KovserHediyyeler.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Data.Repositories.Concretes.Departments
{
    public class DepartmentWriteRepository : WriteRepository<Department>, IDepartmentWriteRepository
    {
        public DepartmentWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
