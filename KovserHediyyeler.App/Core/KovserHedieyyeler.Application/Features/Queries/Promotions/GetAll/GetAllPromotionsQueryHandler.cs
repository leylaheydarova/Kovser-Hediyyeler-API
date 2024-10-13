using KovserHedieyyeler.Application.DTOs.Promotion;
using KovserHedieyyeler.Application.Repositories.Interfaces.Promotions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KovserHedieyyeler.Application.Features.Queries.Promotions.GetAll
{
    public class GetAllPromotionsQueryHandler : IRequestHandler<GetAllPromotionsQueryRequest, GetAllPromotionsQueryResponse>
    {
        readonly IPromotionReadRepository _repository;

        public GetAllPromotionsQueryHandler(IPromotionReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllPromotionsQueryResponse> Handle(GetAllPromotionsQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllWhere(x => !x.isDeleted, false);
            int totalCount = query.Count();
            List<PromotionGetAllDto> dtos = await query.Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(x => new PromotionGetAllDto
                {
                    Id = x.ID.ToString(),
                    Title = x.Title,
                    Description = x.Description,
                    Price = x.Price,
                    DiscountedPrice = x.DiscountedPrice,
                    DiscountPersentage = x.DiscountPersentage.ToString(),
                    StartDate = x.StartDate,
                    ExpireDate = x.ExpireDate
                }).ToListAsync();
            return new GetAllPromotionsQueryResponse
            {
                Dtos = dtos,
                TotalCount = totalCount
            };
        }
    }
}
