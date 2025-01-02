using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHedieyyeler.Application.DTOs.Shops;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetSingle.GetSingleProduct
{
    public class GetSingleProductQueryHandler : IRequestHandler<GetSingleProductQueryRequest, GetSingleProductQueryResponse>
    {
        readonly IProductService _service;

        public GetSingleProductQueryHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<GetSingleProductQueryResponse> Handle(GetSingleProductQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = await _service.GetSingleProductAsync(request.Id);
            return new GetSingleProductQueryResponse
            {
                Dto = dto
            };
        }
    }
}
