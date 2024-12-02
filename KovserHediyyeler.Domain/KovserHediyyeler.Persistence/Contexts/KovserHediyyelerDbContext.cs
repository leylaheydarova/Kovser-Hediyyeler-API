using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Domain.Models.BaseModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Persistence.Contexts
{
    public class KovserHediyyelerDbContext : IdentityDbContext
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

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Shops)
                .WithMany(sh => sh.Products)
                .UsingEntity<Dictionary<string, object>>(
                "ProductShop",
                sh => sh.HasOne<Shop>().WithMany().HasForeignKey("ShopID"),
                p => p.HasOne<Product>().WithMany().HasForeignKey("ProductID"));

            modelBuilder.Entity<Address>()
                 .HasMany(a => a.WebUsers)
                 .WithMany(w => w.Addresses)
                 .UsingEntity<Dictionary<string, object>>(
             "AddressWebUser",
             j => j
                 .HasOne<WebUser>()
                 .WithMany()
                 .HasForeignKey("WebUsersId")
                 .HasConstraintName("FK_AddressWebUser_AspNetUsers_WebUsersId")
                 .OnDelete(DeleteBehavior.Cascade),
             j => j
                 .HasOne<Address>()
                 .WithMany()
                 .HasForeignKey("AddressesID")
                 .HasConstraintName("FK_AddressWebUser_Addresses_AddressesID")
                 .OnDelete(DeleteBehavior.Cascade));


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

            //One column can take only one true value
            //Address
            var currentAddress = ChangeTracker.Entries<Address>()
                                .FirstOrDefault(e => e.Entity.IsCurrentAddress &&
                                 (e.State == EntityState.Modified || e.State == EntityState.Added));

            if (currentAddress != null)
            {
                var shopId = currentAddress.Entity.ShopID;
                var employeeId = currentAddress.Entity.EmployeeID;

                // Shop üçün digər cari ünvanları false et
                if (shopId.HasValue)
                {
                    var shopAddresses = Set<Address>()
                        .Where(a => a.ShopID == shopId && a.ID != currentAddress.Entity.ID && a.IsCurrentAddress)
                        .ToList();

                    foreach (var address in shopAddresses)
                    {
                        address.IsCurrentAddress = false;
                    }
                }

                // Employee üçün digər cari ünvanları false et
                if (employeeId.HasValue)
                {
                    var employeeAddresses = Set<Address>()
                        .Where(a => a.EmployeeID == employeeId && a.ID != currentAddress.Entity.ID && a.IsCurrentAddress)
                        .ToList();

                    foreach (var address in employeeAddresses)
                    {
                        address.IsCurrentAddress = false;
                    }
                }
            }


            ////ProductImage
            var mainImage = ChangeTracker.Entries<ProductImageFile>()
                            .FirstOrDefault(e => e.Entity.IsMain &&
                          (e.State == EntityState.Modified || e.State == EntityState.Added));

            if (mainImage != null)
            {
                // Yalnız həmin məhsula aid şəkilləri tapırıq
                var productId = mainImage.Entity.ProductID; // Mövcud ProductID
                var allImages = Set<ProductImageFile>()
                    .Where(pi => pi.ProductID == productId && pi.ID != mainImage.Entity.ID && pi.IsMain)
                    .ToList();

                foreach (var image in allImages)
                {
                    image.IsMain = false;
                }
            }

            // ProductImage silindiyi zaman sonuncu şəkilin "IsMain" təyin edilməsini təmin et
            var deletedImage = ChangeTracker.Entries<ProductImageFile>()
                                            .FirstOrDefault(e => e.State == EntityState.Deleted && e.Entity.IsMain);

            if (deletedImage != null)
            {
                // Şəkil silindikdən sonra həmin məhsul üçün sonuncu şəkil "IsMain" olaraq təyin edilir
                var productId = deletedImage.Entity.ProductID;
                var remainingImages = Set<ProductImageFile>()
                    .Where(pi => pi.ProductID == productId && pi.IsMain == false)
                    .OrderByDescending(pi => pi.CreatedAt) // Sonuncu əlavə olunan şəkil
                    .FirstOrDefault();

                if (remainingImages != null)
                {
                    remainingImages.IsMain = true;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
