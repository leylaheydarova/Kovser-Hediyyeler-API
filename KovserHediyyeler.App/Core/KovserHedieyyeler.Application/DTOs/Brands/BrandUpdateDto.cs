using KovserHedieyyeler.Application.Validation.Files;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Brands
{
    public class BrandUpdateDto
    {
        public string? Name { get; set; }
        [MaxFileSize(3)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile? file { get; set; }
    }
}
