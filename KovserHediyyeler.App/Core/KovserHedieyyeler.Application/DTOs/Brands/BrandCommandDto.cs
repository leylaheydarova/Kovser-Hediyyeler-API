using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Brands
{
    public record BrandCommandDto
    {
        public string Name { get; set; }
        public IFormFile? file { get; set; }
    }
}
