namespace KovserHedieyyeler.Application.Features.Commands
{
    public class UpdateCommandRequest<T> where T : class
    {
        public Guid Id { get; set; }
        public T Dto { get; set; }
    }
}
