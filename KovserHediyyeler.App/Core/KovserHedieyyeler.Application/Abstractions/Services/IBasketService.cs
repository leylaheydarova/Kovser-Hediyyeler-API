using KovserHedieyyeler.Application.DTOs.Baskets;

namespace KovserHedieyyeler.Application.Abstractions.Services
{
    public interface IBasketService
    {
        public Task AddItemToBasketAsync(Guid productId, int count);
        public Task RemoveItemFromBasketAsync(Guid productId, string customerId);
        public Task RemoveItemFromBasketAddWishListAsync(Guid productId, string customerId);
        public Task UpdateItemCountAsync(Guid productId, int newCount, string customerId);
        public Task ClearBasketAsync(string customerId);

        public Task<BasketGetDto> GetBasketAsync(string customerId);
        public Task<double> GetTotalPriceAsync(string customerId);
        public Task<int> GetTotalItemCountAsync(string customerId);
    }
}
