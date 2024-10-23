using KovserHedieyyeler.Application.DTOs.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.WebUsers.Users
{
    public class WebUserGetSingleDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //public string UserName { get; set; }
        public AddressCommandDto Address { get; set; }
    }
}
