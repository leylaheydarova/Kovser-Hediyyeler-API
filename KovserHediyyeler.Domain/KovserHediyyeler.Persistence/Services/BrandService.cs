using KovserHedieyyeler.Application.DTOs.Brands;
using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Persistence.Services
{
    public class BrandService : IBrandService
    {
        readonly IBrandReadRepository _readRepository;
        readonly IBrandWriteRepository _writeRepository;
        readonly IWebHostEnvironment _env;
        readonly IHttpContextAccessor _accessor;

        public BrandService(IBrandReadRepository readRepository, IBrandWriteRepository writeRepository, IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _env = env;
            _accessor = accessor;
        }

        private async Task<Brand> GetBrandAsync(string id, bool tracking)
        {
            Brand brand = await _readRepository.GetWhereAsync(b => b.ID.ToString() == id, tracking);
            if (brand == null) throw new NotFoundException("brend");
            return brand;
        }
        public async Task CreateAsync(BrandCommandDto dto)
        {
            if (dto == null) throw new BadRequestException();
            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;
            Brand brand = new Brand
            {
                ID = Guid.NewGuid(),
                Name = dto.Name,
                Image = dto.file.UploadFile(_env.WebRootPath, FilePaths.BrandImagePath),
                ImageURL = ""
            };
            brand.ImageURL = $"{scheme}://{host}/{FilePaths.BrandImagePath}/{brand.Image}";

            if (brand == null) throw new BadRequestException();
            await _writeRepository.AddAsync(brand);
            await _writeRepository.SaveAsync();
        }

        public async Task DeleteTemporarilyAsync(string id)
        {
            var brand = await GetBrandAsync(id, true);
            _writeRepository.DeleteTemporarily(brand);
            await _writeRepository.SaveAsync();
        }

        public async Task<List<BrandGetDto>> GetAllAsync(int page, int size)
        {
            var query = _readRepository.GetAllWhere(x => !x.isDeleted, false);
            List<BrandGetDto> dtos = new List<BrandGetDto>();
            dtos = await query
                .Select(x => new BrandGetDto
                {
                    Id = x.ID.ToString(),
                    Name = x.Name,
                    Image = x.Image != null ? x.Image : ConstantPaths.DefaultImage,
                    ImageURL = x.Image != null ? x.ImageURL : ConstantPaths.DefaultImageURL
                })
                .OrderBy(b => b.Name)
                .Skip(page * size)
                .Take(size)
                .ToListAsync();
            return dtos;
        }

        public async Task<BrandGetDto> GetSingleAsync(string id)
        {
            var brand = await GetBrandAsync(id, false);
            var dto = new BrandGetDto
            {
                Id = brand.ID.ToString(),
                Name = brand.Name,
                Image = brand.Image is not null ? brand.Image : ConstantPaths.DefaultImage,
                ImageURL = brand.ImageURL

            };
            return dto;
        }

        public async Task RecoverDataAsync(string id)
        {
            Brand brand = await _readRepository.GetWhereAsync(b => b.isDeleted && b.ID.ToString() == id, true);
            if (brand == null) throw new BadRequestException();
            _writeRepository.RecoverData(brand);
            await _writeRepository.SaveAsync();
        }

        public async Task RemovePermanentAsync(string id)
        {
            var brand = await GetBrandAsync(id, true);

            _writeRepository.RemovePermanently(brand);
            await _writeRepository.SaveAsync();
        }

        public async Task UpdateAsync(BrandUpdateDto dto, string id)
        {
            var brand = await GetBrandAsync(id, true);
            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;
            brand.Name = dto.Name != null ? dto.Name : brand.Name;
            brand.Image = dto.file != null
                ? dto.file.UploadFile(_env.WebRootPath, FilePaths.BrandImagePath)
                : brand.Image;
            brand.ImageURL = dto.file != null
                ? $"{scheme}://{host}/{FilePaths.BrandImagePath}/{brand.Image}"
                : brand.ImageURL;
            _writeRepository.Update(brand);
            await _writeRepository.SaveAsync();
        }

        public async Task UpdateTotalAsync(BrandCommandDto dto, string id)
        {
            var brand = await GetBrandAsync(id, true);
            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;
            brand.Name = dto.Name;
            brand.Image = dto.file.UploadFile(_env.WebRootPath, FilePaths.BrandImagePath);
            brand.ImageURL = $"{scheme}://{host}/{FilePaths.BrandImagePath}/{brand.Image}";

            _writeRepository.Update(brand);
            await _writeRepository.SaveAsync();
        }
    }
}
