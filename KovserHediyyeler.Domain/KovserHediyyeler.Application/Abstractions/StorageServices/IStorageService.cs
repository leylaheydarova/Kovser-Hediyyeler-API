namespace KovserHediyyeler.Application.Abstractions.StorageServices
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get; }
    }
}
