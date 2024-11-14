using KovserHediyyeler.Domain.Models.BaseModels;
using Microsoft.EntityFrameworkCore;

namespace KovserHedieyyeler.Application.Repositories.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
