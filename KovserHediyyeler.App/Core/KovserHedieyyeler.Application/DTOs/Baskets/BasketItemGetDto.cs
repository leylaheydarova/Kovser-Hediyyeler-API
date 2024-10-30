using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Baskets
{
    public class BasketItemGetDto
    {
        public string Id { get; set; }
        public int ProductCount { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public double DiscountedPrice { get; set; }
        public string BasketID { get; set; }
    }
}
