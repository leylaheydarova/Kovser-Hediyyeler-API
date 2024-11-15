using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHediyyeler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Employees
{
    public class EmployeeGetDto
    {
        public string Id { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool isRemote { get; set; }

        //Relationships
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public string ShopName { get; set; }
        public AddressGetDto Address { get; set; } 
    }
}
