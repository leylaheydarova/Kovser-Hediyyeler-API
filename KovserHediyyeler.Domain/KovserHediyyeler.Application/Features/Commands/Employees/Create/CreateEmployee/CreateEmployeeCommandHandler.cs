using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Create.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommandRequest, CreateEmployeeCommandResponse>
    {
        readonly IEmployeeWriteRepository _repository;
        readonly IAddressWriteRepository _addressWriteRepository;

        public CreateEmployeeCommandHandler(IEmployeeWriteRepository repository, IAddressWriteRepository addressWriteRepository)
        {
            _repository = repository;
            _addressWriteRepository = addressWriteRepository;
        }

        public async Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            Employee employee = new Employee
            {
                ID = Guid.NewGuid(),
                FirstName = request.Dto.FirstName,
                LastName = request.Dto.LastName,
                Phone = request.Dto.Phone,
                DepartmentID = request.Dto.DepartmentID,
                ShopID = request.Dto.ShopID,
                isRemote = request.Dto.isRemote,
                PositionID = request.Dto.PositionID
            };

            foreach (var addressDto in request.Dto.Addresses)
            {
                Address address = new Address
                {
                    ID = Guid.NewGuid(),
                    City = addressDto.City,
                    Region = addressDto.Region,
                    District = addressDto.District == null ? "" : addressDto.District,
                    Street = addressDto.Street,
                    Home = addressDto.Home,
                    PostalCode = addressDto.PostalCode,
                    IsCurrentAddress = addressDto.IsCurrentAddress,
                    EmployeeID = employee.ID
                };
                //shop.Addresses.Add(address);
                try
                {
                    await _addressWriteRepository.AddAsync(address);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }

            try
            {
                await _repository.AddAsync(employee);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            await _repository.SaveAsync();

            return new CreateEmployeeCommandResponse
            {
                StatusCode = 201,
                Message = "İşçi uğurla əlavə edildi!"
            };
        }
    }
}
