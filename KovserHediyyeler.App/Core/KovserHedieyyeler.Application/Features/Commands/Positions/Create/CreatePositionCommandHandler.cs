using AutoMapper;
using KovserHedieyyeler.Application.Exceptions.BadRequestExceptions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Positions;
using KovserHediyyeler.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Features.Commands.Positions.Create
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommandRequest, CreatePositionCommandResponse>
    {
        readonly IPositionWriteRepository _repository;
        readonly IMapper _mapper;

        public CreatePositionCommandHandler(IPositionWriteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatePositionCommandResponse> Handle(CreatePositionCommandRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new BadRequestException();
            Position position = _mapper.Map<Position>(request.Dto);
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
