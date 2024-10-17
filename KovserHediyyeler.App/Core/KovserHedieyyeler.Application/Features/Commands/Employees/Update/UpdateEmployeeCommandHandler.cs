using KovserHedieyyeler.Application.Repositories.Abstractions.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Update
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeCommandResponse>
    {
        readonly IEmployeeReadRepository _readRepository;
        readonly IEmployeeWriteRepository _writeRepository;

        public UpdateEmployeeCommandHandler(IEmployeeReadRepository readRepository, IEmployeeWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            Employee employee = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), true);
            employee.FirstName = request.Dto.FirstName;
            employee.LastName = request.Dto.LastName;
            employee.Phone = request.Dto.Phone;
            employee.isRemote = request.Dto.isRemote;
            employee.DepartmentID = request.Dto.DepartmentID;
            employee.ShopID = request.Dto.ShopID;
            employee.PositionID = request.Dto.PositionID;
            
            foreach( var addressDto in request.Dto.Addresses)
            {
                var address = new Address
                {
                    City = addressDto.City,
                    Region = addressDto.Region,
                    Street = addressDto.Street,
                    PostalCode = addressDto.PostalCode,
                    Home = addressDto.Home,
                    IsCurrentAddress = addressDto.IsCurrentAddress
                };
                employee.Address.Add(address);
            }
            _writeRepository.Update(employee);
            await _writeRepository.SaveAsync();

            return new UpdateEmployeeCommandResponse
            {
                Message = "İşçi məlumatları uğurla yeniləndi"
            };
        }
    }
}
