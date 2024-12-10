namespace KovserHediyyeler.Application.Features.Commands.Baskets
{
    public abstract class BasketCommandRequest<T> where T : class
    {
        public T Dto { get; set; }
    }
}
