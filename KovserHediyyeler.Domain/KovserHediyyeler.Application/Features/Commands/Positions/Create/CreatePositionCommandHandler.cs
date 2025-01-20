using KovserHediyyeler.Application.Abstractions;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Commands.Positions.Create
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommandRequest, CreatePositionCommandResponse>
    {
        readonly IPositionService _service;

        public CreatePositionCommandHandler(IPositionService service)
        {
            _service = service;
        }

        public async Task<CreatePositionCommandResponse> Handle(CreatePositionCommandRequest request, CancellationToken cancellationToken)
        {
            await _service.CreatePositionAsync(request.Dto);

            return new CreatePositionCommandResponse
            {
                StatusCode = 201,
                Message = "Vəzifə uğurla əlavə olundu!"
            };
        }
    }
}
