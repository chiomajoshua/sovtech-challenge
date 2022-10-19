namespace Sovtech.API.Middleware
{
    public static class NwebSecMiddleware
    {
        public static IApplicationBuilder UseNWebSecurity(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                 new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                 {
                     NoStore = true,
                     NoCache = true,
                     MustRevalidate = true,
                     MaxAge = TimeSpan.FromSeconds(0),
                     Private = true,
                 };
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("Pragma", "no-cache");
                await next();
            });

            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(opts => opts.NoReferrer());
            app.UseRedirectValidation(t => t.AllowSameHostRedirectsToHttps(44361));
            app.UseXXssProtection(options => options.EnabledWithBlockMode());
            app.UseCsp(opts => opts
               .BlockAllMixedContent()
               .ScriptSources(s => s.Self())
               .ScriptSources(s => s.UnsafeEval())
               .ScriptSources(s => s.UnsafeInline())
               .StyleSources(s => s.UnsafeInline())
               .StyleSources(s => s.Self()));
            return app;
        }
    }
}