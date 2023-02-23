namespace RequestHeaders
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.Run(async (HttpContext context) =>
            //{

            //});

            app.Run(async (HttpContext context) =>
            {
                // Content-Type
                // 
                // check if the header request contains a particular key named id
                if (context.Request.Headers.ContainsKey("id"))
                {
                    string id = context.Request.Headers["id"];
                    await context.Response.WriteAsync($"<p>ID = {id}</p>");
                }

                // Check for User-Agent in the request header
                if (context.Request.Headers.ContainsKey("User-Agent"))
                {
                    string userAgent = context.Request.Headers["User-Agent"];
                    await context.Response.WriteAsync($"<p>{userAgent}<p>");
                }
                // read Authorization-key
                if (context.Request.Headers.ContainsKey("Authorization-Key"))
                {
                    string authKey = context.Request.Headers["Authorization-Key"];
                    await context.Response.WriteAsync($"<p>Authorization Key: {authKey}</p>");
                }
            });
            app.Run();
        }
    }
}