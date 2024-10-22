using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Shops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Products
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
        public ICollection<ShopGetAllDto> ShopNames { get; set; }
        public ICollection<ProductPropertyGetDto> Properties {  get; set; } = new List<ProductPropertyGetDto>();
        public ICollection<ProductImageGetDto> Images { get; set; } = new List<ProductImageGetDto>();
        public ICollection<ProductCommentGetDto> Comments { get; set; } = new List<ProductCommentGetDto>();
    }
}
