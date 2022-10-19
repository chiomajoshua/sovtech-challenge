using Microsoft.OpenApi.Models;

namespace Sovtech.API.Middleware
{
    public static class SwaggerMiddleware
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            _ = services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SovTech API", Version = "1.0" });
                c.CustomSchemaIds(x => x.FullName);
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerService(this IApplicationBuilder app, IHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseSwagger(c => c.SerializeAsV2 = true);
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SovTech API V1");
                });
            }
            return app;
        }
    }
}