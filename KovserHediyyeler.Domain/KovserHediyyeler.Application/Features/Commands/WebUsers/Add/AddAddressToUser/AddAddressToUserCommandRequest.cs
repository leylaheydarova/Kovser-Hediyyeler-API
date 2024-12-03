using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Add.AddAddressToUser
{
    public class AddAddressToUserCommandRequest : CreateCommandRequest<AddressCommandDto>, IRequest<AddAddressToUserCommandResponse>
    {
        public string UserIdOrEmail { get; set; }
    }
}
