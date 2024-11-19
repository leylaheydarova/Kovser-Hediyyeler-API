using KovserHedieyyeler.Application.DTOs.Brands;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Repositories.Brands;
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
            int totalCount = query.Count();
            List<BrandGetDto> dtos = new List<BrandGetDto>();
            dtos = await query
                .Select(x => new BrandGetDto
                {
                    Id = x.ID.ToString(),
                    Name = x.Name,
                    Image = x.Image != null ? x.Image : ConstantPaths.DefaultImage,
                    ImageURL = x.Image != null ? x.ImageURL : ConstantPaths.DefaultImageURL
                })
                .OrderBy(b => b.Name)
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .ToListAsync();

            return new GetAllBrandsQueryResponse
            {
                Datas = dtos,
                TotalCount = totalCount
            };
        }
    }
}
