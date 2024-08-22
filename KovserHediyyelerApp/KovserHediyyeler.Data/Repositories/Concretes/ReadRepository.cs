using KovserHediyyeler.Core.Entities;
using KovserHediyyeler.Core.Entities.BaseModel;
using KovserHediyyeler.Core.Repositories.Abstractions;
using KovserHediyyeler.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Data.Repositories.Concretes
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly KovserHediyyelerDbContext _context;

        public ReadRepository(KovserHediyyelerDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); 

        public IQueryable<T> GetAll(bool isTracking = true)
        {
            var query = Table;
            if (!isTracking)
            {
                query.AsNoTracking();
            }
            return query;
        }

        public IQueryable<T> GetAllWhere(Expression<Func<T, bool>> predicate, bool isTracking = true, params string[] includes)
        {
            var query = Table.Where(predicate);
            if (!isTracking)
            {
                query.AsNoTracking();
            }
            if(includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }

        public async Task<T?> GetByIdAsync(string id, bool isTracking = true, params string[] includes)
        {
            var query = Table.AsQueryable();
            if(!isTracking)
            {
                query.AsNoTracking();
            }
            if(includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }
            T? entity = await query.FirstOrDefaultAsync(x => x.ID == Guid.Parse(id));
            return entity;
        }

        public async Task<T?> GetWhere(Expression<Func<T, bool>> predicate, bool isTracking = true, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (!isTracking)
            {
                query.AsNoTracking();
            }
            if(includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }
            T? entity = await query.FirstOrDefaultAsync(predicate);
            return entity;
        }
    }
}
