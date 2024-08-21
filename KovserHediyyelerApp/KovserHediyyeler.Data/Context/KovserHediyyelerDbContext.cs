using KovserHediyyeler.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Data.Context
{
    public class KovserHediyyelerDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public KovserHediyyelerDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
