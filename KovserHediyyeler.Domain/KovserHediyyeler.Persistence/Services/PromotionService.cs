using KovserHedieyyeler.Application.DTOs.Promotion;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.DTOs.Promotion;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Promotions;
using KovserHediyyeler.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Persistence.Services
{
    public class PromotionService : IPromotionService
    {
        readonly IPromotionReadRepository _readRepository;
        readonly IPromotionWriteRepository _writeRepository;
        readonly IWebHostEnvironment _env;
        readonly IHttpContextAccessor _accessor;

        public PromotionService(IPromotionReadRepository readRepository, IPromotionWriteRepository writeRepository, IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _env = env;
            _accessor = accessor;
        }

        private async Task<Promotion> GetPromotionAsync(string id, bool tracking)
        {
            var promotion = await _readRepository.GetWhereAsync(p => p.ID.ToString() == id, tracking);
            if (promotion == null) throw new NotFoundException("uyğun kampaniya məhsulu");
            return promotion;
        }

        public async Task CreateAsync(PromotionCommandDto dto)
        {
            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;
            Promotion promotion = new Promotion
            {
                ID = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                DiscountedPrice = (dto.Price - ((dto.Price * (int)dto.DiscountPersentage) / 100)),
                ImageName = dto.Image.UploadFile(_env.WebRootPath, FilePaths.PromotionImagePath),
                ImageURL = "",
                ExpireDate = dto.ExpireDate,
                StartDate = dto.StartDate
            };
            promotion.ImageURL = $"{scheme}://{host}/{FilePaths.PromotionImagePath}/{promotion.ImageName}";
            await _writeRepository.AddAsync(promotion);
            await _writeRepository.SaveAsync();
        }

        public async Task<List<PromotionGetAllDto>> GetAllAsync(int page, int size)
        {
            var query = _readRepository.GetAllWhere(x => !x.isDeleted, false);
            List<PromotionGetAllDto> dtos = await query.Skip(page * size)
                .Take(size)
                .Select(x => new PromotionGetAllDto
                {
                    Id = x.ID.ToString(),
                    Title = x.Title,
                    Description = x.Description,
                    Price = (double)x.Price,
                    DiscountedPrice = x.DiscountedPrice,
                    StartDate = x.StartDate,
                    ExpireDate = x.ExpireDate
                }).ToListAsync();
            return dtos;
        }

        public async Task<DateTime> GetExpireDateAsync(string id)
        {
            var promotion = await GetPromotionAsync(id, false);
            return promotion.ExpireDate;
        }

        public async Task<PromotionGetSingleDto> GetSingleAsync(string id)
        {
            var promotion = await GetPromotionAsync(id, false);
            var dto = new PromotionGetSingleDto
            {
                Id = promotion.ID.ToString(),
                Title = promotion.Title,
                Description = promotion.Description,
                DiscountedPrice = (double)promotion.DiscountedPrice,
                DiscountPersentage = (double)(1 - ((promotion.DiscountedPrice * 100) / promotion.Price)) * 100,
                ExpireDate = promotion.ExpireDate,
                StartDate = (DateTime)promotion.StartDate,
                Price = (double)promotion.Price,
                //Products = promotion.Products.Select(p => new ProductGetAllDto
                //{
                //    Id = p.ID.ToString(),
                //    Name = p.Name,
                //    Price = p.Price,
                //    Description = p.Description,
                //    DiscountedPrice = p.DiscountedPrice,
                //    Image = p.Images
                //    .Where(image => image.IsMain) // IsMain filtrasiya
                //        .Select(image => new ProductImageGetDto
                //        {
                //            Id = image.ID.ToString(),
                //            ImageName = image.FileName,
                //            ImageURL = image.Path,
                //            isMain = image.IsMain
                //        })
                //        .FirstOrDefault() // İlk IsMain şəkli götür
                //        ?? new ProductImageGetDto // Default şəkil qaytar
                //        {
                //            Id = Guid.Empty.ToString(),
                //            ImageName = ,
                //            ImageURL = BaseURLs.DefaultImageURL,
                //            isMain = true
                //        },
                //    DepartmentName = p.Department.Name,
                //    ProductAverageRating = p.ProductAverageRating
                //}).ToList()
            };
            return dto;
        }

        public async Task RemovePermanentAsync(string id)
        {
            var promotion = await GetPromotionAsync(id, true);
            _writeRepository.RemovePermanently(promotion);
            await _writeRepository.SaveAsync();
        }

        public async Task UpdateAsync(PromotionPatchDto dto, string id)
        {
            var promotion = await GetPromotionAsync(id, true);
            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;
            promotion.Title = dto.Title != null ? dto.Title : promotion.Title;
            promotion.Description = dto.Description != null ? dto.Description : promotion.Description;
            promotion.Price = dto.Price != null ? dto.Price : promotion.Price;
            promotion.DiscountedPrice = dto.DiscountPersentage != null ? (dto.Price - ((dto.Price * (int)dto.DiscountPersentage) / 100)) : promotion.DiscountedPrice;
            promotion.ExpireDate = dto.ExpireDate != null ? (DateTime)dto.ExpireDate : promotion.ExpireDate;
            promotion.StartDate = dto.StartDate != null ? (DateTime)dto.StartDate : promotion.StartDate;
            promotion.ImageName = dto.Image != null ? dto.Image.UploadFile(_env.WebRootPath, FilePaths.PromotionImagePath) : promotion.ImageName;
            promotion.ImageURL = dto.Image != null ? $"{scheme}://{host}/{FilePaths.PromotionImagePath}/{promotion.ImageName}" : promotion.ImageURL;

            _writeRepository.Update(promotion);
            await _writeRepository.SaveAsync();
        }

    }
}
