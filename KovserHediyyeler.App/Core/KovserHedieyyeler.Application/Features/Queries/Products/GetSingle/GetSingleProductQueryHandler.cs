using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Products;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Products;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetSingle
{
    public class GetSingleProductQueryHandler : IRequestHandler<GetSingleProductQueryRequest, GetSingleProductQueryResponse>
    {
        readonly IProductReadRepository _repository;
        readonly IMapper _mapper;

        public GetSingleProductQueryHandler(IProductReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetSingleProductQueryResponse> Handle(GetSingleProductQueryRequest request, CancellationToken cancellationToken)
        {
            Product product = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), false, 
                nameof(Category), 
                nameof(Department), 
                nameof(ColorCodeProductProperty), 
                nameof(ProductImageFile), 
                nameof(ProductComment),
                nameof(ColorCode));
            if (product == null)
            {
                throw new ProductNotFoundException();
            }
            ProductGetSingleDto dto = _mapper.Map<ProductGetSingleDto>(product);
            return new GetSingleProductQueryResponse
            {
                Dto = dto
            };
        }
    }
}
