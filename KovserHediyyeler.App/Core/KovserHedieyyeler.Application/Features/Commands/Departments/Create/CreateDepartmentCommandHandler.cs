using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Department;
using KovserHedieyyeler.Application.Repositories.Abstractions.Departments;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Create
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommandRequest, CreateDepartmentCommandResponse>
    {
        readonly IDepartmentWriteRepository _repository;
        readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IDepartmentWriteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateDepartmentCommandResponse> Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            DepartmentCommandDto dto = new DepartmentCommandDto
            {
                Name = request.Name,
                Description = request.Description,
                Phone = request.Phone,
                file = request.file,
                
            };

            Department department = _mapper.Map<Department>(dto);


            foreach (var socialMediaDto in dto.SocialMedias)
            {
                socialMediaDto.Name = request.LinkName;
                socialMediaDto.URL = request.URL;
                socialMediaDto.NickName = request.NickName;

                SocialMedia socialMedia = _mapper.Map<SocialMedia>(socialMediaDto);
                department.SocialMedias.Add(socialMedia);
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
