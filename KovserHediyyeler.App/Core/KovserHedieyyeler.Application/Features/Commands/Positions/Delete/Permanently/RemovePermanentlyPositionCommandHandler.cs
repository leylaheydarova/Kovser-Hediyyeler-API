using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Employees;
using KovserHedieyyeler.Application.Repositories.Abstractions.Positions;
using KovserHedieyyeler.Application.Repositories.Interfaces.Positions;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Position position =await _readRepository.GetWhereAsync(x => x.ID.ToString() == request.Id, true, "Employees");
            if (position == null) throw new PositionNotFoundException();
            var query = _employeeReadRepository.GetAllWhere(e => e.PositionID == position.ID, false);
            List<Employee> employees = new List<Employee>();
            employees = await query.ToListAsync();
            //if(employees.Count > 0)
            //{
            //    foreach (var employee in employees)
            //    {
            //        //set new position
            //    }
            //}
            _writeRepository.RemovePermanently(position);
            await _writeRepository.SaveAsync();
            return new RemovePermanentlyPositionCommandResponse
            {
                Message = "Vəzifə uğurla silinmişdir!"
            };
        }
    }
}
