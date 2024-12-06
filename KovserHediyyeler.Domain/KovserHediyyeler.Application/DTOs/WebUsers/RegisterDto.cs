using KovserHedieyyeler.Application.DTOs.Addresses;
using System.ComponentModel.DataAnnotations;

namespace KovserHediyyeler.Application.DTOs.WebUsers
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //public string UserName { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public AddressCommandDto Address { get; set; }
    }
}
