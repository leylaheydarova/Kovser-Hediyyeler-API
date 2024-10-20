using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Permanently
{
    public class RemovePermanentlyShopCommandHandler : IRequestHandler<RemovePermanentlyShopCommandRequest, RemovePermanentlyShopCommandResponse>
    {
        public Task<RemovePermanentlyShopCommandResponse> Handle(RemovePermanentlyShopCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
