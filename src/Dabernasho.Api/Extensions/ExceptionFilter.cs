using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace Dabernasho.Api.Extensions;

public static class ExceptionFilterExtension
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    await context.Response.WriteAsync(
                        new ErrorDetails(contextFeature.Error.Message).ToString());
                }
            });
        });
    }

    public record ErrorDetails(string Message, int Code = 0)
    {
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}