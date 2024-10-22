namespace KovserHedieyyeler.Application.Exceptions.NotFoundExceptions
{
    public class ProductImageNotFoundException:BaseException
    {
        public ProductImageNotFoundException() : base("Məhsul şəkli tapılmadı!")
        {
        }

        public ProductImageNotFoundException(string message) : base(message) 
        {
        }
    }
}
