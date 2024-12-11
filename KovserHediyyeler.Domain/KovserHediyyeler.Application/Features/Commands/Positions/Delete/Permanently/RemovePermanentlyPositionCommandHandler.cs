using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Application.Repositories.Positions;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KovserHedieyyeler.Application.Features.Commands.Positions.Delete.Permanently
{
    public class RemovePermanentlyPositionCommandHandler : IRequestHandler<RemovePermanentlyPositionCommandRequest, RemovePermanentlyPositionCommandResponse>
    {
        readonly IPositionReadRepository _readRepository;
        readonly IPositionWriteRepository _writeRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;

        public RemovePermanentlyPositionCommandHandler(IPositionReadRepository readRepository, IPositionWriteRepository writeRepository, IEmployeeWriteRepository employeeWriteRepository, IEmployeeReadRepository employeeReadRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _employeeWriteRepository = employeeWriteRepository;
            _employeeReadRepository = employeeReadRepository;
        }

        public async Task<RemovePermanentlyPositionCommandResponse> Handle(RemovePermanentlyPositionCommandRequest request, CancellationToken cancellationToken)
        {
            Position position = await _readRepository.GetWhereAsync(x => x.ID.ToString() == request.Id, true, "Employees");
            if (position == null) throw new NotFoundException("vəzifə");
            var query = _employeeReadRepository.GetAllWhere(e => e.PositionID == position.ID, false);
            List<Employee> employees = new List<Employee>();
            employees = await query.ToListAsync();
            _writeRepository.RemovePermanently(position);
            await _writeRepository.SaveAsync();
            return new RemovePermanentlyPositionCommandResponse
            {
                Message = "Vəzifə uğurla silinmişdir!"
            };
        }
    }
}
