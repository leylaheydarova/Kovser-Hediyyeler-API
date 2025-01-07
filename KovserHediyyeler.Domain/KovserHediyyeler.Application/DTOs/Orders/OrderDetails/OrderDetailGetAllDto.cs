namespace KovserHediyyeler.Application.DTOs.Orders.OrderDetails
{
    public class OrderDetailGetAllDto
    {
        public string Id { get; set; }
        public double Price { get; set; }//quantity * product.price
        public int Quantity { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
