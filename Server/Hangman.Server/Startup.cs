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
                    .AddIdentity()
                    .AddApplicationServices()
                    .AddControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                   .UseDatabaseErrorPage();
            }
            
            app.UseHttpsRedirection()
               .UseRouting()
               .UseAuthentication()
               .UseAuthorization()
               .UseCors(options =>
               {
                  options.AllowAnyOrigin()
                         .AllowAnyHeader()
                         .AllowAnyMethod();
               })
               .UseEndpoints(endpoints =>
               {
                  endpoints.MapControllers();
               })
               .ApplyMigrations();
        }
    }
}
