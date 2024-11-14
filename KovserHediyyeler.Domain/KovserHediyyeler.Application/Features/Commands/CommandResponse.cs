namespace KovserHedieyyeler.Application.Features.Commands
{
    public abstract class CommandResponse
    {
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; }
    }
}
