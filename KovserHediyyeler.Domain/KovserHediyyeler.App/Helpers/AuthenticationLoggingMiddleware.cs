namespace KovserHediyyeler.App.Helpers
{
    public class AuthenticationLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                Console.WriteLine("User is authenticated.");
            }
            else
            {
                Console.WriteLine("User is NOT authenticated.");
            }

            await _next(context);
        }
    }
}
