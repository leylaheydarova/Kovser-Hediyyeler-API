using KovserHedieyyeler.Application.DTOs.Addresses;


namespace KovserHedieyyeler.Application.DTOs.Shops
{
    public class ShopCommandDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public ICollection<AddressCommandDto> Addresses {  get; set; }
    }
}
