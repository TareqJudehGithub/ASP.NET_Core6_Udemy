namespace Middlewares.CustomMiddlware;   // in order to access CustomMiddleware.cs class

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Services
        builder.Services.AddTransient<CustomMiddleware>(); // register CustomMiddleware class as middleware service.
        #endregion 

        var app = builder.Build();

        #region Middleware(s)           
        // a lambda expression to be executed only when receiving a request.
        // Middleware 1
        app.Use(async (HttpContext context, RequestDelegate next) =>
        {
            await context.Response.WriteAsync("Executing Middleware 1 - app.Use()\n");

            // Calling the next middleware
            await next(context);   // parameter name in next method should meet the parameter name in the next middleware.                 
        });
        // middleware 2 - app.Use()
        //app.Use(async (HttpContext context, RequestDelegate next) =>
        //{
        //    await context.Response.WriteAsync("This is the 2nd app.Use() middleware.\n");
        //    await next(context);
        //});

        // app.UseMiddleware  - from Middleware Services
        app.UseMiddleware<CustomMiddleware>();


        // Middleware 3
        // This second middleware will not be executed.
        // Because the App.Run() middleware does not forward requests to the subsequent middleware.
        app.Run(async (HttpContext context) =>
        {
            await context.Response.WriteAsync("Middleware 2 - app.Run()");
        });
        #endregion

        app.Run();
    }
}


