using KovserHediyyeler.Application.DTOs.Orders;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(string customerId, OrderDto paymentDto);
    }
}
