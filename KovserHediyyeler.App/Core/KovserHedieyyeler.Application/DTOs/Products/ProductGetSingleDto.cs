using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Products
{
    public record ProductGetSingleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        
        //Relationships
        public string DepartmentName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string ShopName { get; set; }
        public ICollection<ProductPropertyDto> Properties {  get; set; } = new List<ProductPropertyDto>();
        public ICollection<ProductImageDto> Images { get; set; } = new List<ProductImageDto>();
    }
}
