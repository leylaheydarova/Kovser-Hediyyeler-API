using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Domain.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace KovserHedieyyeler.Application.Features.Queries.Baskets.Get.GetBasketCount
{
    public class GetBasketCountQueryHandler : IRequestHandler<GetBasketCountQueryRequest, GetBasketCountQueryResponse>
    {
        readonly IBasketService _service;
        readonly UserManager<WebUser> _userManager;

        public GetBasketCountQueryHandler(IBasketService service, UserManager<WebUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        public async Task<GetBasketCountQueryResponse> Handle(GetBasketCountQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.CustomerId);
            if (user == null) throw new UserNotFoundException();
            var result = await _service.GetTotalItemCountAsync(request.CustomerId);
            return new GetBasketCountQueryResponse
            {
                StatusCode = 200,
                Count = result
            };
        }
    }
}
