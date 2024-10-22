using KovserHediyyeler.Domain.Enums;

namespace KovserHedieyyeler.Application.DTOs.Products.Products
{
    public class ProductPutDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isSingleColour { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public DiscountPersentage DiscountPercentage { get; set; } //request int
        //Relationships
        public Guid? DepartmentID { get; set; }
        public Guid? CategoryID { get; set; }
        public Guid? BrandID { get; set; }
    }
}
