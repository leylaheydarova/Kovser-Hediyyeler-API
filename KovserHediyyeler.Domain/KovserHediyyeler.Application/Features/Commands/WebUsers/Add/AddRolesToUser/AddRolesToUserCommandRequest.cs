using MediatR;
using System.ComponentModel.DataAnnotations;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Add.AddRoleToUser
{
    public class AddRolesToUserCommandRequest : IRequest<AddRolesToUserCommandResponse>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}
