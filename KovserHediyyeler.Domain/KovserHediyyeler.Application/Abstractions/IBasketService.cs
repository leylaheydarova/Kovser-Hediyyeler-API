using KovserHediyyeler.Application.DTOs.Baskets;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IBasketService
    {
        Task AddItemToBasketAsync(Guid productId, int count, string userId, Guid colorId, Guid sizeId);
        Task RemoveItemFromBasketAsync(Guid productId, string customerId);
        public Task UpdateItemCountAsync(Guid productId, int newCount, string customerId);
        public Task<bool> ClearBasketAsync(string customerId);

        public Task<BasketGetDto> GetBasketAsync(string customerId);
        public Task<double> GetTotalPriceAsync(string customerId);
        public Task<int> GetTotalItemCountAsync(string customerId);
        public Task SetIsSelectedTrueAsunc(List<Guid> productIDs, string customerId);
    }
}
