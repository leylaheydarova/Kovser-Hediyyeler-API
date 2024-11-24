using KovserHediyyeler.Application.Repositories.Brands;
using MediatR;

namespace KovserHediyyeler.Application.Features.Commands.Brands.Delete.Clear
{
    public class ClearBrandsCommandHandler : IRequestHandler<ClearBrandsCommandRequest, ClearBrandsCommandResponse>
    {
        readonly IBrandReadRepository _readRepository;
        readonly IBrandWriteRepository _writeRepository;

        public ClearBrandsCommandHandler(IBrandReadRepository readRepository, IBrandWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<ClearBrandsCommandResponse> Handle(ClearBrandsCommandRequest request, CancellationToken cancellationToken)
        {
            var brands = _readRepository.GetAll(true);
            foreach (var brand in brands)
            {
                _writeRepository.RemovePermanently(brand);
            }
            await _writeRepository.SaveAsync();
            return new ClearBrandsCommandResponse
            {
                Message = "Məlumatlar uğurla təmizləndi!"
            };
        }
    }
}
