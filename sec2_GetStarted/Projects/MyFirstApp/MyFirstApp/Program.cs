var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


app.Run(async (HttpContext context) =>
{
    // response code
    int statusCode = context.Response.StatusCode;
    if (statusCode == 200)
    {
        //  await context.Response.WriteAsync($"Good to go!\nStatus Code = {statusCode}");

        // Access the response object header  - Request Headers
        context.Response.Headers["MyKey"] = "My value";
        context.Response.Headers["Server"] = "My Kestrel Server";
        context.Response.Headers["Content-Type"] = "text/html";
        context.Response.Headers["max-age"] = "60";

        // Request Body
        string requestPath = context.Request.Path; // Show current path(the route the user at.)
        string requestMethod = context.Request.Method; // return request method type

        await context.Response.WriteAsync("<h1>My very first ASP.Net server!</h1>");
        await context.Response.WriteAsync("<h2>Hello world!</h2>");
        await context.Response.WriteAsync($"<p>This is the request Path: {requestPath}</p>");
        await context.Response.WriteAsync($"<p>Response method: {requestMethod}</p>");
        await context.Response.WriteAsync($"<p></p>");

    }
    else
    {
        // response body - enables us to write a response body (custom message).
        await context.Response.WriteAsync("My page was not found /cry!\n");
        await context.Response.WriteAsync("This another message! Page was not found :(\n");
        await context.Response.WriteAsync($"Status code is: {statusCode}");
    }
    #region Middleware(s)
    app.MapGet("/", () => "Hello World!!!");
    #endregion


});

app.Run();
