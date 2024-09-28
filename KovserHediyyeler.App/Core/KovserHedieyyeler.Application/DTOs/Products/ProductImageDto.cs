using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Products
{
    public record ProductImageDto
    {
        public bool IsMain { get; set; }
        public IFormFile file {  get; set; }
    }
}
