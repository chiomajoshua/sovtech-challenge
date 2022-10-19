using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Serilog;
using System.Net;

namespace Sovtech.API.Middleware
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    if (contextFeature != null)
                    {
                        Log.Warning($"ExceptionFailure: {JsonConvert.SerializeObject(contextFeature.Error)}.");
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        {
                            IsSuccessful = false,
                            Message = "An Error Occurred. If This Persists, Please Contact The Administrator",
                            StatusCode = 500
                        }));
                    }
                });
            });
        }
    }
}