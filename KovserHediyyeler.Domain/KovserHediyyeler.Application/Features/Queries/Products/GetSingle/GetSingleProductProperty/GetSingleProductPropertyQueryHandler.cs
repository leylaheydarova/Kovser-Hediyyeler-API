using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
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
            var property = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, false);
            if (property == null) throw new ProductPropertyNotFoundException();
            var dto = new ProductPropertyGetDto
            {
                Id = property.ID.ToString(),
                Name = property.Name,
                Value = property.Value
            };

            return new GetSingleProductPropertyQueryResponse
            {
                Dto = dto
            };
        }
    }
}
