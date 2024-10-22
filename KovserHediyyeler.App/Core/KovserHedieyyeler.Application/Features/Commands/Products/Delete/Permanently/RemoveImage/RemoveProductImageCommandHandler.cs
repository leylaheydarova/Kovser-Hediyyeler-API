using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Products;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveImage
{
    public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest, RemoveProductImageCommandResponse>
    {
        readonly IProductImageFileReadRepository _readRepository;
        readonly IProductImageFileWriteRepository _writeRepository;

        public RemoveProductImageCommandHandler(IProductImageFileReadRepository readRepository, IProductImageFileWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            ProductImageFile image = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (image == null) throw new ProductImageNotFoundException();
            _writeRepository.RemovePermanently(image);
            await _writeRepository.SaveAsync();

            return new RemoveProductImageCommandResponse
            {
                Message = "Məhsul şəkli uğurl silinmişdir!"
            };
        }
    }
}
