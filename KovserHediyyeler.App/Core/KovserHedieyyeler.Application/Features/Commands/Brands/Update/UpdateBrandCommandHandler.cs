using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace KovserHedieyyeler.Application.Features.Commands.Brands.Update
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, UpdateBrandCommandResponse>
    {
        readonly IBrandReadRepository _readRepository;
        readonly IBrandWriteRepository _writeRepository;
        readonly IHttpContextAccessor _accessor;

        public UpdateBrandCommandHandler(IBrandReadRepository readRepository, IBrandWriteRepository writeRepository, IHttpContextAccessor accessor)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _accessor = accessor;
        }

        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var id = request.Id.ToString();
            Brand brand = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id ,true);
            if (brand == null) throw new BrandNotFoundException();
            brand.Name = request.Dto.Name;
            brand.Image = request.Dto.file.FileName;
            brand.ImageURL = _accessor.HttpContext.Request.Scheme + "://" + _accessor.HttpContext.Request.Host + $"/{brand.Image}";

            _writeRepository.Update(brand);
            await _writeRepository.SaveAsync();
            return new UpdateBrandCommandResponse
            {
                Message = "Brend məlumatları uğurla yeniləndi!"
            };
        }
    }
}
