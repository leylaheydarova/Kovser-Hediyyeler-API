using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Departments;
using KovserHedieyyeler.Application.Repositories.Abstractions.SocialMedias;
using KovserHediyyeler.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Departments.Delete.Permanently
{
    public class RemovePermanentlyDepartmentCommandHandler : IRequestHandler<RemovePermanentlyDepartmentCommandRequest, RemovePermanentlyDepartmentCommandResponse>
    {
        readonly IDepartmentReadRepository _readRepository;
        readonly IDepartmentWriteRepository _writeRepository;
        readonly ISocialMediaWriteRepository _socialMediaRepository;

        public RemovePermanentlyDepartmentCommandHandler(IDepartmentReadRepository readRepository, IDepartmentWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RemovePermanentlyDepartmentCommandResponse> Handle(RemovePermanentlyDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            Department department = await _readRepository.GetWhereAsync(x => x.ID == Guid.Parse(request.Id), true);
            if (department == null) throw new DepartmentNotFoundException();
            foreach (var socialMedia in department.SocialMedias)
            {
                if (socialMedia.DepartmentID == department.ID)
                { 
                    _socialMediaRepository.RemovePermanently(socialMedia);
                    await _socialMediaRepository.SaveAsync();
                }
            }
            _writeRepository.RemovePermanently(department);
            await _writeRepository.SaveAsync();
            return new RemovePermanentlyDepartmentCommandResponse
            {
                Message = "Şöbə uğurla silindi!"
            };
        }
    }
}
