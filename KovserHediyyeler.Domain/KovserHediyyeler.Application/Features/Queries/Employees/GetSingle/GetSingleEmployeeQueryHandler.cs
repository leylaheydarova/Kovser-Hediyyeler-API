using KovserHedieyyeler.Application.DTOs.Addresses;
using KovserHedieyyeler.Application.DTOs.Employees;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Employees.GetSingle
{
    public class GetSingleEmployeeQueryHandler : IRequestHandler<GetSingleEmployeeQueryRequest, GetSingleEmployeeQueryResponse>
    {
        readonly IEmployeeReadRepository _repository;

        public GetSingleEmployeeQueryHandler(IEmployeeReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetSingleEmployeeQueryResponse> Handle(GetSingleEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            Employee employee = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), false, "Addresses", "Position", "Shop", "Department");
            if (employee == null)
            {
                throw new EmployeeNotFoundException();
            }
            var address = employee.Addresses.FirstOrDefault(ad => ad.IsCurrentAddress && !ad.isDeleted);
            EmployeeGetDto dto = new EmployeeGetDto
            {
                Id = employee.ID.ToString(),
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Phone = employee.Phone,
                isRemote = employee.isRemote,
                DepartmentName = employee.Department.Name,
                PositionName = employee.Position.Status,
                ShopName = employee.Shop.Name,
                Address = new AddressGetDto
                {
                    Id = address.ID.ToString(),
                    City = address.City.ToString(),
                    Region = address.Region,
                    Street = address.Street,
                    Home = address.Home,
                    PostalCode = address.PostalCode,
                    IsCurrentAddress = address.IsCurrentAddress
                }
            };
            return new GetSingleEmployeeQueryResponse
            {
                Dto = dto
            };
        }
    }
}


