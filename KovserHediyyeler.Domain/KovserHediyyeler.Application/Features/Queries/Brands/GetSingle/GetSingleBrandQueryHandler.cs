using KovserHedieyyeler.Application.DTOs.Brands;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Brands.GetSingle
{
    public class GetSingleBrandQueryHandler : IRequestHandler<GetSingleBrandQueryRequest, GetSingleBrandQueryResponse>
    {
        readonly IBrandReadRepository _repository;

        public GetSingleBrandQueryHandler(IBrandReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetSingleBrandQueryResponse> Handle(GetSingleBrandQueryRequest request, CancellationToken cancellationToken)
        {
            Brand brand = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, false);
            if (brand == null)
            {
                throw new BrandNotFoundException();
            }
            var dto = new BrandGetDto
            {
                Id = brand.ID.ToString(),
                Name = brand.Name,
                Image = brand.Image is not null ? brand.Image : ConstantPaths.DefaultImage,
                ImageURL = brand.Image is not null ? brand.Image : ConstantPaths.DefaultImageURL
            };

            return new GetSingleBrandQueryResponse
            {
                Dto = dto
            };
        }
    }
}
