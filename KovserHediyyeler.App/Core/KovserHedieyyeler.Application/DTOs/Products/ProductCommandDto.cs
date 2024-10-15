using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Products
{
    public class ProductCommandDto
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
        public ICollection<ProductPropertyDto> ProductProperties { get; set; } // string propertyname + value (foreach)
        public ICollection<ProductImageDto> ProductImages { get; set; } //iformcollection images,  bool ismain
        public ICollection<Shop> Shops { get; set; } = new List<Shop>();
    }
}
