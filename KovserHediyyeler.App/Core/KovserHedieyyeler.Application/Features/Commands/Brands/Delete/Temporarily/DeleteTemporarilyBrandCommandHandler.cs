using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Delete.Temporarily
{
    public class DeleteTemporarilyBrandCommandHandler : IRequestHandler<DeleteTemporarilyBrandCommandRequest, DeleteTemporarilyBrandCommandResponse>
    {
        readonly IBrandReadRepository _readRepository;
        readonly IBrandWriteRepository _writeRepository;

        public DeleteTemporarilyBrandCommandHandler(IBrandReadRepository readRepository, IBrandWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<DeleteTemporarilyBrandCommandResponse> Handle(DeleteTemporarilyBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Brand brand = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), true);
            if (brand == null)
            {
                throw new BrandNotFoundException();
            }
            _writeRepository.DeleteTemporarily(brand);
            await _writeRepository.SaveAsync();
            return new DeleteTemporarilyBrandCommandResponse
            {
                StatusCode = 200,
                Message = "Brend müvəqqəti silindi!"
            };
        }
    }
}
