using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Baskets.ClearBasket
{
    public class ClearBasketCommandHandler : IRequestHandler<ClearBasketCommandRequest, ClearBasketCommandResponse>
    {
        readonly IBasketService _service;

        public ClearBasketCommandHandler(IBasketService service)
        {
            _service = service;
        }

        public async Task<ClearBasketCommandResponse> Handle(ClearBasketCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.CustomerId == null) throw new BadRequestException();
            await _service.ClearBasketAsync(request.CustomerId);
            return new ClearBasketCommandResponse
            {
                Message = "Səbət uğurla təmizlənmişdir!"
            };
        }
    }
}
