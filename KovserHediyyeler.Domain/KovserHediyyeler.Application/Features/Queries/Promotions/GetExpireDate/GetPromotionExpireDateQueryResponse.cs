namespace KovserHediyyeler.Application.Features.Queries.Promotions.GetExpireDate
{
    public class GetPromotionExpireDateQueryResponse
    {
        public int StatusCode = 200;
        public DateTime ExpireDate { get; set; }
    }
}
