using KovserHedieyyeler.Application.Repositories.Abstractions;
using KovserHediyyeler.Domain.Models.BaseModels;
using KovserHediyyeler.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Persistence.Repositories.Concretes
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
            EntityEntry entry = await _context.AddAsync(entity);
            return entry.State == EntityState.Added;
        }

        public bool DeleteTemporarily(T entity)
        {
            entity.isDeleted = true;
            return _context.Entry(entity).State == EntityState.Modified;
        }

        public bool RemovePermanently(T entity)
        {
            EntityEntry entry = _context.Remove(entity);
            return entry.State == EntityState.Deleted;
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
            EntityEntry entry = _context.Update(entity);
            return entry.State == EntityState.Modified;
        }
    }
}
