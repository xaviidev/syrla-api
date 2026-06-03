using System.Text.Json;
using Syrla.Application.Common;

namespace Syrla.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(
        RequestDelegate next
    )
    {
        _next = next;
    }

    public async Task InvokeAsync(
        HttpContext context
    )
    {
        try
        {
            await _next(context);
        }
        catch (Exception)
        {
            context.Response.StatusCode = 500;

            context.Response.ContentType =
                "application/json";

            var response =
                ApiResponse<string>.Fail(
                    "Ocorreu um erro interno no sistema."
                );

            var json =
                JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);
        }
    }
}
