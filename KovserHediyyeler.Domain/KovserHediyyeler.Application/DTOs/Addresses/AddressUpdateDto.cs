using KovserHediyyeler.Domain.Enums;

namespace KovserHedieyyeler.Application.DTOs.Addresses
{
    public class AddressUpdateDto
    {
        public City? City { get; set; }
        public string? Region { get; set; } // F.eg: "Yasamal", "Nizami", etc.
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? Home { get; set; }
        public string? PostalCode { get; set; } // F.eg: AZ1038
        public bool? IsCurrentAddress { get; set; }
    }
}
