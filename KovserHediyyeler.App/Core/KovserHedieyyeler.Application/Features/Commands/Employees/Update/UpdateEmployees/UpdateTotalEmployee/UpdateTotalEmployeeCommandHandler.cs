using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Update.UpdateEmployees.UpdateEmployee
{
    public class UpdateTotalEmployeeCommandHandler : IRequestHandler<UpdateTotalEmployeeCommandRequest, UpdateTotalEmployeeCommandResponse>
    {
        readonly IEmployeeReadRepository _readRepository;
        readonly IEmployeeWriteRepository _writeRepository;

        public UpdateTotalEmployeeCommandHandler(IEmployeeReadRepository readRepository, IEmployeeWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateTotalEmployeeCommandResponse> Handle(UpdateTotalEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            Employee employee = await _readRepository.GetWhereAsync(emp => !emp.isDeleted && emp.ID.ToString() == request.Id, true);
            if (employee == null) throw new EmployeeNotFoundException();
            employee.FirstName = request.Dto.FirstName;
            employee.LastName = request.Dto.LastName;
            employee.Phone = request.Dto.Phone;
            employee.DepartmentID = request.Dto.DepartmentID;
            employee.ShopID = request.Dto.ShopID;
            employee.isRemote = request.Dto.isRemote;
            employee.PositionID = request.Dto.PositionID;

            _writeRepository.Update(employee);
            await _writeRepository.SaveAsync();

            return new UpdateTotalEmployeeCommandResponse
            {
                Message = "İşçi məlumatları uğurla yeniləndi"
            };
        }

    }
}

