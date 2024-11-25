using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Brands.GetAll
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQueryRequest, GetAllBrandsQueryResponse>
    {
        readonly IBrandService _servivce;

        public GetAllBrandsQueryHandler(IBrandService servivce)
        {
            _servivce = servivce;
        }

        public async Task<GetAllBrandsQueryResponse> Handle(GetAllBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _servivce.GetAllAsync(request.Page, request.Size);
            return new GetAllBrandsQueryResponse
            {
                Datas = dtos,
                TotalCount = dtos.Count
            };
        }
    }
}
