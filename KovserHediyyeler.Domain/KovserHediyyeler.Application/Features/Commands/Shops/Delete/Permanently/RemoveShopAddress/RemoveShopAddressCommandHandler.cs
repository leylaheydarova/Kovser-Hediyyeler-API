using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Features.Commands.Shops.Delete.Permanently.RemoveShopAddress;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Permanently.RemoveShopAddress
{
    public class RemoveShopAddressCommandHandler : IRequestHandler<RemoveShopAddressCommandRequest, RemoveShopAddressCommandResponse>
    {
        readonly IAddressReadRepository _readRepository;
        readonly IAddressWriteRepository _writeRepository;

        public RemoveShopAddressCommandHandler(IAddressReadRepository readRepository, IAddressWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RemoveShopAddressCommandResponse> Handle(RemoveShopAddressCommandRequest request, CancellationToken cancellationToken)
        {
            Address address = await _readRepository.GetWhereAsync(x => x.ID.ToString() == request.Id, true);
            if (address == null) throw new NotFoundException("ünvan");
            _writeRepository.RemovePermanently(address);
            await _writeRepository.SaveAsync();
            return new RemoveShopAddressCommandResponse
            {
                Message = "Mağaza ünvanı uğurla silinmişdir"
            };
        }
    }
}
