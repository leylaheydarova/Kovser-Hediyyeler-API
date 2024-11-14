namespace KovserHedieyyeler.Application.Features.Commands
{
    public class UpdateCommandRequest<T> where T : class
    {
        public string Id { get; set; }
        public T Dto { get; set; }
    }
}
