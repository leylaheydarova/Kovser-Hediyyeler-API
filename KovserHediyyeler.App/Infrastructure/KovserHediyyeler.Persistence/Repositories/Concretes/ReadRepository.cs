using KovserHedieyyeler.Application.Exceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions;
using KovserHediyyeler.Domain.Models.BaseModels;
using KovserHediyyeler.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly KovserHediyyelerDbContext _context;

        public ReadRepository(KovserHediyyelerDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable GetAll(bool isTracking)
        {
            var query = Table.AsQueryable();
            if(isTracking == false)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public IQueryable GetAllWhere(Expression<Func<T, bool>> predicate, bool isTracking, params string[] includes)
        {
            var query = Table.Where(predicate);
            if(isTracking == false)
            {
                query = query.AsNoTracking();
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool isTracking, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (isTracking == false)
            {
                query = query.AsNoTracking();
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            T? entity = await query.FirstOrDefaultAsync(x => x.ID.ToString() == id);
            return entity;
        }

        public async Task<T> GetWhereAsync(Expression<Func<T, bool>> predicate, bool isTracking, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (isTracking == false)
            {
                query = query.AsNoTracking();
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            T? entity = await query.FirstOrDefaultAsync(predicate);
            return entity;
        }
    }
}
