using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;  // for using StringValues

namespace GetVsPost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.Run(async (HttpContext context) =>
            {
                await context.Response.WriteAsync("<h1>GET VS POST</h1>\n");


                // Creating a new Stream reader object - bases on the Request Body stream.
                StreamReader reader = new StreamReader(context.Request.Body);

                // Read full request body
                string body = await reader.ReadToEndAsync();


                // In this if statement below, if the post request contained a specific string:
                if (body == "Hello world")
                {
                    await context.Response.WriteAsync($"<p>Your posted: {body}</p>\n");
                }
                else
                {
                    await context.Response.WriteAsync($"<p>Your posted something else.</p>\n");
                }


                // Convert query string to dictionary              
                Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(body);


                // return the first value will be StringValue type.
                if (queryDict.ContainsKey("firstName"))
                {
                    string firstName = queryDict["firstName"][0];
                    await context.Response.WriteAsync($"First Name: {firstName}\n");

                }

                // In case we needed to return multiple values, we remove the [0] and implement a foreach loop.
                Dictionary<string, StringValues> qString = QueryHelpers.ParseQuery(body);

                if (qString.ContainsKey("age"))
                {
                    string age = qString["age"];
                    await context.Response.WriteAsync($"Age: {age}\n");
                   
                }


            });

            app.Run();
        }
    }
}