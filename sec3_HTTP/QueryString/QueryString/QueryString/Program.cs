namespace QueryString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            #region Middlewares
            app.Run(async (HttpContext context) =>
            {
                int statusCode = context.Response.StatusCode;
                if (statusCode == 200)
                {
                    await context.Response.WriteAsync($"<p>Status code: {statusCode}</p>");
                }
                context.Response.Headers["Content-Type"] = "text/html";
                // if the request coming is a GET, then check the ID key in the query string
                if (context.Request.Method == "GET")
                {
                    if (context.Request.Query.ContainsKey("id"))
                    {
                        string id = context.Request.Query["id"];
                        await context.Response.WriteAsync($"<p>User ID: {id}</p>");
                    }
                    if (context.Request.Query.ContainsKey("name"))
                    {
                        string name = context.Request.Query["name"];
                        await context.Response.WriteAsync($"Username: {name}");
                    }
                }
            });
            #endregion

            app.Run();
        }
    }
}