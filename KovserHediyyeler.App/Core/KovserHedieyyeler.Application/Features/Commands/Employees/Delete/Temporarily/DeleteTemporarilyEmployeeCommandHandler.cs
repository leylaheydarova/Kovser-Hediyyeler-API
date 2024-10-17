using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Permanently;
using KovserHedieyyeler.Application.Repositories.Abstractions.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Temporarily
{
    public class DeleteTemporarilyEmployeeCommandHandler : IRequestHandler<DeleteTemporarilyEmployeeCommandRequest, DeleteTemporarilyEmployeeCommandResponse>
    {
        readonly IEmployeeReadRepository _readRepository;
        readonly IEmployeeWriteRepository _writeRepository;

        public DeleteTemporarilyEmployeeCommandHandler(IEmployeeReadRepository readRepository, IEmployeeWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<DeleteTemporarilyEmployeeCommandResponse> Handle(DeleteTemporarilyEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            Employee employee = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), true);
            if (employee == null) throw new EmployeeNotFoundException();
            _writeRepository.DeleteTemporarily(employee);
            await _writeRepository.SaveAsync();

            return new DeleteTemporarilyEmployeeCommandResponse
            {
                Message = "İşçi uğurla silindi!"
            };
        }
    }
}
