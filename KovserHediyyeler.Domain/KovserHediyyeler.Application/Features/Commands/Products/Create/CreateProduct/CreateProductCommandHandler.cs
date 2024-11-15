using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Application.Repositories.Shops;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductWriteRepository _productwriterepository;
        readonly IProductImageFileWriteRepository _productimagefilewriterepository;
        readonly IProductPropertyWriteRepository _productpropertywriterepository;
        readonly IColorWriteRepository _colorwriterepository;
        readonly IShopReadRepository _shopRepository;
        readonly IHttpContextAccessor _accessor;

        public CreateProductCommandHandler(IProductWriteRepository productwriterepository, IProductImageFileWriteRepository productimagefilewriterepository, IProductPropertyWriteRepository productpropertywriterepository, IColorWriteRepository colorwriterepository, IHttpContextAccessor accessor, IShopReadRepository shopRepository)
        {
            _productwriterepository = productwriterepository;
            _productimagefilewriterepository = productimagefilewriterepository;
            _productpropertywriterepository = productpropertywriterepository;
            _colorwriterepository = colorwriterepository;
            _accessor = accessor;
            _shopRepository = shopRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            Product product = new Product
            {
                ID = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                BrandID = dto.BrandID,
                CategoryID = dto.CategoryID,
                DepartmentID = dto.DepartmentID,
                Price = dto.Price,
                DiscountedPrice = (dto.Price - ((dto.Price * (int)dto.DiscountPercentage) / 100)),
                isSingleColour = dto.isSingleColour,
                Stock = dto.Stock
            };

            foreach (var imagedto in dto.ProductImages)
            {
                var res = imagedto.file.FileName;

                ProductImageFile image = new ProductImageFile
                {
                    ID = Guid.NewGuid(),
                    FileName = imagedto.file.FileName,
                    Path = _accessor.HttpContext.Request.Scheme + "://" + _accessor.HttpContext.Request.Host + $"/{imagedto.file.FileName}",
                    ProductID = product.ID
                };
                try
                {
                    await _productimagefilewriterepository.AddAsync(image);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }

            foreach (var colordto in request.Dto.Colors)
            {
                ColorCode color = new ColorCode
                {
                    ID = Guid.NewGuid(),
                    Name = colordto.Name,
                    HexCode = colordto.HexCode
                };

                var propertycolor = new ProductProperty
                {
                    ID = Guid.NewGuid(),
                    Name = "rəng",
                    Value = color.Name,
                    ProductID = product.ID
                };
                await _productpropertywriterepository.AddAsync(propertycolor);
            }

            foreach (var propertydto in dto.ProductProperties)
            {
                ProductProperty property = new ProductProperty
                {
                    ID = Guid.NewGuid(),
                    Name = propertydto.Name,
                    Value = propertydto.Value,
                    ProductID = product.ID
                };

                await _productpropertywriterepository.AddAsync(property);
            }

            foreach (var shopId in request.Dto.ShopIDs)
            {
                var shop = product.Shops.FirstOrDefault(sh => sh.ID == shopId && !sh.isDeleted);
                product.Shops.Add(shop);
            }


            try
            {
                await _productwriterepository.AddAsync(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            await _productwriterepository.SaveAsync();

            return new CreateProductCommandResponse
            {
                StatusCode = 201,
                Message = "Məhsul uğurla əlavə edildi!"
            };
        }
    }
}
