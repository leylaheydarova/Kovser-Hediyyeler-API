using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Permanently.RemoveShopAddress
{
    public class RemovePermanentlyShopAddressCommandRequest:DeleteCommandRequest, IRequest<RemovePermanentlyShopAddressCommandResponse>
    {
    }
}
