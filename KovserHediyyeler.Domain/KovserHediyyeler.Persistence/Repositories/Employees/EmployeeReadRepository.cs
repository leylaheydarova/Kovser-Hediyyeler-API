using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Employees
{
    public class EmployeeReadRepository : ReadRepository<Employee>, IEmployeeReadRepository
    {
        public EmployeeReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
