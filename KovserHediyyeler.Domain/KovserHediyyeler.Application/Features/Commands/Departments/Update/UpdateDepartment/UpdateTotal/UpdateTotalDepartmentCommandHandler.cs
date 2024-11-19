using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Extentions;
using KovserHediyyeler.Application.Repositories.Departments;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Update.UpdateDepartment.UpdateTotal
{
    public class UpdateTotalDepartmentCommandHandler : IRequestHandler<UpdateTotalDepartmentCommandRequest, UpdateTotalDepartmentCommandResponse>
    {
        readonly IDepartmentReadRepository _readRepository;
        readonly IDepartmentWriteRepository _writeRepository;

        public UpdateTotalDepartmentCommandHandler(IDepartmentReadRepository readRepository, IDepartmentWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateTotalDepartmentCommandResponse> Handle(UpdateTotalDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            FileConstants constant = new FileConstants();
            Department department = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (department == null) throw new DepartmentNotFoundException();
            department.Name = request.Dto.Name;
            department.Description = request.Dto.Description;
            department.LogoImage = request.Dto.file.UploadFile(constant.root, FilePaths.DepartmentImagePath);
            department.LogoImageURL = $"{constant.scheme}://{constant.host}/{department.LogoImage}";
            _writeRepository.Update(department);
            await _writeRepository.SaveAsync();
            return new UpdateTotalDepartmentCommandResponse
            {
                Message = "Şöbə məlumatları uğurla yeniləndi!"
            };
        }
    }
}
