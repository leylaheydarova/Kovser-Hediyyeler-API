using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Departments;
using KovserHedieyyeler.Application.Repositories.Abstractions.SocialMedias;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Update
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommandRequest, UpdateDepartmentCommandResponse>
    {
        readonly IDepartmentReadRepository _readRepository;
        readonly IDepartmentWriteRepository _writeRepository;
        readonly IHttpContextAccessor _accessor;
        public UpdateDepartmentCommandHandler(IDepartmentReadRepository readRepository, IDepartmentWriteRepository writeRepository, IHttpContextAccessor accessor, ISocialMediaReadRepository socialMediaReadRepository, ISocialMediaWriteRepository socialMediaWriteRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _accessor = accessor;;
        }

        public async Task<UpdateDepartmentCommandResponse> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            Department department = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), true, nameof(SocialMedia));
            if (department == null) throw new DepartmentNotFoundException();
            department.Name = request.Dto.Name;
            department.Description = request.Dto.Description;
            department.LogoImage = request.Dto.file.Name;
            department.LogoImageURL = _accessor.HttpContext.Request.Scheme + "/" + _accessor.HttpContext.Request.Host + $"/{department.LogoImage}";
            foreach (var socialMediaDto in request.Dto.SocialMedias)
            {
                var socialMedia = department.SocialMedias.FirstOrDefault(y => y.DepartmentID == Guid.Parse(request.Id) && y.NickName == request.Nickname);
                if (socialMedia != null)
                {
                    socialMedia.Name = socialMediaDto.Name;
                    socialMedia.URL = socialMediaDto.URL;
                    socialMedia.NickName = socialMediaDto.NickName;
                }
            }
            _writeRepository.Update(department);
            await _writeRepository.SaveAsync();
            return new UpdateDepartmentCommandResponse
            {
                Message = "Şöbə məlumatları uğurla yeniləndi!"
            };
        }
    }
}
