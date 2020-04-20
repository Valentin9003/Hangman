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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabase(this.Configuration)
                    .AddIdentity()
                    .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
