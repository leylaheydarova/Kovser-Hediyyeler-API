using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;


namespace KovserHedieyyeler.Application.Features.Commands.Brands.Update.UpdateAll
{
    public class UpdateTotalBrandCommandHandler : IRequestHandler<UpdateTotalBrandCommandRequest, UpdateTotalBrandCommandResponse>
    {
        readonly IBrandReadRepository _readRepository;


        public UpdateTotalBrandCommandHandler(IBrandReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<UpdateTotalBrandCommandResponse> Handle(UpdateTotalBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var id = request.Id.ToString();
            Brand brand = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == request.Id, true);

            return new UpdateTotalBrandCommandResponse
            {
                Message = "Brend məlumatları uğurla yeniləndi!"
            };
        }
    }
}
