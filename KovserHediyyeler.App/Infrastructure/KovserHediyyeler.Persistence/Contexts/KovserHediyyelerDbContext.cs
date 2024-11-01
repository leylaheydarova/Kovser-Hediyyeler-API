using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Domain.Models.BaseModels;
using KovserHediyyeler.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Persistence.Contexts
{
    public class KovserHediyyelerDbContext:IdentityDbContext<WebUser, UserRole, string>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressWebUser> AddressWebUsers { get; set; } 
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDepartment> CategoryDepartments { get; set; }
        public DbSet<CategoryPromotion> CategoryPromotions { get; set; }
        public DbSet<ColorCode> Colors { get; set; }
        public DbSet<ColorCodeProductProperty> ColorCodeProductProperties { get; set; }
        public DbSet<CustomerBankCard> CustomerBankCards { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentPosition> DepartmentPositions { get; set; }
        public DbSet<DepartmentPromotion> DepartmentPromotions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<Endpoint> Endpoint { get; set; }
        public DbSet<Domain.Models.File> Files { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderPayment> OrderPayments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<ProductShop> ProductShops { get; set; }
        public DbSet<Promotion> Promotions {  get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<WebUser> WebUsers { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<WishListItem> WishListItems { get; set; }

        public KovserHediyyelerDbContext(DbContextOptions<KovserHediyyelerDbContext> option):base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(ad => ad.Shop)
                .WithMany(sh => sh.Addresses)
                .HasForeignKey(ad => ad.ShopID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Address>()
                .HasMany(ad => ad.AddressWebUsers)
                .WithOne(adw => adw.Address)
                .HasForeignKey(ad => ad.AddressID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Bank>()
                .HasMany(b => b.BankCards)
                .WithOne(bc => bc.Bank)
                .HasForeignKey(bc => bc.BankID)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Basket>()
                .HasMany(b => b.BasketItems)
                .WithOne(bi => bi.Basket)
                .HasForeignKey(bi => bi.BasketID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Basket>()
                .HasOne(b => b.Customer)
                .WithOne(c => c.Basket)
                .HasForeignKey<Basket>(c => c.CustomerID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Basket>()
                .HasOne(b => b.Order)
                .WithOne(o => o.Basket)
                .HasForeignKey<Order>(o => o.BasketID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BasketItem>()
                .HasOne(b => b.Product)
                .WithMany(p => p.BasketItems)
                .HasForeignKey(b => b.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany()
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Category>()
            //    .HasMany(c => c.Products)
            //    .WithOne(p => p.Category)
            //    .HasForeignKey(p => p.CategoryID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Category>()
            //    .HasMany(c => c.CategoryDepartments)
            //    .WithOne(cd => cd.Category)
            //    .HasForeignKey(cd => cd.CategoryID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Category>()
            //    .HasMany(c => c.CategoryPromotions)
            //    .WithOne(cp => cp.Category)
            //    .HasForeignKey(cp => cp.CategoryID)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ColorCode>()
                .HasMany(cc => cc.ColorCodeProductProperties)
                .WithOne(cp => cp.ColorCode)
                .HasForeignKey(cp => cp.ColorCodeID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CustomerBankCard>()
                .HasOne(cbc => cbc.Customer)
                .WithMany(c => c.BankCards)
                .HasForeignKey(cbc => cbc.CustomerID)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Department>()
            //   .HasMany(d => d.SocialMedias)
            //   .WithOne(sm => sm.Department)
            //   .HasForeignKey(fk => fk.DepartmentID)
            //   .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Department>()
            //    .HasMany(d => d.Employees)
            //    .WithOne(e => e.Department)
            //    .HasForeignKey(e => e.DepartmentID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Department>()
            //    .HasMany(d => d.Products)
            //    .WithOne(p => p.Department)
            //    .HasForeignKey(p => p.DepartmentID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Department>()
            //    .HasMany(d => d.CategoryDepartments)
            //    .WithOne(cd => cd.Department)
            //    .HasForeignKey(cd => cd.DepartmentID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Department>()
            //    .HasMany(d => d.DepartmentPositions)
            //    .WithOne(dp => dp.Department)
            //    .HasForeignKey(dp => dp.DepartmentID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Department>()
            //    .HasMany(d => d.DepartmentPromotions)
            //    .WithOne(dp => dp.Department)
            //    .HasForeignKey(dp => dp.DepartmentID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Employee>()
            //    .HasMany(e => e.Addresses)
            //    .WithOne(ad => ad.Employee)
            //    .HasForeignKey(ad => ad.EmployeID)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionID)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Shop)
                .WithMany(sh => sh.Employees)
                .HasForeignKey(e => e.ShopID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<InvoiceFile>()
                .HasOne(inf => inf.Order)
                .WithOne(o => o.InvoiceFile)
                .HasForeignKey<Order>(o => o.InvoiceFileId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.OrderPayment)
                .WithOne(op => op.Order)
                .HasForeignKey<Order>(o => o.OrderPaymentID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(w => w.Orders)
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Shipping)
                .WithMany(sh => sh.Orders)
                .HasForeignKey(o => o.ShippingID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Shop)
                .WithMany(sh => sh.Orders)
                .HasForeignKey(o => o.ShopID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Details)
                .WithOne(d => d.Order)
                .HasForeignKey(d => d.OrderID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Position>()
                .HasMany(p => p.DepartmentPositions)
                .WithOne(dp => dp.Position)
                .HasForeignKey(dp => dp.PositionID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Position>()
                .HasMany(p => p.Employees)
                .WithOne(e => e.Position)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Promotion)
                .WithMany(pr => pr.Products)
                .HasForeignKey(p => p.PromotionID)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Product>()
            //    .HasMany(p => p.Properties)
            //    .WithOne(pp => pp.Product)
            //    .HasForeignKey(pp => pp.ProductID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Product>()
            //    .HasMany(p => p.Images)
            //    .WithOne(pi => pi.Product)
            //    .HasForeignKey(pi => pi.ProductID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Product>()
            //    .HasMany(p => p.Comments)
            //    .WithOne(pc => pc.Product)
            //    .HasForeignKey(pc => pc.ProductID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Product>()
            //    .HasMany(p => p.WishListItems)
            //    .WithOne(wli => wli.Product)
            //    .HasForeignKey(wli => wli.ProductID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Product>()
            //    .HasMany(p => p.ProductShops)
            //    .WithOne(psh => psh.Product)
            //    .HasForeignKey(psh => psh.ProductID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<ProductComment>()
            //    .HasOne(pc => pc.Customer)
            //    .WithMany(c => c.ProductComments)
            //    .HasForeignKey(pc => pc.CustomerID)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<ProductProperty>()
            //    .HasMany(pr => pr.ColorCodeProductProperties)
            //    .WithOne(cp => cp.ProductProperty)
            //    .HasForeignKey(cp => cp.ProductPropertyID)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Promotion>()
                .HasMany(p => p.DepartmentPromotions)
                .WithOne(dp => dp.Promotion)
                .HasForeignKey(dp => dp.PromotionID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Promotion>()
                .HasMany(p => p.CategoryPromotions)
                .WithOne(cp => cp.Promotion)
                .HasForeignKey(cp => cp.PromotionID)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Shop>()
            //    .HasMany(sh => sh.ProductShops)
            //    .WithOne(psh => psh.Shop)
            //    .HasForeignKey(psh => psh.ShopID)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WebUser>()
                .HasOne(w => w.WishList)
                .WithOne(wl => wl.Customer)
                .HasForeignKey<WishList>(w => w.CustomerID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WebUser>()
                .HasMany(wu => wu.AddressWebUsers)
                .WithOne(aw => aw.WebUser)
                .HasForeignKey(aw => aw.WebUserID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WishList>()
                .HasMany(wl => wl.ListItems)
                .WithOne(wli => wli.List)
                .HasForeignKey(wli => wli.WishListID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<IdentityUserToken<Guid>>()
                .HasKey(x => new { x.UserId, x.LoginProvider, x.Name });

            modelBuilder.Entity<IdentityUserLogin<Guid>>()
                .HasKey(x => new { x.LoginProvider, x.ProviderKey });

            modelBuilder.Entity<IdentityUserClaim<Guid>>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<IdentityUserRole<Guid>>()
                .HasKey(x => new { x.UserId, x.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasNoKey();

            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();

            //modelBuilder.Entity<Endpoint>()
            //    .HasMany(e => e.Roles)
            //    .WithMany(r => r.Endpoints)
            //    .
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

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
