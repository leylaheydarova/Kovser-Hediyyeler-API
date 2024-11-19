
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Update.UpdateShopAddress
{
    public class UpdateShopAddressCommandHandler : IRequestHandler<UpdateShopAddressCommandRequest, UpdateShopAddressCommandResponse>
    {
        IAddressReadRepository _readRepository;
        IAddressWriteRepository _writeRepository;

        public UpdateShopAddressCommandHandler(IAddressReadRepository readRepository, IAddressWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateShopAddressCommandResponse> Handle(UpdateShopAddressCommandRequest request, CancellationToken cancellationToken)
        {
            Address address = await _readRepository.GetWhereAsync(a => !a.isDeleted && a.ID.ToString() == request.Id && a.ShopID.ToString() == request.ShopID, true);
            if (address == null) throw new AddressNotFoundException();
            var dto = request.Dto;
            address.City = dto.City is not null ? (City)dto.City : address.City;
            address.Region = dto.Region is not null ? dto.Region : address.Region;
            address.District = dto.District is not null ? dto.District : "";
            address.Street = dto.Street is not null ? dto.Street : address.Street;
            address.Home = dto.Home is not null ? dto.Home : address.Home;
            address.PostalCode = dto.PostalCode is not null ? dto.PostalCode : address.PostalCode;
            address.IsCurrentAddress = dto.IsCurrentAddress is not null ? (bool)dto.IsCurrentAddress : address.isDeleted;

            _writeRepository.Update(address);
            await _writeRepository.SaveAsync();

            return new UpdateShopAddressCommandResponse
            {
                Message = "Mağaza ünvanı uğurla dəyişdirildi!"
            };
        }
    }
}


