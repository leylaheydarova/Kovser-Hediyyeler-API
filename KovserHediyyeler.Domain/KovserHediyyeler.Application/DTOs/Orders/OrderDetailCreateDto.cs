namespace KovserHediyyeler.Application.DTOs.Orders
{
    public class OrderDetailCreateDto
    {
        public double Price { get; set; }//quantity * product.price
        public double DiscountedPrice { get; set; } //quantity * product.discountedPrice
        public int Quantity { get; set; }
        //Relationships
        public Guid ProductID { get; set; }
    }
}
