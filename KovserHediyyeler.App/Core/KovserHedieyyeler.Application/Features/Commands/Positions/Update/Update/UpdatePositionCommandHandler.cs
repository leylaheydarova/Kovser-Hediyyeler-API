using KovserHedieyyeler.Application.Repositories.Abstractions.Positions;
using KovserHedieyyeler.Application.Repositories.Interfaces.Positions;
using KovserHediyyeler.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Positions.Update.Update
{
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommandRequest, UpdatePositionCommandResponse>
    {
        readonly IPositionReadRepository _readRepository;
        readonly IPositionWriteRepository _writeRepository;

        public UpdatePositionCommandHandler(IPositionReadRepository readRepository, IPositionWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdatePositionCommandResponse> Handle(UpdatePositionCommandRequest request, CancellationToken cancellationToken)
        {
            Position position = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            position.Status = request.Dto.Status != null ? request.Dto.Status : position.Status;
            _writeRepository.Update(position);
            await _writeRepository.SaveAsync();
            return new UpdatePositionCommandResponse
            {
                Message = "Məlumat uğurla yeniləndi!"
            };
        }
    }
}
