namespace KovserHedieyyeler.Application.Features.Queries
{
    public class GetSingleQueryResponse<T> where T : class
    {
        public T Dto { get; set; }
        public int StatusCode { get; set; } = 200;
    }
}
