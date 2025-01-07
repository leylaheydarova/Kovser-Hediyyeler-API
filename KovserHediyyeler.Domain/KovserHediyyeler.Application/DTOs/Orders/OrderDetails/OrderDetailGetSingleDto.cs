namespace KovserHediyyeler.Application.DTOs.Orders.OrderDetails
{
    public class OrderDetailGetSingleDto
    {
        public string Id { get; set; }
        public double Price { get; set; }//quantity * product.price
        public int Quantity { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageName { get; set; }
        public string ProductImageURl { get; set; }
        public string ProductDescription { get; set; }
        public string ProductSize { get; set; }
        public string ProductColor { get; set; }
    }
}
