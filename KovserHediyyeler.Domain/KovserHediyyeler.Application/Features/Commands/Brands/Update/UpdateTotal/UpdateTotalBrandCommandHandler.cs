using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;


namespace KovserHedieyyeler.Application.Features.Commands.Brands.Update.UpdateAll
{
    public class UpdateTotalBrandCommandHandler : IRequestHandler<UpdateTotalBrandCommandRequest, UpdateTotalBrandCommandResponse>
    {
        readonly IBrandReadRepository _readRepository;
        readonly IBrandWriteRepository _writeRepository;
        readonly IWebHostEnvironment _env;
        readonly IHttpContextAccessor _accessor;

        public UpdateTotalBrandCommandHandler(IBrandReadRepository readRepository, IBrandWriteRepository writeRepository, IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _env = env;
            _accessor = accessor;
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
