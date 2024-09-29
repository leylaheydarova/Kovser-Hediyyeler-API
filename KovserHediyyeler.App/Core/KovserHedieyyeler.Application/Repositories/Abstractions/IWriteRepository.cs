using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Repositories.Abstractions
{
    public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync (T entity);
        bool DeleteTemporarily(T entity);
        bool RemovePermanently(T entity);
        bool Update(T entity);
        Task<int> SaveAsync();
        int Save();
    }
}
