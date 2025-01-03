namespace KovserHediyyeler.Application.Abstractions.Products
{
    public interface IProductDeleteService
    {
        public Task RemovePermanentlyProductAsync(string id);
        public Task RemovePermanentlyProductImageFileAsync(string id);
        public Task RemovePermanentlyProductPropertyAsync(string id);
        public Task RemovePermanentlyProductShopAsync(string prodcutId, string shopId);
        public Task RemovePermanentlyProductColorAsync(string id);
        public Task RemovePermanentlyProductSizeAsync(string id);
        public Task DeleteTemporarilyProductAsync(string id);
        public Task RecoverProductDataAsync(string id);

    }
}
