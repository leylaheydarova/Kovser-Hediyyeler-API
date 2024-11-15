using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Employees
{
    public class EmployeeWriteRepository : WriteRepository<Employee>, IEmployeeWriteRepository
    {
        public EmployeeWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
