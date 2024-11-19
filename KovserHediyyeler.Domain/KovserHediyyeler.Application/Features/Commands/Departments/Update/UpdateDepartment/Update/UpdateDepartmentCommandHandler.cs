using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Departments;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateDepartment.Update
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommandRequest, UpdateDepartmentCommandResponse>
    {
        readonly IDepartmentReadRepository _readRepository;
        readonly IDepartmentWriteRepository _writeRepository;
        readonly IHttpContextAccessor _accessor;
        readonly IWebHostEnvironment _env;

        public UpdateDepartmentCommandHandler(IDepartmentReadRepository readRepository, IDepartmentWriteRepository writeRepository, IHttpContextAccessor accessor, IWebHostEnvironment env)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _accessor = accessor;
            _env = env;
        }

        public async Task<UpdateDepartmentCommandResponse> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            Department department = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true, "SocialMedias");
            if (department == null) throw new DepartmentNotFoundException();
            department.Name = request.Dto.Name != null ? request.Dto.Name : department.Name;
            department.Description = request.Dto.Description != null ? request.Dto.Description : department.Description;
            department.LogoImage = request.Dto.file != null ?
                request.Dto.file.UploadFile(_env.WebRootPath, FilePaths.DepartmentImagePath)
                : department.LogoImage;
            department.LogoImageURL = request.Dto.file != null ?
                _accessor.HttpContext.Request.Scheme + "://" + _accessor.HttpContext.Request.Host + $"/{department.LogoImage}"
                : department.LogoImageURL;
            _writeRepository.Update(department);
            await _writeRepository.SaveAsync();
            return new UpdateDepartmentCommandResponse
            {
                Message = "Məlumat uğurla yeniləndi!"
            };
        }
    }
}
