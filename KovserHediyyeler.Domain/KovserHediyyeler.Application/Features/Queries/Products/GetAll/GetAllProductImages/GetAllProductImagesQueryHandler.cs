using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHediyyeler.Application.Repositories.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetAll.GetAllProductImages
{
    public class GetAllProductImagesQueryHandler : IRequestHandler<GetAllProductImagesQueryRequest, GetAllProductImagesQueryResponse>
    {
        readonly IProductImageFileReadRepository _repository;

        public GetAllProductImagesQueryHandler(IProductImageFileReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllProductImagesQueryResponse> Handle(GetAllProductImagesQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllWhere(x => !x.isDeleted && x.ProductID.ToString() == request.ProductId, false);
            var totalCount = query.Count();
            var dtos = new List<ProductImageGetDto>();
            dtos = await query.Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(x => new ProductImageGetDto
                {
                    Id = x.ID.ToString(),
                    ImageName = x.FileName,
                    ImageURL = x.Path,
                    isMain = x.IsMain
                }).ToListAsync();
            return new GetAllProductImagesQueryResponse
            {
                Datas = dtos,
                TotalCount = totalCount
            };
        }
    }
}
