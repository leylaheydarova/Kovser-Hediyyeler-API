using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHedieyyeler.Application.DTOs.Shops;
using KovserHediyyeler.Application.Abstractions.Products;
using KovserHediyyeler.Application.DTOs.Products.ProductColor;
using KovserHediyyeler.Application.DTOs.Products.ProductSize;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;

namespace KovserHediyyeler.Persistence.Services.Products
{
    public class ProductGetSingleService : IProductGetSingleService
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductPropertyReadRepository _productPropertyReadRepository;
        readonly IProductColorReadRepository _productColorReadRepository;
        readonly IProductSizeReadRepository _productSizeReadRepository;

        public ProductGetSingleService(IProductReadRepository productReadRepository, IProductPropertyReadRepository productPropertyReadRepository, IProductColorReadRepository productColorReadRepository, IProductSizeReadRepository productSizeReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productPropertyReadRepository = productPropertyReadRepository;
            _productColorReadRepository = productColorReadRepository;
            _productSizeReadRepository = productSizeReadRepository;
        }

        public async Task<ProductGetSingleDto> GetSingleProductAsync(string id)
        {
            Product product = await _productReadRepository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(id), false,
                "Category",
                "Department",
                "Brand",
                "Properties",
                "Images",
                "Colors",
                "Sizes",
                //"Comments",
                "Shops.Addresses");
            if (product == null)
            {
                throw new NotFoundException("məhsul");
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
                Colors = product.Colors.Select(color => new ProductColorGetDto
                {
                    Id = color.ID.ToString(),
                    ColorName = color.ColorName
                }).ToList(),
                Sizes = product.Sizes.Select(size => new ProductSizeGetDto
                {
                    Id = size.ID.ToString(),
                    SizeName = size.SizeName
                }).ToList(),
                //Comments = product.Comments.Select(comment => new ProductCommentGetDto
                //{
                //    Id = comment.ID.ToString(),
                //    CommentText = comment.CommentText,
                //    //Username = comment.Customer.UserName,
                //    RatingGivenByCustomer = (int)comment.RatingGivenByUser
                //}).ToList()
            };
            return dto;
        }

        public async Task<ProductPropertyGetDto> GetSingleProductPropertyAsync(string id)
        {
            var property = await _productPropertyReadRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == id, false);
            if (property == null) throw new NotFoundException("məhsul xüsusiyyəti");
            var dto = new ProductPropertyGetDto
            {
                Id = property.ID.ToString(),
                Name = property.Name,
                Value = property.Value
            };
            return dto;
        }

        public async Task<ProductColorGetDto> GetSingleProductColorAsync(string id)
        {
            var color = await _productColorReadRepository.GetByIdAsync(id, false);
            if (color == null) throw new NotFoundException("rəng");
            var dto = new ProductColorGetDto
            {
                Id = color.ID.ToString(),
                ColorName = color.ColorName
            };
            return dto;
        }

        public async Task<ProductSizeGetDto> GetSingleProductSizeAsync(string id)
        {
            var size = await _productSizeReadRepository.GetByIdAsync(id, false);
            if (size == null) throw new NotFoundException("ölçü");
            var dto = new ProductSizeGetDto
            {
                Id = size.ID.ToString(),
                SizeName = size.SizeName
            };
            return dto;
        }
    }
}
