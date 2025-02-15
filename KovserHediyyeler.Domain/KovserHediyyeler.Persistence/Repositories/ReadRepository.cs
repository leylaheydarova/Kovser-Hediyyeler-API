using KovserHediyyeler.Application.Repositories;
using KovserHediyyeler.Domain.Models.BaseModel;
using KovserHediyyeler.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KovserHediyyeler.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly KovserHediyyelerDbContext _context;

        public ReadRepository(KovserHediyyelerDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool isTracking)
        {
            var query = Table.AsQueryable();
            if (isTracking == false)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public IQueryable<T> GetAllWhere(Expression<Func<T, bool>> predicate, bool isTracking, params string[] includes)
        {
            var query = Table.Where(predicate);
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
            return query;
        }

        public async Task<T> GetByIdAsync(Guid id, bool isTracking, params string[] includes)
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
            T? entity = await query.FirstOrDefaultAsync(x => x.ID == id);
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
