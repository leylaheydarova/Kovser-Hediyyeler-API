using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHediyyeler.Application.Repositories.Positions;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Positions.Create
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommandRequest, CreatePositionCommandResponse>
    {
        readonly IPositionWriteRepository _repository;

        public CreatePositionCommandHandler(IPositionWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreatePositionCommandResponse> Handle(CreatePositionCommandRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new BadRequestException();
            Position position = new Position
            {
                ID = Guid.NewGuid(),
                Status = request.Dto.Status
            };
            await _repository.AddAsync(position);
            await _repository.SaveAsync();
            return new CreatePositionCommandResponse
            {
                StatusCode = 201,
                Message = "Vəzifə uğurla əlavə olundu!"
            };
        }
    }
}
