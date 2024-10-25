using KovserHediyyeler.Domain.Models.BaseModels;
using KovserHediyyeler.Domain.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class AddressWebUser:BaseEntity
    {
        public Guid AddressID {  get; set; }
        public Address Address { get; set; }
        [ForeignKey(nameof(WebUser))]
        public string WebUserID { get; set; }
        public WebUser WebUser { get; set; }
    }
}
