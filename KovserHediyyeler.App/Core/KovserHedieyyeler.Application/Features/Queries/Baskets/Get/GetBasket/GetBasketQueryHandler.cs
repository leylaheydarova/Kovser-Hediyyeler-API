using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Domain.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace KovserHedieyyeler.Application.Features.Queries.Baskets.Get.GetBasket
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQueryRequest, GetBasketQueryResponse>
    {
        readonly IBasketService _service;
        readonly UserManager<WebUser> _userManager;

        public GetBasketQueryHandler(IBasketService service, UserManager<WebUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        public async Task<GetBasketQueryResponse> Handle(GetBasketQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.CustomerId);
            if (user == null) throw new UserNotFoundException();
            var result = await _service.GetBasketAsync(request.CustomerId);
            return new GetBasketQueryResponse
            {
                Dto = result
            };
        }
    }
}
