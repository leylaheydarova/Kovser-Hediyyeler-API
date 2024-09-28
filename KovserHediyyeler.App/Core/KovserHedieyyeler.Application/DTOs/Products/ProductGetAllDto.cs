using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Products
{
    public record ProductGetAllDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double DiscountedPrice { get; set; }

        //Relationships
        public string DepartmentName { get; set; }
        public string CategoryName { get; set; }
        public ProductImageDto Image { get; set; }
    }
}
