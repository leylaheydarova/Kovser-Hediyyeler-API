using KovserHediyyeler.Domain.Models;

namespace KovserHediyyeler.Application.DTOs.Orders.OrderDetails
{
    public class OrderDetailCreateDto
    {
        public double Price { get; set; }//quantity * product.price
        public double DiscountedPrice { get; set; } //quantity * product.discountedPrice
        public int Quantity { get; set; }
        public ProductColor SelectedColor { get; set; }
        public ProductSize SelectedSize { get; set; }
        //Relationships
        public Guid ProductID { get; set; }
    }
}
