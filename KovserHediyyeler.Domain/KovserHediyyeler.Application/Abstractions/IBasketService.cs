namespace KovserHediyyeler.Application.Abstractions
{
    public interface IBasketService
    {
        Task AddItemToBasketAsync(Guid productId, int count);
    }
}
