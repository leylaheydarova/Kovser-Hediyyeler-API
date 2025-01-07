using KovserHediyyeler.Domain.Enums;

namespace KovserHediyyeler.Application.DTOs.Orders
{
    public class OrderGetAllForACustomerDto
    {
        public string Id { get; set; }
        public double DiscountedPrice { get; set; }
        public string OrderTrackingNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<string> ImageNames { get; set; } //product images (isMain true)
        public ICollection<string> ImageURLs { get; set; } //product images (isMain true)
    }
}
