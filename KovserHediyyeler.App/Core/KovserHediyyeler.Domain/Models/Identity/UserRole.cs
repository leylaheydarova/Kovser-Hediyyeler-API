using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KovserHediyyeler.Domain.Models.Identity
{
    public class UserRole : IdentityRole<string>
    {
        //public ICollection<Endpoint> Endpoints { get; set; }
        //[Key]
        //public string ID { get; set; }
    }
}
