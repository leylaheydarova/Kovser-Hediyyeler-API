namespace KovserHedieyyeler.Application.Features.Commands
{
    public abstract class CreateCommandRequest<T> where T : class
    {
        public T Dto { get; set; }
    }
}
