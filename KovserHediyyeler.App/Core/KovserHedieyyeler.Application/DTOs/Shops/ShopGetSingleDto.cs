using KovserHedieyyeler.Application.DTOs.Employees;
using KovserHedieyyeler.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Shops
{
    public class ShopGetSingleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public ICollection<EmployeeGetDto> Employees { get; set; }
        public ICollection<ProductGetAllDto> Products { get; set; }
    }
}
