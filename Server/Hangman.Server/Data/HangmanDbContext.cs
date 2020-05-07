
using Hangman.Server.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Hangman.Server.Data
{
    public class HangmanDbContext : IdentityDbContext<User>
    {

        public HangmanDbContext(DbContextOptions<HangmanDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        public DbSet<Word> Words { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var assembly = typeof(HangmanDbContext).Assembly;

            builder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(builder);
        }
    }
}
