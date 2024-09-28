using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Shops
{
    public record ShopCommandDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
    }
}
