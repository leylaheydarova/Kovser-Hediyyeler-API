using KovserHedieyyeler.Application.DTOs.Products.ProductComment;
using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Shops;

namespace KovserHedieyyeler.Application.DTOs.Products.Products
{
    public class ProductGetSingleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public double ProductAverageRating { get; set; }


        //Relationships
        public string DepartmentName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public ICollection<ShopGetAllDto>? ShopNames { get; set; }
        public ICollection<ProductPropertyGetAllDto> Properties { get; set; } = new List<ProductPropertyGetAllDto>();
        public ICollection<ProductImageGetDto> Images { get; set; } = new List<ProductImageGetDto>();
        public ICollection<ProductCommentGetDto> Comments { get; set; } = new List<ProductCommentGetDto>();
    }
}
