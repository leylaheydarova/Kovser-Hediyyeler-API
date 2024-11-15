using KovserHedieyyeler.Application.DTOs.Products.ProductImage;

namespace KovserHedieyyeler.Application.DTOs.Products.Products
{
    public class ProductGetAllDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double DiscountedPrice { get; set; }
        public double ProductAverageRating { get; set; }

        //Relationships
        public string DepartmentName { get; set; }
        public ProductImageGetDto Image { get; set; }
    }
}
