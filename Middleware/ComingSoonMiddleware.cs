using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class ComingSoonMiddleware
{
    private readonly RequestDelegate _next;

    public ComingSoonMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Check if the request is already for the ComingSoon page
        if (!context.Request.Path.Value.Contains("/Home/ComingSoon"))
        {
            // Redirect all other requests to the Home/ComingSoon page
            context.Response.Redirect("/Home/ComingSoon");
        }
        else
        {
            await _next(context);
        }
    }
}
