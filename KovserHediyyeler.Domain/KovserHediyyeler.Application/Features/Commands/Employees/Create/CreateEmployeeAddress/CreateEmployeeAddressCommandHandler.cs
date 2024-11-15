using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Create.CreateEmployeeAddress
{
    public class CreateEmployeeAddressCommandHandler : IRequestHandler<CreateEmployeeAddressCommandRequest, CreateEmployeeAddressCommandResponse>
    {
        readonly IAddressWriteRepository _repository;

        public CreateEmployeeAddressCommandHandler(IAddressWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateEmployeeAddressCommandResponse> Handle(CreateEmployeeAddressCommandRequest request, CancellationToken cancellationToken)
        {
            Address address = new Address
            {
                City = request.Dto.City,
                Region = request.Dto.Region,
                Street = request.Dto.Street,
                Home = request.Dto.Home,
                PostalCode = request.Dto.PostalCode,
                IsCurrentAddress = request.Dto.IsCurrentAddress,
                EmployeeID = Guid.Parse(request.EmployeeId)
            };

            await _repository.AddAsync(address);
            await _repository.SaveAsync();

            return new CreateEmployeeAddressCommandResponse
            {
                StatusCode = 201,
                Message = "İşçi ünvanı uğurla əlavə edilmişdir!"
            };
        }

    }
}
