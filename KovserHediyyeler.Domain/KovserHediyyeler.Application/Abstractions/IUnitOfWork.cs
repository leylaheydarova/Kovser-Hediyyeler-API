namespace KovserHediyyeler.Application.Abstractions
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Dispose();

    }
}
