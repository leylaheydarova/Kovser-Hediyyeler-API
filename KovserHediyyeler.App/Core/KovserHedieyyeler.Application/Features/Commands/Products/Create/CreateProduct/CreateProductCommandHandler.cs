
using KovserHedieyyeler.Application.Repositories.Abstractions.Products;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Create.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IProductPropertyWriteRepository _productPropertyWriteRepository;
        readonly IColorWriteRepository _colorWriteRepository;
        readonly IHttpContextAccessor _accessor;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductImageFileWriteRepository productImageFileWriteRepository, IHttpContextAccessor accessor, IProductPropertyWriteRepository productPropertyWriteRepository, IColorWriteRepository colorWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _accessor = accessor;
            _productPropertyWriteRepository = productPropertyWriteRepository;
            _colorWriteRepository = colorWriteRepository;
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
                DiscountedPrice = (dto.Price - ((dto.Price*(int)dto.DiscountPercentage)/100)),
                isSingleColour = dto.isSingleColour,
                Stock = dto.Stock
            };

            foreach(var imageDto in dto.ProductImages)
            {
                var res = imageDto.file.FileName;

                ProductImageFile image = new ProductImageFile
                {
                    ID = Guid.NewGuid(),
                    FileName = imageDto.file.FileName,
                    Path = _accessor.HttpContext.Request.Scheme + "://" + _accessor.HttpContext.Request.Host + $"/{imageDto.file.FileName}",
                    ProductID = product.ID
                };
                try
                {
                    await _productImageFileWriteRepository.AddAsync(image);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }

            foreach (var colorDto in request.Dto.Colors)
            {
                ColorCode color = new ColorCode
                {
                    ID = Guid.NewGuid(),
                    Name = colorDto.Name,
                    HexCode = colorDto.HexCode,
                };

                var propertyColor = new ProductProperty
                {
                    ID = Guid.NewGuid(),
                    Name = "Rəng",
                    Value = color.Name,
                    ProductID = product.ID
                };
                await _productPropertyWriteRepository.AddAsync(propertyColor);

                ColorCodeProductProperty colorProperty = new ColorCodeProductProperty
                {
                    ID = Guid.NewGuid(),
                    ColorCodeID = color.ID,
                    ProductPropertyID = propertyColor.ID
                };
                color.ColorCodeProductProperties.Add(colorProperty);
                await _colorWriteRepository.AddAsync(color);
                
            }

            foreach (var propertyDto in dto.ProductProperties)
            {
                ProductProperty property = new ProductProperty
                {
                    ID = Guid.NewGuid(),
                    Name = propertyDto.Name,
                    Value = propertyDto.Value,
                    ProductID = product.ID
                };

                await _productPropertyWriteRepository.AddAsync(property);
            }

            foreach(var shopId in request.Dto.ShopIDs)
            {
                var ShopProduct = new ProductShop()
                {
                    ProductID = product.ID,
                    ShopID = shopId
                };
                product.ProductShops.Add(ShopProduct);
            }

            try
            {
                await _productWriteRepository.AddAsync(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            await _productWriteRepository.SaveAsync();

            return new CreateProductCommandResponse
            {
                StatusCode = 201,
                Message = "Məhsul uğurla əlavə edildi!"
            };
            
        }
    }
}
