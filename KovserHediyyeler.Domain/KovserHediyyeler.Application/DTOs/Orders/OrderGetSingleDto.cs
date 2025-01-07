using KovserHediyyeler.Application.DTOs.Orders.OrderDetails;

namespace KovserHediyyeler.Application.DTOs.Orders
{
    public class OrderGetSingleDto
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountedPrice { get; set; }
        public double SavingAmount { get; set; }
        //public double? TaxAmount { get; set; } //edv
        public string OrderTrackingNumber { get; set; }
        public string OrderPaymentType { get; set; }
        public string OrderPaymentStatus { get; set; }
        public string OrderPaymentDate { get; set; }
        public string OrderStatus { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string ShippingType { get; set; }
        public string ShippingStatus { get; set; }
        public string ShippingAddress { get; set; }
        public ICollection<OrderDetailGetSingleDto> Details { get; set; } = new List<OrderDetailGetSingleDto>();
    }
}
