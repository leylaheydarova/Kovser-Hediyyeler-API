using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHedieyyeler.Application.DTOs.Shops;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Products.GetSingle.GetSingleProduct
{
    public class GetSingleProductQueryHandler : IRequestHandler<GetSingleProductQueryRequest, GetSingleProductQueryResponse>
    {
        readonly IProductReadRepository _repository;

        public GetSingleProductQueryHandler(IProductReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetSingleProductQueryResponse> Handle(GetSingleProductQueryRequest request, CancellationToken cancellationToken)
        {
            Product product = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), false,
                "Category",
                "Department",
                "Brand",
                "Properties",
                "Images",
                //"Comments",
                "Shops.Addresses");
            if (product == null)
            {
                throw new ProductNotFoundException();
            }
            ProductGetSingleDto dto = new ProductGetSingleDto
            {
                Id = product.ID.ToString(),
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                BrandName = product.Brand.Name,
                CategoryName = product.Category.Name,
                DepartmentName = product.Department.Name,
                DiscountPrice = product.DiscountedPrice,
                ProductAverageRating = product.ProductAverageRating,
                Images = product.Images.Select(image => new ProductImageGetDto
                {
                    Id = image.ID.ToString(),
                    ImageName = image.FileName,
                    ImageURL = image.Path,
                    isMain = image.IsMain
                }).ToList(),
                Properties = product.Properties.Select(property => new ProductPropertyGetDto
                {
                    Id = property.ID.ToString(),
                    Name = property.Name,
                    Value = property.Value
                }).ToList(),
                ShopNames = product.Shops != null ? product.Shops.Select(shop => new ShopGetAllDto
                {
                    Id = shop.ID.ToString(),
                    Name = shop.Name,
                    City = shop.Addresses.FirstOrDefault(x => x.IsCurrentAddress).GetCity,
                    Description = shop.Description,
                    Phone = shop.Phone
                }).ToList() : null,
                //Comments = product.Comments.Select(comment => new ProductCommentGetDto
                //{
                //    Id = comment.ID.ToString(),
                //    CommentText = comment.CommentText,
                //    //Username = comment.Customer.UserName,
                //    RatingGivenByCustomer = (int)comment.RatingGivenByUser
                //}).ToList()
            };
            return new GetSingleProductQueryResponse
            {
                Dto = dto
            };
        }
    }
}
