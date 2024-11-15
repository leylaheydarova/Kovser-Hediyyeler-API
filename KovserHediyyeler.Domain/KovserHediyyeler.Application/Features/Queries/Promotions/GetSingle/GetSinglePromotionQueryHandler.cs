using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHedieyyeler.Application.DTOs.Promotion;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Promotions;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Promotions.GetSingle
{
    public class GetSinglePromotionQueryHandler : IRequestHandler<GetSinglePromotionQueryRequest, GetSinglePromotionQueryResponse>
    {
        readonly IPromotionReadRepository _repository;

        public GetSinglePromotionQueryHandler(IPromotionReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetSinglePromotionQueryResponse> Handle(GetSinglePromotionQueryRequest request, CancellationToken cancellationToken)
        {
            Promotion promotion = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), false, "Products.Department");
            if (promotion == null)
            {
                throw new PromotionNotFoundException();
            }

            var dto = new PromotionGetSingleDto
            {
                Id = promotion.ID.ToString(),
                Title = promotion.Title,
                Description = promotion.Description,
                DiscountedPrice = promotion.DiscountedPrice,
                DiscountPersentage = promotion.DiscountPersentage.ToString(),
                ExpireDate = promotion.ExpireDate,
                StartDate = (DateTime)promotion.StartDate,
                Price = promotion.Price,
                Products = promotion.Products.Select(p => new ProductGetAllDto
                {
                    Id = p.ID.ToString(),
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    DiscountedPrice = p.DiscountedPrice,
                    Image = p.Images
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
                        },
                    DepartmentName = p.Department.Name,
                    ProductAverageRating = p.ProductAverageRating
                }).ToList()
            };
            return new GetSinglePromotionQueryResponse
            {
                Dto = dto
            };
        }
    }
}
//todo: bir mehuslun endirime dusub dusmemesini yoxlayan bir metod yaz