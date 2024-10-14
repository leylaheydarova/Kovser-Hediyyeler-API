namespace KovserHedieyyeler.Application.Features.Commands
{
    public abstract class CommandResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
