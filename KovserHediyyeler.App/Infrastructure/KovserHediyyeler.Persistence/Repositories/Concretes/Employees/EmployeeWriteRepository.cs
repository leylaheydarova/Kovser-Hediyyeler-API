using KovserHedieyyeler.Application.Repositories.Abstractions.Employees;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes.Employees
{
    public class EmployeeWriteRepository : WriteRepository<Employee>, IEmployeeWriteRepository
    {
        public EmployeeWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
