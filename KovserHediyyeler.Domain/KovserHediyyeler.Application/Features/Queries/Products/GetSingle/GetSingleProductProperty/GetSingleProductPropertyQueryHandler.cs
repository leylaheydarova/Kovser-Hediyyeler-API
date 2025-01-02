using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Products;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetSingle.GetSingleProductProperty
{
    public class GetSingleProductPropertyQueryHandler : IRequestHandler<GetSingleProductPropertyQueryRequest, GetSingleProductPropertyQueryResponse>
    {
        readonly IProductPropertyReadRepository _repository;

        public GetSingleProductPropertyQueryHandler(IProductPropertyReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetSingleProductPropertyQueryResponse> Handle(GetSingleProductPropertyQueryRequest request, CancellationToken cancellationToken)
        {
            

            return new GetSingleProductPropertyQueryResponse
            {
                Dto = dto
            };
        }
    }
}
