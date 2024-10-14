using KovserHedieyyeler.Application.Exceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Brands;
using KovserHediyyeler.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Brands.Update
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, UpdateBrandCommandResponse>
    {
        readonly IBrandReadRepository _readRepository;
        readonly IBrandWriteRepository _writeRepository;

        public UpdateBrandCommandHandler(IBrandReadRepository readRepository, IBrandWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Brand brand = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), true);
            if (brand == null) throw new BrandNotFoundException();
            brand.Name = request.Dto.Name;
            brand.Image = request.Dto.file.Name;
            return new UpdateBrandCommandResponse
            {
                StatusCode = 200,
                Message = "Məlumatlar uğurla yeniləndi!"
            };
        }
    }
}
