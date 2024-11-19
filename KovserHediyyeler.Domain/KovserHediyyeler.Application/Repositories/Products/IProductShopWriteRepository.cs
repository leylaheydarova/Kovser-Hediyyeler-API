namespace KovserHediyyeler.Application.Repositories.Products
{
    public interface IProductShopWriteRepository
    {
        public Task RemovePermanentlyProductShopAsync(string productId, string shopId);
    }
}
