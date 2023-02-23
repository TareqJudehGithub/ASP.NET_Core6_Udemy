namespace Middlewares.CustomMiddlware
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("First Response to be executed.");
            await next(context);
            await context.Response.WriteAsync("Second Response to be executed.");

        }
    }
}
