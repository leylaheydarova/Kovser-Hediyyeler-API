using KovserHedieyyeler.Application.DTOs.SocialMedias;
using KovserHedieyyeler.Application.Validation.Files;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Department
{
    public record DepartmentCommandDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        [MaxFileSize(3)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile file { get; set; }
        public ICollection<SocialMediaDto> SocialMedias { get; set; }
    }
}
