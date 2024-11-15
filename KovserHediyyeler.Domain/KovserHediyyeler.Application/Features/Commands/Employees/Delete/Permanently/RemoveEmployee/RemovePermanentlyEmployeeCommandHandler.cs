using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Permanently.RemoveEmployee
{
    public class RemovePermanentlyEmployeeCommandHandler : IRequestHandler<RemovePermanentlyEmployeeCommandRequest, RemovePermanentlyEmployeeCommandResponse>
    {
        readonly IEmployeeReadRepository _readRepository;
        readonly IEmployeeWriteRepository _writeRepository;
        readonly IAddressWriteRepository _addressWriteRepository;

        public RemovePermanentlyEmployeeCommandHandler(IEmployeeReadRepository readRepository, IEmployeeWriteRepository writeRepository, IAddressWriteRepository addressWriteRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _addressWriteRepository = addressWriteRepository;
        }

        public async Task<RemovePermanentlyEmployeeCommandResponse> Handle(RemovePermanentlyEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            Employee employee = await _readRepository.GetWhereAsync(x => x.ID.ToString() == request.Id, true, "Addresses");
            if (employee == null) throw new EmployeeNotFoundException();
            foreach (var address in employee.Addresses)
            {
                _addressWriteRepository.RemovePermanently(address);
            }
            _writeRepository.RemovePermanently(employee);
            await _writeRepository.SaveAsync();

            return new RemovePermanentlyEmployeeCommandResponse
            {
                Message = "İşçi uğurla silinmişdir"
            };
        }
    }
}
