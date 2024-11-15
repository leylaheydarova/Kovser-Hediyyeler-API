using KovserHedieyyeler.Application.DTOs.Positions;
using KovserHediyyeler.Application.Repositories.Positions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KovserHedieyyeler.Application.Features.Queries.Positions.GetAll
{
    public class GetAllPositionsQueryHandler : IRequestHandler<GetAllPositionsQueryRequest, GetAllPositionsQueryResponse>
    {
        readonly IPositionReadRepository _repository;

        public GetAllPositionsQueryHandler(IPositionReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllPositionsQueryResponse> Handle(GetAllPositionsQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllWhere(x => !x.isDeleted, false);
            int totalCount = query.Count();
            List<PositionGetDto> dtos = new List<PositionGetDto>();
            dtos = await query.Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(x => new PositionGetDto
                {
                    Id = x.ID.ToString(),
                    Status = x.Status
                }).ToListAsync();
            return new GetAllPositionsQueryResponse
            {
                Datas = dtos,
                TotalCount = totalCount
            };
        }
    }
}
