using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Baskets
{
    public class BasketGetDto
    {
        public string Id { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public ICollection<BasketItemGetDto> Items { get; set; }
    }
}
