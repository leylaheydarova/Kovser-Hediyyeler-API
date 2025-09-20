namespace KovserHediyyeler.Application.Repositories.Products
{
    public interface IProductShopWriteRepository
    {
        public Task RemovePermanentlyProductShopAsync(Guid productId, Guid shopId);
    }
}
