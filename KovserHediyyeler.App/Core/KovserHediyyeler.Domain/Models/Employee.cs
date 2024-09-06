using KovserHediyyeler.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Domain.Models
{
    public class Employee:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool isRemote { get; set; }

        //Relationships
        public string DepartmentID { get; set; }
        public Department Department { get; set; }
        public string PositionID { get; set; }
        public Position Position { get; set; }
        public string? ShopID { get; set; }
        public Shop? Shop { get; set; }
        public ICollection<Address> Address { get; set; }
    }
}
