using KovserHedieyyeler.Application.DTOs.Department;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Departments;
using KovserHediyyeler.Application.Repositories.SocialMedias;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Create.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommandRequest, CreateDepartmentCommandResponse>
    {
        readonly IDepartmentWriteRepository _repository;
        readonly IHttpContextAccessor _accessor;
        readonly ISocialMediaWriteRepository _smRepository;
        readonly IWebHostEnvironment _env;

        public CreateDepartmentCommandHandler(IDepartmentWriteRepository repository, IHttpContextAccessor accessor, ISocialMediaWriteRepository smRepository, IWebHostEnvironment env)
        {
            _repository = repository;
            _accessor = accessor;
            _smRepository = smRepository;
            _env = env;
        }

        public async Task<CreateDepartmentCommandResponse> Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            DepartmentCommandDto dto = new DepartmentCommandDto
            {
                Name = request.Name,
                Description = request.Description,
                Phone = request.Phone,
                file = request.File,
                SocialMedias = request.SocialMedias
            };

            Department department = new Department
            {
                ID = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Phone = dto.Phone,
                LogoImage = dto.file.UploadFile(_env.WebRootPath, FilePaths.DepartmentImagePath),
                LogoImageURL = _accessor.HttpContext.Request.Scheme + "://" + _accessor.HttpContext.Request.Host + $"/{dto.file.FileName}"
            };


            foreach (var socialMediaDto in dto.SocialMedias)
            {
                SocialMedia socialMedia = new SocialMedia()
                {
                    Name = socialMediaDto.Name,
                    Department = department,
                    NickName = socialMediaDto.NickName,
                    URL = socialMediaDto.URL
                };
                await _smRepository.AddAsync(socialMedia);
            }

            await _repository.AddAsync(department);
            await _repository.SaveAsync();

            return new CreateDepartmentCommandResponse
            {
                StatusCode = 201,
                Message = "Şöbə uğurla əlavə edildi!"
            };
        }
    }
}
