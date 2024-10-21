using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Addresses;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Employees.Update.UpdateEmployeeAddress
{
    public class UpdateEmployeeAddressCommandHandler : IRequestHandler<UpdateEmployeeAddressCommandRequest, UpdateEmployeeAddressCommandResponse>
    {
        IAddressReadRepository _readRepository;
        IAddressWriteRepository _writeRepository;

        public UpdateEmployeeAddressCommandHandler(IAddressReadRepository readRepository, IAddressWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateEmployeeAddressCommandResponse> Handle(UpdateEmployeeAddressCommandRequest request, CancellationToken cancellationToken)
        {
            Address address = await _readRepository.GetWhereAsync(a => !a.isDeleted && a.ID.ToString() == request.Id && a.EmployeID.ToString() == request.EmployeeId, true);
            if (address == null) throw new AddressNotFoundException();
            address.City = request.Dto.City;
            address.Region = request.Dto.Region;
            address.Street = request.Dto.Street;
            address.Home = request.Dto.Home;
            address.PostalCode = request.Dto.PostalCode;
            address.IsCurrentAddress = request.Dto.IsCurrentAddress;

            _writeRepository.Update(address);
            await _writeRepository.SaveAsync();

            return new UpdateEmployeeAddressCommandResponse
            {
                Message = "İşçi ünvanı uğurla dəyişdirildi!"
            };
        }

    }
}
