using KovserHediyyeler.Domain.Models.BaseModels;
using KovserHediyyeler.Domain.Models.Identity;

namespace KovserHediyyeler.Domain.Models
{
    public class AddressWebUser:BaseEntity
    {
        public Guid AddressID {  get; set; }
        public Address Address { get; set; }
        public Guid WebUserID { get; set; }
        public WebUser WebUser { get; set; }
    }
}
