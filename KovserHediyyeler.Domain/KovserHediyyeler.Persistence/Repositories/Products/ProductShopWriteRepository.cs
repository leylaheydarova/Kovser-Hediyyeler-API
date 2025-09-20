using KovserHediyyeler.Application.Exceptions.BadRequestExceptions;
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

        public async Task RemovePermanentlyProductShopAsync(Guid productId, Guid shopId)
        {

            var productShop = await _context.Set<Dictionary<string, object>>("ProductShop")
                                    .FirstOrDefaultAsync(ps =>
                                        ps["ProductID"].ToString() == productId.ToString() &&
                                        ps["ShopID"].ToString() == shopId.ToString());

            if (productShop == null)
                throw new InvalidInputException("əlaqə");

            // Əlaqəni silirik.
            _context.Set<Dictionary<string, object>>("ProductShop").Remove(productShop);

            // Dəyişiklikləri saxlamaq.
            await _context.SaveChangesAsync();
        }
    }
}
