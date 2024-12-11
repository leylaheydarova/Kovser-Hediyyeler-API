using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Recover
{
    public class RecoverEmployeeCommandHandler : IRequestHandler<RecoverEmployeeCommandRequest, RecoverEmployeeCommandResponse>
    {
        IEmployeeReadRepository _readRepository;
        IEmployeeWriteRepository _writeRepository;
        IAddressWriteRepository _addressWriteRepository;

        public RecoverEmployeeCommandHandler(IEmployeeReadRepository readRepository, IEmployeeWriteRepository writeRepository, IAddressWriteRepository addressWriteRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _addressWriteRepository = addressWriteRepository;
        }

        public async Task<RecoverEmployeeCommandResponse> Handle(RecoverEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            Employee employee = await _readRepository.GetWhereAsync(emp => emp.isDeleted && emp.ID.ToString() == request.Id, true);
            if (employee == null) throw new NotFoundException("işçi");
            foreach (var address in employee.Addresses)
            {
                _addressWriteRepository.RecoverData(address);
            }
            _writeRepository.RecoverData(employee);
            await _writeRepository.SaveAsync();

            return new RecoverEmployeeCommandResponse()
            {
                Message = "İşçi məlumatları uğurla bərpa edilmişdir!"
            };
        }

    }
}
