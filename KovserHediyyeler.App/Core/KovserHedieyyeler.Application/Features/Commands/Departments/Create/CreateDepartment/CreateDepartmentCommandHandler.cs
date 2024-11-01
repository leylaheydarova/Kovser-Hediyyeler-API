using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Department;
using KovserHedieyyeler.Application.Repositories.Abstractions.Departments;
using KovserHedieyyeler.Application.Repositories.Abstractions.SocialMedias;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Create.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommandRequest, CreateDepartmentCommandResponse>
    {
        readonly IDepartmentWriteRepository _repository;
        readonly IHttpContextAccessor _accessor;
        readonly ISocialMediaWriteRepository _smRepository;

        public CreateDepartmentCommandHandler(IDepartmentWriteRepository repository, IHttpContextAccessor accessor, ISocialMediaWriteRepository smRepository)
        {
            _repository = repository;
            _accessor = accessor;
            _smRepository = smRepository;
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
                LogoImage = dto.file.FileName,
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
