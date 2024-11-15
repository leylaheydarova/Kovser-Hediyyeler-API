using KovserHedieyyeler.Application.DTOs.Addresses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Create.CreateShopAddress
{
    public class CreateShopAddressCommandRequest:CreateCommandRequest<AddressCommandDto>, IRequest<CreateShopAddressCommandResponse>
    {
        public string ShopId {  get; set; }
    }
}
