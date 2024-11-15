using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Permanently.RemoveShopAddress
{
    public class RemovePermanentlyShopAddressCommandHandler : IRequestHandler<RemovePermanentlyShopAddressCommandRequest, RemovePermanentlyShopAddressCommandResponse>
    {
        readonly IAddressReadRepository _readRepository;
        readonly IAddressWriteRepository _writeRepository;

        public RemovePermanentlyShopAddressCommandHandler(IAddressReadRepository readRepository, IAddressWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RemovePermanentlyShopAddressCommandResponse> Handle(RemovePermanentlyShopAddressCommandRequest request, CancellationToken cancellationToken)
        {
            Address address = await _readRepository.GetWhereAsync(x => x.ID.ToString() == request.Id, true);
            if (address == null) throw new AddressNotFoundException();
            _writeRepository.RemovePermanently(address);
            await _writeRepository.SaveAsync();

            return new RemovePermanentlyShopAddressCommandResponse
            {
                Message = "Mağaza ünvanı uğurla silinmişdir"
            };
        }
    }
}
