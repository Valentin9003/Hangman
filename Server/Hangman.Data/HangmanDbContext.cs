using Hangman.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hangman.Data
{
    public class HangmanDbContext : IdentityDbContext<User>
    {

        public HangmanDbContext(DbContextOptions<HangmanDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        public DbSet<Game> Game { get; set; }

        public DbSet<VictimPicture> VictimPicture { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var assembly = typeof(HangmanDbContext).Assembly;

            builder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(builder);
        }
    }
}
