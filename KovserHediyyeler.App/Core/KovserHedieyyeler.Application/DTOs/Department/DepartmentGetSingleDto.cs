using KovserHedieyyeler.Application.DTOs.SocialMedias;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Department
{
    public record DepartmentGetSingleDto
    {
        public string Id { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public IFormFile file { get; set; }
        public ICollection<SocialMediaDto> SocialMedias { get; set;}
    }
}
