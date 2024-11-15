using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHediyyeler.Application.Repositories.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetAll.GetAllProductProperties
{
    public class GetAllProductPropertiesQueryHandler : IRequestHandler<GetAllProductPropertiesQueryRequest, GetAllProductPropertiesQueryResponse>
    {
        readonly IProductPropertyReadRepository _repository;

        public GetAllProductPropertiesQueryHandler(IProductPropertyReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllProductPropertiesQueryResponse> Handle(GetAllProductPropertiesQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllWhere(x => !x.isDeleted && x.ProductID.ToString() == request.ProductId, false);
            var totalCount = query.Count();
            var dtos = new List<ProductPropertyGetAllDto>();
            dtos = await query.Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(x => new ProductPropertyGetAllDto
                {
                    Id = x.ID.ToString(),
                    Name = x.Name,
                    Value = x.Value
                }).ToListAsync();
            return new GetAllProductPropertiesQueryResponse
            {
                Datas = dtos,
                TotalCount = totalCount
            };
        }
    }
}
