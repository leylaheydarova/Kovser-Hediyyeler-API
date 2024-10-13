using AutoMapper;
using KovserHedieyyeler.Application.DTOs.Promotion;
using KovserHedieyyeler.Application.Exceptions;
using KovserHedieyyeler.Application.Repositories.Interfaces.Promotions;
using KovserHediyyeler.Domain.Models;
using MediatR;

namespace KovserHedieyyeler.Application.Features.Queries.Promotions.GetSingle
{
    public class GetSinglePromotionQueryHandler : IRequestHandler<GetSinglePromotionQueryRequest, GetSinglePromotionQueryResponse>
    {
        readonly IPromotionReadRepository _repository;
        readonly IMapper _mapper;

        public GetSinglePromotionQueryHandler(IPromotionReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetSinglePromotionQueryResponse> Handle(GetSinglePromotionQueryRequest request, CancellationToken cancellationToken)
        {
            Promotion promotion = await _repository.GetWhereAsync(x => !x.isDeleted && x.ID == Guid.Parse(request.Id), false, nameof(Product), nameof(Department), nameof(Category));
            if (promotion == null)
            {
                throw new PromotionNotFoundException();
            }
            
            PromotionGetSingleDto dto = _mapper.Map<PromotionGetSingleDto>(promotion);
            return new GetSinglePromotionQueryResponse
            {
                Dto = dto
            };
        }
    }
}
//todo: bir mehuslun endirime dusub dusmemesini yoxlayan bir metod yaz