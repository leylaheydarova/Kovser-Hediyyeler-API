using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Brands
{
    public record BrandGetDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
