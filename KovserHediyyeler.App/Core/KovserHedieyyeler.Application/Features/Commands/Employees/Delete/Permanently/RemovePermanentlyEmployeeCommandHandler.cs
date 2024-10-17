using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Delete.Permanently
{
    public class RemovePermanentlyEmployeeCommandHandler : IRequestHandler<RemovePermanentlyEmployeeCommandRequest, RemovePermanentlyEmployeeCommandResponse>
    {
        readonly IEmployeeReadRepository _readRepository;
        readonly IEmployeeWriteRepository _writeRepository;

        public RemovePermanentlyEmployeeCommandHandler(IEmployeeReadRepository readRepository, IEmployeeWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RemovePermanentlyEmployeeCommandResponse> Handle(RemovePermanentlyEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            Employee employee = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), true);
            if (employee == null) throw new EmployeeNotFoundException();
            _writeRepository.RemovePermanently(employee);
            await _writeRepository.SaveAsync();

            return new RemovePermanentlyEmployeeCommandResponse
            {
                Message = "İşçi müvəqqəti olaraq silindi!"
            };
        }
    }
}
