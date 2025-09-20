namespace KovserHediyyeler.Application.Abstractions.Products
{
    public interface IProductDeleteService
    {
        public Task RemovePermanentlyProductAsync(Guid id);
        public Task RemovePermanentlyProductImageFileAsync(Guid id);
        public Task RemovePermanentlyProductPropertyAsync(Guid id);
        public Task RemovePermanentlyProductShopAsync(Guid prodcutId, Guid shopId);
        public Task RemovePermanentlyProductColorAsync(Guid id);
        public Task RemovePermanentlyProductSizeAsync(Guid id);
        public Task DeleteTemporarilyProductAsync(Guid id);
        public Task RecoverProductDataAsync(Guid id);

    }
}
