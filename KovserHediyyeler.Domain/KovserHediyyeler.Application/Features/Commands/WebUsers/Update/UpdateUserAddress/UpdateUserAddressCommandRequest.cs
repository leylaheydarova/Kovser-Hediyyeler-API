using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHedieyyeler.Application.Features.Commands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.WebUsers.Update.UpdateUserAddress
{
    public class UpdateUserAddressCommandRequest : UpdateCommandRequest<AddressUpdateDto>, IRequest<UpdateUserAddressCommandResponse>
    {
        public string UserIdOrEmail { get; set; }
    }
}
