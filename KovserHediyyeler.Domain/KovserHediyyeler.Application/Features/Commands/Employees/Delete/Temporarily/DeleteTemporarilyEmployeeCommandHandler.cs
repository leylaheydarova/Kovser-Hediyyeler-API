using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Temporarily
{
    public class DeleteTemporarilyEmployeeCommandHandler : IRequestHandler<DeleteTemporarilyEmployeeCommandRequest, DeleteTemporarilyEmployeeCommandResponse>
    {
        IEmployeeReadRepository _readRepository;
        IEmployeeWriteRepository _writeRepository;
        IAddressWriteRepository _addressWriteRepository;

        public DeleteTemporarilyEmployeeCommandHandler(IEmployeeReadRepository readRepository, IEmployeeWriteRepository writeRepository, IAddressWriteRepository addressWriteRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _addressWriteRepository = addressWriteRepository;
        }

        public async Task<DeleteTemporarilyEmployeeCommandResponse> Handle(DeleteTemporarilyEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            Employee employee = await _readRepository.GetWhereAsync(emp => !emp.isDeleted && emp.ID.ToString() == request.Id, true);
            if (employee == null) throw new NotFoundException("işçi");
            foreach (var address in employee.Addresses)
            {
                _addressWriteRepository.DeleteTemporarily(address);
            }
            _writeRepository.DeleteTemporarily(employee);
            await _writeRepository.SaveAsync();

            return new DeleteTemporarilyEmployeeCommandResponse
            {
                Message = "İşçi müvəqqəti silinmişdir!"
            };
        }

    }
}
