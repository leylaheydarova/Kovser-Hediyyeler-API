using KovserHediyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Application.Repositories.Categories;
using KovserHediyyeler.Application.Repositories.Departments;
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
        readonly ICategoryReadRepository _categoryRepository;
        readonly IDepartmentReadRepository _departmentRepository;
        readonly IBrandReadRepository _brandRepository;
        readonly IHttpContextAccessor _accessor;

        public CreateProductCommandHandler(IProductWriteRepository productwriterepository, IProductImageFileWriteRepository productimagefilewriterepository, IProductPropertyWriteRepository productpropertywriterepository, IColorWriteRepository colorwriterepository, IHttpContextAccessor accessor, IShopReadRepository shopRepository, ICategoryReadRepository categoryRepository, IDepartmentReadRepository departmentRepository, IBrandReadRepository brandRepository)
        {
            _productwriterepository = productwriterepository;
            _productimagefilewriterepository = productimagefilewriterepository;
            _productpropertywriterepository = productpropertywriterepository;
            _colorwriterepository = colorwriterepository;
            _accessor = accessor;
            _shopRepository = shopRepository;
            _categoryRepository = categoryRepository;
            _departmentRepository = departmentRepository;
            _brandRepository = brandRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var category = await _categoryRepository.GetWhereAsync(c => c.ID == request.Dto.CategoryID, false);
            if (category == null) throw new InvalidInputException("Category");

            var department = await _departmentRepository.GetWhereAsync(d => d.ID == request.Dto.DepartmentID, false);
            if (department == null) throw new InvalidInputException("Department");

            var brand = request.Dto.BrandID is not null
                ? await _brandRepository.GetWhereAsync(b => b.ID == request.Dto.BrandID, false)
                : null;

            if (brand == null && request.Dto.BrandID is not null)
                throw new InvalidInputException("Brand");

            Product product = new Product
            {
                ID = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                BrandID = brand.ID,
                CategoryID = category.ID,
                DepartmentID = department.ID,
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
                    ProductID = product.ID,
                    IsMain = imagedto.IsMain
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
                await _colorwriterepository.AddAsync(color);
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
                var shop = await _shopRepository.GetWhereAsync(sh => sh.ID == shopId && !sh.isDeleted, false);
                if (shop != null)
                {
                    shop.Products.Add(product);
                }
                else throw new InvalidInputException("Shop");
            }

            category.Products.Add(product);
            department.Products.Add(product);
            if (brand is not null) brand.Products.Add(product);
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
