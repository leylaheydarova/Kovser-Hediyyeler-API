using KovserHediyyeler.Application.DTOs.Orders;
using KovserHediyyeler.Domain.Enums;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(string customerId, OrderDto orderDto); //todo: payment cancel oldugu hali da dusun
        Task<bool> ApproveOrderPaymentAsync(string customerId, PaymentStatus status, Guid OrderId, ShippingType type);
    }
}
