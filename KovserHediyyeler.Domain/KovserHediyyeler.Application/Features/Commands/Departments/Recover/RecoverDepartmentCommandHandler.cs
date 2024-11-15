using KovserHediyyeler.Application.Repositories.Departments;
using KovserHediyyeler.Application.Repositories.SocialMedias;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Recover
{
    public class RecoverDepartmentCommandHandler : IRequestHandler<RecoverDepartmentCommandRequest, RecoverDepartmentCommandResponse>
    {
        readonly IDepartmentReadRepository _readRepository;
        readonly IDepartmentWriteRepository _writeRepository;
        readonly ISocialMediaWriteRepository _socialMediaRepository;

        public RecoverDepartmentCommandHandler(IDepartmentReadRepository readRepository, IDepartmentWriteRepository writeRepository, ISocialMediaWriteRepository socialMediaRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task<RecoverDepartmentCommandResponse> Handle(RecoverDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            Department department = await _readRepository.GetWhereAsync(x => x.isDeleted && x.ID == Guid.Parse(request.Id), true);
            foreach (var socialMedia in department.SocialMedias)
            {
                if (socialMedia.DepartmentID == department.ID)
                {
                    _socialMediaRepository.RecoverData(socialMedia);
                }
            }
            _writeRepository.RecoverData(department);
            await _writeRepository.SaveAsync();
            return new RecoverDepartmentCommandResponse
            {
                Message = "Şöbə məlumatları uğurla bərpa edilmişdir!"
            };
        }
    }
}
