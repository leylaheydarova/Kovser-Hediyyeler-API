using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KovserHedieyyeler.Application.DTOs.Products.ProductImage;

namespace KovserHedieyyeler.Application.DTOs.Products
{
    public class ProductGetAllDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double DiscountedPrice { get; set; }
        public string ProductAverageRating { get; set; }

        //Relationships
        public string DepartmentName { get; set; }
        public ProductImagePostDto Image { get; set; }
    }
}
