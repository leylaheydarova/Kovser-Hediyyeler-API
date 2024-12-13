using KovserHediyyeler.Domain.Enums;

namespace KovserHediyyeler.Application.DTOs.Orders
{
    public class OrderDto
    {
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Currency { get; set; }
        public ShippingType ShippingType { get; set; }
    }
}
