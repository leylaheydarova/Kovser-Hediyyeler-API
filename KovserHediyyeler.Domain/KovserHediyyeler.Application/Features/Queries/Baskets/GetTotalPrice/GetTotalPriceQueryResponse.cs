namespace KovserHediyyeler.Application.Features.Queries.Baskets.GetTotalPrice
{
    public class GetTotalPriceQueryResponse
    {
        public int StatusCode { get; set; } = 200;
        public double TotalPrice { get; set; }
    }
}
