using KovserHediyyeler.Application.Repositories.Departments;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Departments
{
    public class DepartmentWriteRepository : WriteRepository<Department>, IDepartmentWriteRepository
    {
        public DepartmentWriteRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
