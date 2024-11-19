using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Domain.Enums;
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
            Address address = await _readRepository.GetWhereAsync(a => !a.isDeleted && a.ID.ToString() == request.Id && a.EmployeeID.ToString() == request.EmployeeId, true);
            if (address == null) throw new AddressNotFoundException();
            var dto = request.Dto;
            address.City = dto.City != null ? (City)dto.City : address.City;
            address.Region = dto.Region != null ? dto.Region : address.Region;
            address.District = dto.District != null ? dto.District : "";
            address.Street = dto.Street != null ? dto.Street : address.Street;
            address.Home = dto.Home != null ? dto.Home : address.Home;
            address.PostalCode = dto.PostalCode != null ? dto.PostalCode : address.PostalCode;
            address.IsCurrentAddress = dto.IsCurrentAddress != null ? (bool)dto.IsCurrentAddress : address.IsCurrentAddress;

            _writeRepository.Update(address);
            await _writeRepository.SaveAsync();

            return new UpdateEmployeeAddressCommandResponse
            {
                Message = "İşçi ünvanı uğurla dəyişdirildi!"
            };
        }

    }
}
