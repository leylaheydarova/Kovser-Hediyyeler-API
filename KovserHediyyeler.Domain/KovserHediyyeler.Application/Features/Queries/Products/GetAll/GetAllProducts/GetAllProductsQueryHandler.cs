using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHediyyeler.Application.Repositories.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetAll.GetAllProducts
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
            var query = _repository.GetAllWhere(x => !x.isDeleted, false, "Department");

            int totalCount = query.Count();
            List<ProductGetAllDto> dtos = await query
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(x => new ProductGetAllDto
                {
                    Id = x.ID.ToString(),
                    Name = x.Name,
                    Description = x.Description,
                    DepartmentName = x.Department.Name,
                    DiscountedPrice = x.DiscountedPrice,
                    Price = x.Price,
                    ProductAverageRating = x.ProductAverageRating,
                    Image = x.Images
                        .Where(image => image.IsMain) // IsMain filtrasiya
                        .Select(image => new ProductImageGetDto
                        {
                            Id = image.ID.ToString(),
                            ImageName = image.FileName,
                            ImageURL = image.Path,
                            isMain = image.IsMain
                        })
                        .FirstOrDefault() // İlk IsMain şəkli götür
                        ?? new ProductImageGetDto // Default şəkil qaytar
                        {
                            Id = Guid.Empty.ToString(),
                            ImageName = "DefaultProductImage.png",
                            ImageURL = "https://localhost:7232/DefaultProductImage.png",
                            isMain = true
                        }
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
