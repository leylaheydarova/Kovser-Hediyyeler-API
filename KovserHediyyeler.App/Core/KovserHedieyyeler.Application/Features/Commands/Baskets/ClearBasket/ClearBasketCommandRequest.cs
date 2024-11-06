using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Baskets.ClearBasket
{
    public class ClearBasketCommandRequest:IRequest<ClearBasketCommandResponse>
    {
        public string CustomerId { get; set; }
    }
}
