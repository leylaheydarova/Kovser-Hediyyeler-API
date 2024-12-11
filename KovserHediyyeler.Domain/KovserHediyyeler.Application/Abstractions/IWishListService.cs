using KovserHediyyeler.Application.DTOs.WishLists;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IWishListService
    {
        Task<bool> AddItemToWishListAsync(string customerId, Guid productId);
        Task<bool> RemoveItemFromWishListAsync(string customerId, Guid productId);
        Task<WishListGetDto> GetWishListAsync(string customerId);
    }
}
