namespace KovserHedieyyeler.Application.Exceptions.NotFoundExceptions
{
    public class ProductPropertyNotFoundException:BaseException
    {
        public ProductPropertyNotFoundException() : base("Məhsul xüsusiyyəti tapılmadı!")
        {
        }

        public ProductPropertyNotFoundException(string message) : base(message) 
        {
        }
    }
}
