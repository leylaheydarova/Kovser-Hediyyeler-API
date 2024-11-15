using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Products;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Delete.Permanently.RemoveProperty
{
    public class RemoveProductPropertyCommandHandler : IRequestHandler<RemoveProductPropertyCommandRequest, RemoveProductPropertyCommandResponse>
    {
        readonly IProductPropertyReadRepository _readRepository;
        readonly IProductPropertyWriteRepository _writeRepository;

        public RemoveProductPropertyCommandHandler(IProductPropertyReadRepository readRepository, IProductPropertyWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RemoveProductPropertyCommandResponse> Handle(RemoveProductPropertyCommandRequest request, CancellationToken cancellationToken)
        {
            ProductProperty property = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (property == null) throw new ProductPropertyNotFoundException();
            _writeRepository.RemovePermanently(property);
            await _writeRepository.SaveAsync();

            return new RemoveProductPropertyCommandResponse
            {
                Message = "Məhsul xassəsi uğurla silinmişdir!"
            };
        }

    }
}
