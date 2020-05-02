using Hangman.Server.Data;
using Hangman.Server.Data.Models;
using Hangman.Server.Features.Identity;
using Hangman.Server.Infrastructure.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Hangman.Server.Features.Game;
using Hangman.Server.Features.Image;

namespace Hangman.Server.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration) => services.AddDbContext<HangmanDbContext>(options =>
            options.UseSqlServer( configuration.GetDefaultConnectionString()));

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<HangmanDbContext>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IIdentityService, IdentityService>()
                    .AddTransient<IIdentityServiceHelper, IdentityServiceHelper>()
                    .AddTransient<IGameService, GameService>()
                    .AddTransient<IImageService,ImageService>();

            return services;
        }

        public static IServiceCollection ConfigureJwtAutentication(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
            => services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = ProjectConstants.SwaggerApiTitle,
                        Version = ProjectConstants.SwaggerApiVersion
                    });
            });
        public static void AddApiControllers (this IServiceCollection services) =>
        services.AddControllers(options => options.Filters.Add<ModelOrNotFoundActionFilter>());

        public static IServiceCollection AddConfiguration (this IServiceCollection services, IConfiguration configuration)
            => services.Configure<AppSettings>(options => 
            configuration.GetSection(ProjectConstants.AppSettingsConfigSection).Bind(options));
    }
}
