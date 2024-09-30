using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Repositories.Abstractions
{
    public interface IReadRepository<T>:IRepository<T> where T : BaseEntity
    {
        IQueryable GetAll(bool isTracking);
        IQueryable GetAllWhere(Expression<Func<T, bool>> predicate, bool isTracking, params string[] includes);
        Task<T> GetByIdAsync(string id,  bool isTracking, params string[] includes);
        Task<T> GetWhereAsync(Expression<Func<T, bool>> predicate, bool isTracking, params string[] includes);
    }
}
