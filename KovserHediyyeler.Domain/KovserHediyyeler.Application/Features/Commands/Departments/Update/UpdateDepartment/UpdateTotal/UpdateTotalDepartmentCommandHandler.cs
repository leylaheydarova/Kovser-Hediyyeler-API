using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Departments;
using KovserHedieyyeler.Application.Repositories.Abstractions.SocialMedias;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateDepartment.UpdateTotal
{
    public class UpdateTotalDepartmentCommandHandler : IRequestHandler<UpdateTotalDepartmentCommandRequest, UpdateTotalDepartmentCommandResponse>
    {
        readonly IDepartmentReadRepository _readRepository;
        readonly IDepartmentWriteRepository _writeRepository;
        readonly IHttpContextAccessor _accessor;

        public UpdateTotalDepartmentCommandHandler(IDepartmentReadRepository readRepository, IDepartmentWriteRepository writeRepository, IHttpContextAccessor accessor)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _accessor = accessor;
        }

        public async Task<UpdateTotalDepartmentCommandResponse> Handle(UpdateTotalDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            Department department = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (department == null) throw new DepartmentNotFoundException();
            department.Name = request.Dto.Name;
            department.Description = request.Dto.Description;
            department.LogoImage = request.Dto.file.FileName;
            department.LogoImageURL = _accessor.HttpContext.Request.Scheme + "://" + _accessor.HttpContext.Request.Host + $"/{department.LogoImage}";
            _writeRepository.Update(department);
            await _writeRepository.SaveAsync();
            return new UpdateTotalDepartmentCommandResponse
            {
                Message = "Şöbə məlumatları uğurla yeniləndi!"
            };
        }
    }
}
