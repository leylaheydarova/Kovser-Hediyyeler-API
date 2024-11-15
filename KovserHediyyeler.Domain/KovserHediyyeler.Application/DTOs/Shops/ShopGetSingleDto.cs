using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHediyyeler.Application.DTOs.Employees;

namespace KovserHedieyyeler.Application.DTOs.Shops
{
    public class ShopGetSingleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public AddressGetDto Address { get; set; }
        public ICollection<EmployeeGetAllDto> Employees { get; set; } = new List<EmployeeGetAllDto>();
        //public ICollection<ProductGetAllDto> Products { get; set; } = new List<ProductGetAllDto>();
    }
}
