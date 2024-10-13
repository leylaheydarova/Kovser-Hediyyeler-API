namespace KovserHedieyyeler.Application.Features.Queries
{
    public class GetAllQueryResponse<T> where T : class
    {
        public List<T> Dtos { get; set; }
        public int TotalCount { get; set; }
    }
}
