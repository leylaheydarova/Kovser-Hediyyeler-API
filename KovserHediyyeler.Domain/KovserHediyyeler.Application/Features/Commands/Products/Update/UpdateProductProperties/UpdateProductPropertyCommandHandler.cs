using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Products.Update.UpdateProductProperties
{
    public class UpdateProductPropertyCommandHandler : IRequestHandler<UpdateProductPropertyCommandRequest, UpdateProductPropertyCommandResponse>
    {
        readonly IProductPropertyReadRepository _readRepository;
        readonly IProductPropertyWriteRepository _writeRepository;

        public UpdateProductPropertyCommandHandler(IProductPropertyReadRepository readRepository, IProductPropertyWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateProductPropertyCommandResponse> Handle(UpdateProductPropertyCommandRequest request, CancellationToken cancellationToken)
        {
            ProductProperty property = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            if (property == null) throw new ProductPropertyNotFoundException();
            property.Name = request.Dto.Name != null ? request.Dto.Name : property.Name;
            property.Value = request.Dto.Value != null ? request.Dto.Value : property.Value;

            _writeRepository.Update(property);
            await _writeRepository.SaveAsync();

            return new UpdateProductPropertyCommandResponse
            {

                Message = "Məhsul xassəsi uğurla yeniləndi!"
            };
        }
    }
}
