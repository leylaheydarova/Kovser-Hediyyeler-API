using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Promotion
{
    public class PromotionGetAllDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public string DiscountPersentage { get; set; }
        public double? DiscountedPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
