using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Employees
{
    public class EmployeeCommandDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool isRemote { get; set; }

        //Relationships
        public Guid DepartmentID { get; set; }
        public Guid PositionID { get; set; }
        public Guid? ShopID { get; set; }
        public ICollection<AddressCommandDto> Addresses { get; set; } = new List<AddressCommandDto>();
    }
}
