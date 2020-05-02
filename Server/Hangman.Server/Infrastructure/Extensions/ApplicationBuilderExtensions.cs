using Hangman.Server.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hangman.Server.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<HangmanDbContext>();

            dbContext.Database.Migrate();
        }
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
            => app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(ProjectConstants.SwaggerEndpoint, ProjectConstants.SwaggerApiTitle);
                    options.RoutePrefix = string.Empty;
                });
    }
}
