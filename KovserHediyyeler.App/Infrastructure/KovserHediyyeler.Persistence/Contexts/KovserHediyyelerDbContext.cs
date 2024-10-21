using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Domain.Models.BaseModels;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Persistence.Contexts
{
    public class KovserHediyyelerDbContext:DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ColorCode> Colors { get; set; }
        public DbSet<CustomerBankCard> CustomerBankCards { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Domain.Models.File> Files { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderPayment> OrderPayments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<Promotion> Promotions {  get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<WebUser> WebUsers { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<WishListItem> WishListItems { get; set; }
        public KovserHediyyelerDbContext(DbContextOptions<KovserHediyyelerDbContext> option):base(option)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>()
                .HasOne(b => b.Customer)
                .WithOne(w => w.Basket)
                .HasForeignKey<Basket>(b => b.CustomerID);
                

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)  
                .WithMany(w => w.Orders)   
                .HasForeignKey(o => o.CustomerID);

            modelBuilder.Entity<ProductComment>()
                .HasOne(pc => pc.Customer)  
                .WithMany(w => w.ProductComments)   
                .HasForeignKey(pc => pc.CustomerID);
            modelBuilder.Entity<Order>()
                .HasOne(i => i.InvoiceFile)
                .WithOne(o => o.Order)
                .HasForeignKey<InvoiceFile>(i => i.ID);
            modelBuilder.Entity<Order>()
                .HasOne(op => op.OrderPayment)
                .WithOne(o => o.Order)
                .HasForeignKey<OrderPayment>(op => op.ID);
            modelBuilder.Entity<Department>()
                .HasMany(d => d.SocialMedias)
                .WithOne(sm => sm.Department)
                .HasForeignKey(fk => fk.DepartmentID);
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany() 
                .HasForeignKey(c => c.ParentId);
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
        public override int SaveChanges()
        {
            //Address
            var currentAddress = ChangeTracker.Entries<Address>()
                                .FirstOrDefault(e => e.Entity.IsCurrentAddress && (e.State == EntityState.Modified || e.State == EntityState.Added));

            if (currentAddress != null)
            {
                var allAddresses = Addresses.Where(ad => ad.ID != currentAddress.Entity.ID && ad.IsCurrentAddress).ToList();
                foreach (var address in allAddresses)
                {
                    address.IsCurrentAddress = false;
                }
            }

            ////ProductImage
            var mainImage = ChangeTracker.Entries<ProductImageFile>()
                                .FirstOrDefault(e => e.Entity.IsMain && (e.State == EntityState.Modified || e.State == EntityState.Added));

            if (mainImage != null)
            {
                var allImages = Set<ProductImageFile>().Where(pi => pi.ID != mainImage.Entity.ID && pi.IsMain).ToList();
                foreach (var image in allImages)
                {
                    image.IsMain = false;
                }
            }

            //CustomerbankCard
            var activeCard = ChangeTracker.Entries<CustomerBankCard>()
                    .FirstOrDefault(e => e.Entity.IsForPayment && (e.State == EntityState.Modified || e.State == EntityState.Added));

            if (activeCard != null)
            {
                var allCards = CustomerBankCards.Where(p => p.ID != activeCard.Entity.ID && p.IsForPayment).ToList();
                foreach (var card in allCards)
                {
                    card.IsForPayment = false;
                }
            }

            return base.SaveChanges();
        }


    }
}
