using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Domain.Models.BaseModel;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Persistence.Contexts
{
    public class KovserHediyyelerDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ColorCode> Colors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Domain.Models.File> Files { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImageFile> ProductImagesFiles { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

        public KovserHediyyelerDbContext(DbContextOptions<KovserHediyyelerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasIndex(b => b.Name)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany()
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Department>()
                .HasIndex(d => d.Name)
                .IsUnique();

            modelBuilder.Entity<Position>()
                .HasIndex(p => p.Status)
                .IsUnique();

            modelBuilder.Entity<ColorCode>()
                .HasIndex(c => c.HexCode)
                .IsUnique();

            modelBuilder.Entity<ColorCode>()
                .HasIndex(c => c.Name)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var changedEntries = ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added || e.State == EntityState.Deleted);

            var now = DateTime.UtcNow.AddHours(4);


            foreach (var entry in changedEntries)
            {

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = now;
                }
                else if (entry.State == EntityState.Modified && entry.Entity.isDeleted == true)
                {
                    entry.Entity.DeletedAt = now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
