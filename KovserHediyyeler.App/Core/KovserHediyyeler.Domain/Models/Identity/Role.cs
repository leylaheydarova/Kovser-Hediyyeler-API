using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace KovserHediyyeler.Domain.Models.Identity
{
    public class Role : IdentityRole<string>
    {
        public ICollection<Endpoint> Endpoints { get; set; }
        [Key]
        public override string Id { get => base.Id; set => base.Id = value; }
    }
}
