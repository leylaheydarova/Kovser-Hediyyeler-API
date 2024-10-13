using KovserHedieyyeler.Application.DTOs.Products;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Department
{
    public class DepartmentGetAllDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoImage { get; set; }
        public string LogoImageURL { get; set; }
    }
}
