using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Recover
{
    public class RecoverBrandCommandHandler : IRequestHandler<RecoverBrandCommandRequest, RecoverBrandCommandResponse>
    {
        readonly IBrandReadRepository _readRepository;
        readonly IBrandWriteRepository _writeRepository;

        public RecoverBrandCommandHandler(IBrandReadRepository readRepository, IBrandWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<RecoverBrandCommandResponse> Handle(RecoverBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Brand brand = await _readRepository.GetWhereAsync(b => b.isDeleted && b.ID.ToString() == request.Id, true);
            if (brand == null) throw new BadRequestException();
            _writeRepository.RecoverData(brand);
            await _writeRepository.SaveAsync();
            return new RecoverBrandCommandResponse
            {
                Message = "Brend məlumatları uğurla bərpa edilmişdir!"
            };
            
        }
    }
}
