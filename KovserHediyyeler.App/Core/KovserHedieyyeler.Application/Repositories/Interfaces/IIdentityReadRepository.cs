using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Repositories.Abstractions
{
    public interface IIdentityReadRepository<T>:IIdentityRepository<T> where T: IdentityUser<Guid>
    {
        IQueryable GetAll(bool isTracking);
        IQueryable GetAllWhere(Expression<Func<T, bool>> predicate, bool isTracking, params string[] includes);
        Task<T> GetByIdAsync(string id, bool isTracking, params string[] includes);
        Task<T> GetWhereAsync(Expression<Func<T, bool>> predicate, bool isTracking, params string[] includes);
    }
}
