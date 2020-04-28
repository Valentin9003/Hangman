using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hangman.Server.Infrastructure.Extensions;

namespace Hangman.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) => services
                    .AddDatabase(this.Configuration)
                    .AddApplicationServices()
                    .AddIdentity()
                    .AddOptions()
                    .AddConfiguration(this.Configuration)
                    .ConfigureJwtAutentication(this.Configuration)
                    .AddSwagger()
                    .AddApiControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                   .UseDatabaseErrorPage();
            }

            app.UseSwaggerUI()
               .UseRouting()
               .UseCors(options =>
                   options.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod())
               .UseAuthentication()
               .UseAuthorization()
               .UseEndpoints(endpoints =>
               {
                   endpoints.MapControllers();
               })
               .ApplyMigrations();
               
        }
    }
}
