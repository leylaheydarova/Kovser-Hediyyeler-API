using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Delete.Permanently
{
    public class RemovePermanentlyBrandCommandHandler : IRequestHandler<RemovePermanentlyBrandCommandRequest, RemovePermanentlyBrandCommandResponse>
    {
        readonly IBrandReadRepository _readRepository;
        readonly IBrandWriteRepository _writeRepository;

        public RemovePermanentlyBrandCommandHandler(IBrandReadRepository readRepository, IBrandWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RemovePermanentlyBrandCommandResponse> Handle(RemovePermanentlyBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Brand brand = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), true);
            if (brand == null)
            {
                throw new BrandNotFoundException();
            }
            _writeRepository.RemovePermanently(brand);
            await _writeRepository.SaveAsync();
            return new RemovePermanentlyBrandCommandResponse
            {
                StatusCode = 200,
                Message = "Brend uğurla silindi!"
            };
        }
    }
}
