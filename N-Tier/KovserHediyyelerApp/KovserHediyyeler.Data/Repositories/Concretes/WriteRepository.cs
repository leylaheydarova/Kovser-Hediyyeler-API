using KovserHediyyeler.Core.Entities.BaseModel;
using KovserHediyyeler.Core.Repositories.Abstractions;
using KovserHediyyeler.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Data.Repositories.Concretes
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly KovserHediyyelerDbContext _context;

        public WriteRepository(KovserHediyyelerDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry entityEntry = await _context.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public bool Delete(T entity)
        {
            EntityEntry entityEntry = _context.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool DeleteSoft(T entity)
        {
            entity.isDeleted = true;
            return _context.Entry(entity).State == EntityState.Modified;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool Update(T entity)
        {
            EntityEntry entityEntry = _context.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
