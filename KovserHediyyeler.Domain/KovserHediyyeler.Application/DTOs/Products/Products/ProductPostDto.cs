using KovserHedieyyeler.Application.DTOs.Colors;
using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHediyyeler.Domain.Enums;

namespace KovserHedieyyeler.Application.DTOs.Products.Products
{
    public class ProductPostDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isSingleColour { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public DiscountPersentage DiscountPercentage { get; set; } //request int
        //Relationships
        public Guid DepartmentID { get; set; }
        public Guid CategoryID { get; set; }
        public Guid? BrandID { get; set; }

        public ICollection<Guid> ShopIDs { get; set; } = new List<Guid>();
        public ICollection<ProductPropertyCommandDto> ProductProperties { get; set; } = new List<ProductPropertyCommandDto>();
        public ICollection<ProductImageCommandDto> ProductImages { get; set; } = new List<ProductImageCommandDto>();
        public ICollection<ColorDto> Colors { get; set; } = new List<ColorDto>();
    }
}
