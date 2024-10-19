using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Departments;
using KovserHedieyyeler.Application.Repositories.Abstractions.SocialMedias;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Delete.Temporarily
{
    public class DeleteTemporarilyDepartmentCommandHandler : IRequestHandler<DeleteTemporarilyDepartmentCommandRequest, DeleteTemporarilyDepartmentCommandResponse>
    {
        readonly IDepartmentReadRepository _readRepository;
        readonly IDepartmentWriteRepository _writeRepository;
        readonly ISocialMediaWriteRepository _socialMediaRepository;

        public DeleteTemporarilyDepartmentCommandHandler(IDepartmentReadRepository readRepository, IDepartmentWriteRepository writeRepository, ISocialMediaWriteRepository socialMediaRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task<DeleteTemporarilyDepartmentCommandResponse> Handle(DeleteTemporarilyDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            Department department = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), true);
            if (department == null) throw new DepartmentNotFoundException();
            foreach (var socialMedia in department.SocialMedias)
            {
                if (socialMedia.DepartmentID == department.ID)
                {
                    _socialMediaRepository.DeleteTemporarily(socialMedia);
                }
            }
            _writeRepository.DeleteTemporarily(department);
            await _writeRepository.SaveAsync();
            return new DeleteTemporarilyDepartmentCommandResponse
            {
                Message = "Şöbə müvəqqəti silindi!"
            };
        }
    }
}
