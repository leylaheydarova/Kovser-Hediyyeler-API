using KovserHedieyyeler.Application.DTOs.Brands;
using KovserHedieyyeler.Application.Repositories.Abstractions.Brands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KovserHedieyyeler.Application.Features.Queries.Brands.GetAll
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQueryRequest, GetAllBrandsQueryResponse>
    {
        private readonly IBrandReadRepository _repository;

        public GetAllBrandsQueryHandler(IBrandReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllBrandsQueryResponse> Handle(GetAllBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllWhere(x => !x.isDeleted, false);
            int TotalCount = query.Count();
            List<BrandGetDto> dtos = new List<BrandGetDto>();
            dtos = await query
                .Skip(request.Page * request.Size)  
                .Take(request.Size)                
                .Select(x => new BrandGetDto
                {
                    Id = x.ID.ToString(), 
                    Name = x.Name,
                    Image = x.Image,
                }).ToListAsync();

            return new GetAllBrandsQueryResponse { Dtos = dtos };
        }
    }
}
