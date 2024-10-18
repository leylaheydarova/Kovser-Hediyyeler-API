namespace KovserHedieyyeler.Application.Features.Queries
{
    public class GetAllQueryResponse<T> where T : class
    {
        public List<T> Datas { get; set; }
        public int TotalCount { get; set; }
        public int StatusCode { get; set; } = 200;
    }
}
