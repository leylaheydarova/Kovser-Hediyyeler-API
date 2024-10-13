using KovserHedieyyeler.Application.DTOs.Products;
using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Promotion
{
    public class PromotionCommandDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public DiscountPersentage? DiscountPersentage { get; set; }
        public double? DiscountedPrice { get; set; }
        public ICollection<ProductGetAllDto> Products { get; set; } = new List<ProductGetAllDto>();
        public DateTime? StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public ICollection<Guid> DepartmentIDs { get;  set; } = new List<Guid>();
        public ICollection<Guid> CategoryIDs { get; set; } = new List<Guid>();
        
    }
}
