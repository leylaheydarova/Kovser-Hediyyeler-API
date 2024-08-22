using KovserHediyyeler.Core.Entities.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Core.Repositories.Abstractions
{
   public interface IWriteRepository<T>: IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        bool Delete(T entity);
        bool DeleteSoft(T entity);
        bool Update(T entity);
        Task<int> SaveAsync();
        int Save();
    }
}
