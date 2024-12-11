using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Application.Repositories.Shops;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Permanently.RemoveShop
{
    public class RemovePermanentlyShopCommandHandler : IRequestHandler<RemovePermanentlyShopCommandRequest, RemovePermanentlyShopCommandResponse>
    {
        readonly IShopReadRepository _readRepository;
        readonly IShopWriteRepository _writeRepository;
        readonly IAddressWriteRepository _addressWriteRepository;

        public RemovePermanentlyShopCommandHandler(IShopReadRepository readRepository, IShopWriteRepository writeRepository, IAddressWriteRepository addressWriteRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _addressWriteRepository = addressWriteRepository;
        }

        public async Task<RemovePermanentlyShopCommandResponse> Handle(RemovePermanentlyShopCommandRequest request, CancellationToken cancellationToken)
        {
            Shop shop = await _readRepository.GetWhereAsync(x => x.ID.ToString() == request.Id, true);
            if (shop == null) throw new NotFoundException("mağaza");
            foreach (var address in shop.Addresses)
            {
                _addressWriteRepository.RemovePermanently(address);
            }
            _writeRepository.RemovePermanently(shop);
            await _writeRepository.SaveAsync();

            return new RemovePermanentlyShopCommandResponse
            {
                Message = "Mağaza uğurla silinmişdir"
            };
        }
    }
}
