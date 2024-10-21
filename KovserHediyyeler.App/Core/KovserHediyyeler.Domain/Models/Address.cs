using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models.BaseModels;

namespace KovserHediyyeler.Domain.Models
{
    public class Address:BaseEntity
    {
        public City City { get; set; }
        public string Region { get; set; } // F.eg: "Yasamal", "Nizami", etc.
        public string Street { get; set; }
        public string Home { get; set; }
        public string? PostalCode { get; set; } // F.eg: AZ1038
        public bool IsCurrentAddress { get; set; }

        //Relationships
        public Guid? ShopID { get; set; }
        public Shop? Shop { get; set; }
        public Guid? EmployeID {  get; set; }
        public Employee? Employee { get; set; }

        //Cross-tables
        public ICollection<AddressWebUser> AddressWebUsers { get; set; } = new List<AddressWebUser>();

        public string FullAddress
        {
            get
            {
                return $"{City.ToString()} şəhəri, {Region} rayonu, {Street}, {Home}, {PostalCode}";
            }
        }

        public string GetCity
        {
            get
            {
                return City.ToString();
            }
        }

        public string GetID
        {
            get
            {
                return ID.ToString();
            }
        }
    }
}
