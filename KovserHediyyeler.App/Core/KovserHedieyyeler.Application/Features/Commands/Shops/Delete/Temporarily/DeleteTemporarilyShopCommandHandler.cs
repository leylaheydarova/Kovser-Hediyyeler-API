using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Addresses;
using KovserHedieyyeler.Application.Repositories.Abstractions.Shops;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Shops.Delete.Temporarily
{
    public class DeleteTemporarilyShopCommandHandler : IRequestHandler<DeleteTemporarilyShopCommandRequest, DeleteTemporarilyShopCommandResponse>
    {
        IShopReadRepository _readRepository;
        IShopWriteRepository _writeRepository;
        IAddressWriteRepository _addressWriteRepository;

        public DeleteTemporarilyShopCommandHandler(IShopReadRepository readRepository, IShopWriteRepository writeRepository, IAddressWriteRepository addressWriteRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _addressWriteRepository = addressWriteRepository;
        }

        public async Task<DeleteTemporarilyShopCommandResponse> Handle(DeleteTemporarilyShopCommandRequest request, CancellationToken cancellationToken)
        {
            Shop shop = await _readRepository.GetWhereAsync(sh => !sh.isDeleted && sh.ID.ToString() == request.Id, true);
            if (shop == null) throw new ShopNotFoundException();
            foreach(var address in shop.Addresses)
            {
                _addressWriteRepository.DeleteTemporarily(address);
            }
            _writeRepository.DeleteTemporarily(shop);
            await _writeRepository.SaveAsync();

            return new DeleteTemporarilyShopCommandResponse
            {
                Message = "Mağaza müvəqqəti silinmişdir!"
            };
        }
    }
}
