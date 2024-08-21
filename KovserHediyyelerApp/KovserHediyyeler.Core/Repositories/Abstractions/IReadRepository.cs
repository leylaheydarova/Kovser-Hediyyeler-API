using KovserHediyyeler.Core.Entities.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Core.Repositories.Abstractions
{
    public interface IReadRepository<T>:IRepository<T>where T : BaseEntity
    {
        IQueryable<T> GetAll(bool isTracking = true);
        IQueryable<T> GetAllWhere(Expression<Func<T, bool>> predicate, bool isTracking = true, params string[] include);
        Task<T?> GetByIdAsync(int id, bool isTracking = true, params string[] include);
        Task<T?> GetWhere(Expression<Func<T, bool>> predicate, bool isTracking = true, params string[] include); 
    }
}
