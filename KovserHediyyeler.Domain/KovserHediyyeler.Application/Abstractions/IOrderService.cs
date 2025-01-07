using KovserHediyyeler.Application.DTOs.Orders;
using KovserHediyyeler.Application.DTOs.Orders.OrderDetails;
using KovserHediyyeler.Domain.Enums;

namespace KovserHediyyeler.Application.Abstractions
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(string customerId, OrderDto orderDto); //todo: payment cancel oldugu hali da dusun
        Task<bool> ApproveOrderPaymentAsync(string customerId, PaymentStatus status, Guid OrderId, ShippingType type);
        Task<bool> CancelOrderAsync(Guid OrderId);
        Task ChangeShippingStatusAsync(Guid OrderId, ShippingStatus status);
        Task ChangeOrderStatusAsync(Guid OrderId, OrderStatus status);
        Task<List<OrderGetAllDto>> GetAllOrdersAsync(int page, int size);
        Task<List<OrderGetAllForACustomerDto>> GetAllCustomerOrdersAsync(int page, int size, string customerId);
        Task<List<OrderDetailGetAllDto>> GetAllOrderDetailsAsync(Guid orderId);
        Task<OrderGetSingleDto> GetSingleOrderAsync(Guid orderId);
    }
}
