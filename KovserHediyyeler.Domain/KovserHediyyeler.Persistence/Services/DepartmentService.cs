using KovserHedieyyeler.Application.DTOs.Department;
using KovserHedieyyeler.Application.DTOs.SocialMedias;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories;
using KovserHediyyeler.Application.Repositories.Departments;
using KovserHediyyeler.Application.Repositories.SocialMedias;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Domain.Models.BaseModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace KovserHediyyeler.Persistence.Services
{
    public class DepartmentService : IDepartmentService
    {
        readonly IDepartmentReadRepository _readRepository;
        readonly IDepartmentWriteRepository _writeRepository;
        readonly ISocialMediaReadRepository _smReadRepository;
        readonly ISocialMediaWriteRepository _smWriteRepository;
        readonly IWebHostEnvironment _env;
        readonly IHttpContextAccessor _accessor;

        public DepartmentService(IDepartmentReadRepository readRepository, IDepartmentWriteRepository writeRepository, ISocialMediaReadRepository smReadRepository, ISocialMediaWriteRepository smWriteRepository, IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _smReadRepository = smReadRepository;
            _smWriteRepository = smWriteRepository;
            _env = env;
            _accessor = accessor;
        }

        private async Task<T> GetEntityAsync<T>(IReadRepository<T> repository, string id, bool trackChanges = true) where T : BaseEntity
        {
            T entity = await repository.GetWhereAsync(x => x.ID.ToString() == id, trackChanges);
            if (entity == null)
            {
                if (typeof(T) == typeof(Department))
                    throw new DepartmentNotFoundException();
                if (typeof(T) == typeof(SocialMedia))
                    throw new SocialMediaNotFoundException();
            }
            return entity;
        }
        public async Task CreateDepartmentAsync(DepartmentCommandDto dto)
        {
            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;
            dto = new DepartmentCommandDto
            {
                Name = dto.Name,
                Description = dto.Description,
                Phone = dto.Phone,
                File = dto.File,
                SocialMedias = dto.SocialMedias
            };

            Department department = new Department
            {
                ID = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Phone = dto.Phone,
                LogoImage = dto.File.UploadFile(_env.WebRootPath, FilePaths.DepartmentImagePath),
                LogoImageURL = ""
            };
            department.LogoImageURL = $"{scheme}://{host}/{FilePaths.DepartmentImagePath}/{department.LogoImage}";


            foreach (var socialMediaDto in dto.SocialMedias)
            {
                SocialMedia socialMedia = new SocialMedia()
                {
                    Name = socialMediaDto.Name,
                    Department = department,
                    NickName = socialMediaDto.NickName,
                    URL = socialMediaDto.URL
                };
                await _smWriteRepository.AddAsync(socialMedia);
            }

            await _writeRepository.AddAsync(department);
            await _writeRepository.SaveAsync();
        }

        public async Task CreateDepartmentSocialMediaAsync(SocialMediaCommandDto dto, string DepartmentId)
        {
            var socialMedia = new SocialMedia
            {
                ID = Guid.NewGuid(),
                Name = dto.Name,
                NickName = dto.NickName,
                URL = dto.URL,
                DepartmentID = Guid.Parse(DepartmentId)
            };
            await _smWriteRepository.AddAsync(socialMedia);
            await _smWriteRepository.SaveAsync();
        }

        public async Task DeleteTemporarilyDepartment(string id)
        {
            var department = await GetEntityAsync(_readRepository, id);
            foreach (var socialMedia in department.SocialMedias)
            {
                if (socialMedia.DepartmentID == department.ID)
                {
                    _smWriteRepository.DeleteTemporarily(socialMedia);
                }
            }
            _writeRepository.DeleteTemporarily(department);
            await _writeRepository.SaveAsync();
        }

        public async Task<List<DepartmentGetAllDto>> GetAllDepartments(int page, int size)
        {
            var query = _readRepository.GetAllWhere(x => !x.isDeleted, false, "SocialMedias");
            List<DepartmentGetAllDto> dtos = new List<DepartmentGetAllDto>();
            dtos = await query.Skip(page * size)
                .Take(size)
                .Select(x => new DepartmentGetAllDto
                {
                    Id = x.ID.ToString(),
                    Name = x.Name,
                    Description = x.Description,
                    LogoImage = x.LogoImage != null ? x.LogoImage : ConstantPaths.DefaultImage,
                    LogoImageURL = x.LogoImage != null ? x.LogoImageURL : ConstantPaths.DefaultImageURL
                }).ToListAsync();
            return dtos;
        }

        public async Task<List<SocialMediaGetDto>> GetAllDepartmentSocialMedias(string DepartmentId)
        {
            if (!Guid.TryParse(DepartmentId, out var departmentId))
            {
                throw new DepartmentNotFoundException();
            }
            var query = _smReadRepository.GetAllWhere(x => !x.isDeleted && x.DepartmentID == departmentId, false);
            query = query.Include(sm => sm.Department);
            if (!query.Any()) throw new DepartmentNotFoundException();
            List<SocialMediaGetDto> dtos = new List<SocialMediaGetDto>();
            dtos = await query.Select(x => new SocialMediaGetDto
            {
                Id = x.ID.ToString(),
                Name = x.Name,
                NickName = x.NickName,
                URL = x.URL,
                DepartmenName = x.Department.Name
            }).ToListAsync();
            return dtos;
        }

        public async Task<DepartmentGetSingleDto> GetSingleDepartment(string id)
        {
            Department department = await GetEntityAsync(_readRepository, id);
            DepartmentGetSingleDto dto = new DepartmentGetSingleDto
            {
                Id = department.ID.ToString(),
                Name = department.Name,
                Description = department.Description,
                LogoImage = department.LogoImage != null ? department.LogoImage : ConstantPaths.DefaultImage,
                LogoImageURL = department.LogoImage != null ? department.LogoImageURL : ConstantPaths.DefaultImageURL,
                Phone = department.Phone,
                SocialMedias = department.SocialMedias.Select(socialMedia => new SocialMediaGetDto
                {
                    Id = socialMedia.ID.ToString(),
                    Name = socialMedia.Name,
                    NickName = socialMedia.NickName,
                    URL = socialMedia.URL,
                    DepartmenName = socialMedia.Department.Name
                }).ToList()
            };
            return dto;
        }

        public async Task RecoverDepartmentAsync(string id)
        {
            Department department = await _readRepository.GetWhereAsync(x => x.isDeleted && x.ID == Guid.Parse(id), true);
            foreach (var socialMedia in department.SocialMedias)
            {
                if (socialMedia.DepartmentID == department.ID)
                {
                    _smWriteRepository.RecoverData(socialMedia);
                }
            }
            _writeRepository.RecoverData(department);
            await _writeRepository.SaveAsync();
        }

        public async Task RemovePermanentlyDepartmentAsync(string id)
        {
            Department department = await _readRepository.GetWhereAsync(x => x.ID == Guid.Parse(id), true);
            if (department == null) throw new DepartmentNotFoundException();
            foreach (var socialMedia in department.SocialMedias)
            {
                if (socialMedia.DepartmentID == department.ID)
                {
                    _smWriteRepository.RemovePermanently(socialMedia);
                }
            }
            _writeRepository.RemovePermanently(department);
            await _writeRepository.SaveAsync();
        }

        public async Task RemovePermanentlyDepartmentSocialMediaAsync(string id)
        {
            SocialMedia socialMedia = await _smReadRepository.GetWhereAsync(x => x.ID.ToString() == id, true);
            if (socialMedia == null) throw new SocialMediaNotFoundException();
            _smWriteRepository.RemovePermanently(socialMedia);
            await _smWriteRepository.SaveAsync();
        }

        public async Task UpdateDepartmentAsync(DepartmentUpdateDto dto, string id)
        {
            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;
            Department department = await GetEntityAsync(_readRepository, id);
            department.Name = dto.Name != null ? dto.Name : department.Name;
            department.Description = dto.Description != null ? dto.Description : department.Description;
            department.LogoImage = dto.file != null ?
                dto.file.UploadFile(_env.WebRootPath, FilePaths.DepartmentImagePath)
                : department.LogoImage;
            department.LogoImageURL = dto.file != null ?
                $"{scheme}://{host}/{FilePaths.DepartmentImagePath}/{department.LogoImage}"
                : department.LogoImageURL;
            _writeRepository.Update(department);
            await _writeRepository.SaveAsync();
        }

        public async Task UpdateDepartmentSocialMediaAsync(SocialMediaUpdateDto dto, string id)
        {
            var socialMedia = await GetEntityAsync(_smReadRepository, id);
            socialMedia.NickName = dto.NickName != null ? dto.NickName : socialMedia.NickName;
            socialMedia.Name = dto.Name != null ? dto.Name : socialMedia.Name;
            socialMedia.URL = dto.URL != null ? dto.URL : socialMedia.URL;
            socialMedia.DepartmentID = dto.DepartmentID != null ? (Guid)dto.DepartmentID : socialMedia.DepartmentID;
            _smWriteRepository.Update(socialMedia);
            await _smWriteRepository.SaveAsync();
        }

        public async Task UpdateTotalDepartmentAsync(DepartmentCommandDto dto, string id)
        {
            var scheme = _accessor.HttpContext.Request.Scheme;
            var host = _accessor.HttpContext.Request.Host;
            var department = await GetEntityAsync(_readRepository, id);
            department.Name = dto.Name;
            department.Description = dto.Description;
            department.LogoImage = dto.File.UploadFile(_env.WebRootPath, FilePaths.DepartmentImagePath);
            department.LogoImageURL = $"{scheme}://{host}/{FilePaths.DepartmentImagePath}/{department.LogoImage}";
            _writeRepository.Update(department);
            await _writeRepository.SaveAsync();
        }
    }
}
