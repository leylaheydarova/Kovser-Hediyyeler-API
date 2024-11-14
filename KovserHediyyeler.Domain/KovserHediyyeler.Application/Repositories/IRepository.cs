using KovserHediyyeler.Domain.Models.BaseModel;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
