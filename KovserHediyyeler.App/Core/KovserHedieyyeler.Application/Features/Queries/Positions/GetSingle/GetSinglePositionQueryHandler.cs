using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Positions;
using KovserHedieyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHedieyyeler.Application.Repositories.Interfaces.Positions;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Positions.GetSingle
{
    public class GetSinglePositionQueryHandler : IRequestHandler<GetSinglePositionQueryRequest, GetSinglePositionQueryResponse>
    {
        readonly IPositionReadRepository _repository;
        readonly IMapper _mapper;

        public GetSinglePositionQueryHandler(IPositionReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetSinglePositionQueryResponse> Handle(GetSinglePositionQueryRequest request, CancellationToken cancellationToken)
        {
            Position position = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), false);
            if(position == null)
            {
                throw new PositionNotFoundException();
            }
            PositionGetDto dto = _mapper.Map<PositionGetDto>(position);
            return new GetSinglePositionQueryResponse
            {
                Dto = dto
            };
        }
    }
}
