using KovserHediyyeler.Application.Repositories.Departments;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;

namespace KovserHediyyeler.Persistence.Repositories.Departments
{
    public class DepartmentReadRepository : ReadRepository<Department>, IDepartmentReadRepository
    {
        public DepartmentReadRepository(KovserHediyyelerDbContext context) : base(context)
        {
        }
    }
}
