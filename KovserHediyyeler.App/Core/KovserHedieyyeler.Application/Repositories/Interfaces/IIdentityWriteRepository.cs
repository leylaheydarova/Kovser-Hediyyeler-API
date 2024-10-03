using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Repositories.Abstractions
{
    public interface IIdentityWriteRepository<T>:IIdentityRepository<T> where T: IdentityUser<Guid>
    {
        Task<bool> AddAsync(T entity);
        bool RemovePermanently(T entity);
        bool Update(T entity);
        Task<int> SaveAsync();
        int Save();
    }
}
