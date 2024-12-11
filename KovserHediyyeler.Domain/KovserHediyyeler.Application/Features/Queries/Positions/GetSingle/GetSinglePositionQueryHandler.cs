using KovserHedieyyeler.Application.DTOs.Positions;
using KovserHediyyeler.Application.Exceptions.NotFoundExceptions;
using KovserHediyyeler.Application.Repositories.Positions;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Positions.GetSingle
{
    public class GetSinglePositionQueryHandler : IRequestHandler<GetSinglePositionQueryRequest, GetSinglePositionQueryResponse>
    {
        readonly IPositionReadRepository _repository;

        public GetSinglePositionQueryHandler(IPositionReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetSinglePositionQueryResponse> Handle(GetSinglePositionQueryRequest request, CancellationToken cancellationToken)
        {
            Position position = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), false);
            if (position == null) throw new NotFoundException("vəzifə");
            PositionGetDto dto = new PositionGetDto
            {
                Id = position.ID.ToString(),
                Status = position.Status
            };
            return new GetSinglePositionQueryResponse
            {
                Dto = dto
            };
        }
    }
}
