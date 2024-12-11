namespace KovserHediyyeler.Application.Abstractions
{
    public interface IWishListService
    {
        Task<bool> AddItemToWishListAsync(string customerId, Guid productId);
        Task RemoveItemFromWishListAsync(string customerId, Guid productId);
    }
}
