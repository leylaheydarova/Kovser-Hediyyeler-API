using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Domain.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace KovserHedieyyeler.Application.Features.Queries.Baskets.Get.GetBasketTotalPrice
{
    public class GetBasketTotalPriceQueryHandler : IRequestHandler<GetBasketTotalPriceQueryRequest, GetBasketTotalPriceQueryResponse>
    {
        readonly IBasketService _service;
        readonly UserManager<WebUser> _userManager;

        public GetBasketTotalPriceQueryHandler(IBasketService service, UserManager<WebUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        public async Task<GetBasketTotalPriceQueryResponse> Handle(GetBasketTotalPriceQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.CustomerId);
            if (user == null) throw new UserNotFoundException();
            var result = await _service.GetTotalPriceAsync(request.CustomerId);
            return new GetBasketTotalPriceQueryResponse
            {
                StatusCode = 200,
                TotalPrice = result
            };
        }
    }
}
