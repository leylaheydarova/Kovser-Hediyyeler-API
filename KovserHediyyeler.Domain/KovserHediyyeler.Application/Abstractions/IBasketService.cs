namespace KovserHediyyeler.Application.Abstractions
{
    public interface IBasketService
    {
        Task AddItemToBasketAsync(Guid productId, int count, string userId);
        Task RemoveItemFromBasketAsync(Guid productId, string customerId);

    }
}
