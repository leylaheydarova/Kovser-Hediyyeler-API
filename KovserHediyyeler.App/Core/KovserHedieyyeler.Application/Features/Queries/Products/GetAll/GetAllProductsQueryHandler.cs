using KovserHedieyyeler.Application.DTOs.Products;
using KovserHedieyyeler.Application.Repositories.Abstractions.Products;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetAll
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        readonly IProductReadRepository _repository;

        public GetAllProductsQueryHandler(IProductReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllWhere(x => !x.isDeleted, false, nameof(Department));
            int totalCount = query.Count();
            List<ProductGetAllDto> dtos = new List<ProductGetAllDto>();
            dtos = await query.Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(x => new ProductGetAllDto
                {
                    Id = x.ID.ToString(),
                    Name = x.Name,
                    Description = x.Description,
                    DepartmentName = x.Department.Name,
                    DiscountedPrice = x.DiscountedPrice,
                    Price = x.Price
                })
                .ToListAsync();
            return new GetAllProductsQueryResponse
            {
                Datas = dtos,
                TotalCount = totalCount
            };
        }
    }
}
