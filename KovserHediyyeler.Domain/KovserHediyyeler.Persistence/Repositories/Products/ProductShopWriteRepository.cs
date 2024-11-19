using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Persistence.Repositories.Products
{
    public class ProductShopWriteRepository : IProductShopWriteRepository
    {
        readonly KovserHediyyelerDbContext _context;

        public ProductShopWriteRepository(KovserHediyyelerDbContext context)
        {
            _context = context;
        }

        public async Task RemovePermanentlyProductShopAsync(string productId, string shopId)
        {

            var product = await _context.Products.Include(p => p.Shops).FirstOrDefaultAsync(p => p.ID.ToString() == productId);
            if (product == null) throw new ProductNotFoundException();

            try
            {
                var shop = product.Shops.FirstOrDefault(sh => sh.ID.ToString() == shopId);
                product.Shops.Remove(shop);
            }
            catch
            {
                throw new ShopNotFoundException();
            }


            await _context.SaveChangesAsync();
        }
    }
}
