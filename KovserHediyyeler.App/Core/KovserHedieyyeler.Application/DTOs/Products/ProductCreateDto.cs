using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Products
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isSingleColour { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        //Relationships
        public Guid DepartmentID { get; set; }
        public Guid CategoryID { get; set; }
        public Guid? BrandID { get; set; }
        public Guid? DiscountID { get; set; }
        public ICollection<ProductProperty> Properties { get; set; } = new List<ProductProperty>();
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<Shop> Shops { get; set; } = new List<Shop>();
    }
}
