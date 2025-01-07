using KovserHedieyyeler.Application.DTOs.Products.ProductImage;
using KovserHedieyyeler.Application.DTOs.Products.ProductProperty;
using KovserHedieyyeler.Application.DTOs.Products.Products;
using KovserHediyyeler.Application.Abstractions.Products;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KovserHediyyeler.Persistence.Services.Products
{
    public class ProductPatchService : IProductPatchService
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductImageFileReadRepository _productImageFileReadRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IProductPropertyReadRepository _productPropertyReadRepository;
        readonly IProductPropertyWriteRepository _productPropertyWriteRepository;
        readonly IProductColorReadRepository _productColorReadRepository;
        readonly IProductColorWriteRepository _productColorWriteRepository;
        readonly IProductSizeReadRepository _productSizeReadRepository;
        readonly IProductSizeWriteRepository _productSizeWriteRepository;
        readonly IWebHostEnvironment _env;
        readonly IHttpContextAccessor _accessor;

        public ProductPatchService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IProductImageFileReadRepository productImageFileReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository, IProductPropertyReadRepository productPropertyReadRepository, IProductPropertyWriteRepository productPropertyWriteRepository, IProductColorReadRepository productColorReadRepository, IProductColorWriteRepository productColorWriteRepository, IProductSizeReadRepository productSizeReadRepository, IProductSizeWriteRepository productSizeWriteRepository, IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _productImageFileReadRepository = productImageFileReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _productPropertyReadRepository = productPropertyReadRepository;
            _productPropertyWriteRepository = productPropertyWriteRepository;
            _productColorReadRepository = productColorReadRepository;
            _productColorWriteRepository = productColorWriteRepository;
            _productSizeReadRepository = productSizeReadRepository;
            _productSizeWriteRepository = productSizeWriteRepository;
            _env = env;
            _accessor = accessor;
        }

        public async Task UpdateProductAsync(string id, ProductPutDto dto)
        {
            Product product = await _productReadRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == id, true);
            if (product == null) throw new NotFoundException("məhsul");
            double? discountprice = 0;
            if (dto.Price != null)
            {
                if (dto.DiscountPercentage != null)
                {
                    discountprice = dto.Price - dto.Price * (int)dto.DiscountPercentage! / 100;
                }
                else
                {
                    discountprice = dto.Price;
                }
            }

            product.Name = dto.Name != null ? dto.Name : product.Name;
            product.Description = dto.Description != null ? dto.Description : product.Description;
            product.Stock = product.Stock;
            product.Price = dto.Price != null ? (double)dto.Price : product.Price;
            product.DiscountedPrice = (double)discountprice > 0 ? (double)discountprice : product.DiscountedPrice;
            product.isSingleColour = dto.isSingleColour != null ? (bool)dto.isSingleColour : product.isSingleColour;
            product.BrandID = dto.BrandID != null ? dto.BrandID : product.BrandID;
            product.DepartmentID = dto.DepartmentID != null ? (Guid)dto.DepartmentID : product.DepartmentID;
            product.CategoryID = dto.CategoryID != null ? (Guid)dto.CategoryID : product.CategoryID;

            _productWriteRepository.Update(product);
            await _productWriteRepository.SaveAsync();
        }

        public async Task UpdateProductImageFileAsync(string id, ProductImageCommandDto dto)
        {
            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;
            ProductImageFile image = await _productImageFileReadRepository.GetWhereAsync(x => x.ID.ToString() == id, true);
            if (image == null) throw new NotFoundException("məhsul şəkli");
            image.FileName = dto.file != null ? dto.file.UploadFile(_env.WebRootPath, FilePaths.ProuctImageFilePath) : image.FileName != null ? image.FileName : ConstantPaths.DefaultImage;
            image.Path = dto.file != null
                ? $"{scheme}://{host}/{FilePaths.ProuctImageFilePath}/{image.FileName}"
                : image.Path != null ? image.Path : ConstantPaths.DefaultImageURL;
            image.IsMain = dto.IsMain != null ? (bool)dto.IsMain : image.IsMain;

            _productImageFileWriteRepository.Update(image);
            await _productImageFileWriteRepository.SaveAsync();
        }

        public async Task UpdateProductPropertyAsync(string id, ProductPropertyCommandDto dto)
        {
            ProductProperty property = await _productPropertyReadRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == id, true);
            if (property == null) throw new NotFoundException("məhsul xüsusiyyəti");
            property.Name = dto.Name != null ? dto.Name : property.Name;
            property.Value = dto.Value != null ? dto.Value : property.Value;

            _productPropertyWriteRepository.Update(property);
            await _productPropertyWriteRepository.SaveAsync();

        }

        public async Task UpdateProductColorAsync(string id, string? colorName, int colorStock)
        {
            using var transaction = await _productWriteRepository.BeginTransactionAsync();
            try
            {
                var color = await _productColorReadRepository.GetWhereAsync(c => c.ID.ToString() == id && !c.isDeleted, true, "Product");
                if (color == null) throw new NotFoundException("məhsul rəngi");
                var tempStock = color.ColorStock; //ilkin stok dəyəri
                color.ColorName = colorName != null ? colorName : color.ColorName;
                color.ColorStock = colorStock != 0 ? colorStock :color.ColorStock;
                color.Product.Stock += color.ColorStock - tempStock;//çünki color-da olan ilkin stok dəyəri çıxmalı, yeni stock dəyəri toplanmalıdır.
                _productColorWriteRepository.Update(color);
                _productWriteRepository.Update(color.Product);
                await _productColorWriteRepository.SaveAsync();
                await _productWriteRepository.SaveAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateProductSizeAsync(string id, string? sizeName, int sizeStock)
        {
            using var transaction = await _productWriteRepository.BeginTransactionAsync();
            try
            {
                var size = await _productSizeReadRepository.GetWhereAsync(c => c.ID.ToString() == id && !c.isDeleted, true, "Product");
                if (size == null) throw new NotFoundException("məhsul ölçüsü");
                var tempStock = size.SizeStock; //ilkin stok dəyəri
                size.SizeName = sizeName != null ? sizeName : size.SizeName;
                size.SizeStock = sizeStock != 0 ? sizeStock : size.SizeStock;
                size.Product.Stock += size.SizeStock - tempStock; //çünki size-da olan ilkin stok dəyəri çıxmalı, yeni stock dəyəri toplanmalıdır.
                _productSizeWriteRepository.Update(size);
                _productWriteRepository.Update(size.Product);
                await _productSizeWriteRepository.SaveAsync();
                await _productWriteRepository.SaveAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

    }
}
