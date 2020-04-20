using Hangman.Data;
using Hangman.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration) => services.AddDbContext<HangmanDbContext>(options =>
            options.UseSqlServer( configuration.GetConnectionString("DefaultConnection")));
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
    }
}
