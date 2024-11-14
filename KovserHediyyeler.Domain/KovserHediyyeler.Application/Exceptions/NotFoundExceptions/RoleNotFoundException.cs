namespace KovserHedieyyeler.Application.Exceptions.NotFoundExceptions
{
    public class RoleNotFoundException : BaseException
    {
        public RoleNotFoundException() : base("Uyğun rol tapılmadı!")
        {
        }

        public RoleNotFoundException(string message) : base(message)
        {
        }
    }
}
