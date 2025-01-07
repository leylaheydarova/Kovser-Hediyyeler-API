using KovserHediyyeler.Domain.Enums;

namespace KovserHediyyeler.Application.DTOs.Orders
{
    public class OrderGetAllDto
    {
        public string Id { get; set; }
        public double DiscountedPrice { get; set; }
        public string OrderTrackingNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerPhone { get; set; }
    }
}
