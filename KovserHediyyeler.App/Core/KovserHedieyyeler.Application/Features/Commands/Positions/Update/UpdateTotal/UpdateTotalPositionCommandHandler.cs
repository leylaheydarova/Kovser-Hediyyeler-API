using KovserHedieyyeler.Application.Repositories.Abstractions.Positions;
using KovserHedieyyeler.Application.Repositories.Interfaces.Positions;
using KovserHediyyeler.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Positions.Update.UpdateTotalPosition
{
    public class UpdateTotalPositionCommandHandler : IRequestHandler<UpdateTotalPositionCommandRequest, UpdateTotalPositionCommandResponse>
    {
        readonly IPositionReadRepository _readRepository;
        readonly IPositionWriteRepository _writeRepository;

        public UpdateTotalPositionCommandHandler(IPositionReadRepository readRepository, IPositionWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<UpdateTotalPositionCommandResponse> Handle(UpdateTotalPositionCommandRequest request, CancellationToken cancellationToken)
        {
            Position position = await _readRepository.GetWhereAsync(x => !x.isDeleted && x.ID.ToString() == request.Id, true);
            position.Status = request.Dto.Status;
            _writeRepository.Update(position);
            await _writeRepository.SaveAsync();
            return new UpdateTotalPositionCommandResponse
            {
                Message = "Vəzifə məlumatlarl uğurla yeniləndi!"
            };
        }
    }
}
