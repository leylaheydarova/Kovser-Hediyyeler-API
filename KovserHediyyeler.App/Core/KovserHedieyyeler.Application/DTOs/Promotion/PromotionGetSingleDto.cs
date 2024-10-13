using KovserHedieyyeler.Application.DTOs.Categories;
using KovserHedieyyeler.Application.DTOs.Department;
using KovserHedieyyeler.Application.DTOs.Products;
using KovserHediyyeler.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Promotion
{
    public class PromotionGetSingleDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public string DiscountPersentage { get; set; }
        public double? DiscountedPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public ICollection<ProductGetAllDto> Products { get; set; }
        public ICollection<DepartmentGetAllDto> DepartmentNames { get; set; }
        public ICollection<CategoryGetDto> CategoryNames { get; set; }
    }
}
