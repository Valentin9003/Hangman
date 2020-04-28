using Hangman.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Hangman.Server.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(pk => pk.Id);

            SeedUser(builder);
        }

        private void SeedUser(EntityTypeBuilder<User> builder)
        {
        var users = new List<User>()
        {
             new User
             {
                 Id = Guid.NewGuid().ToString(),
                 Email = "User1@abv.bg",
                 PasswordHash = "User1@abv.bg",
                 UserName = "User1@abv.bg"
             },
             
             new User
             {
                 Id = Guid.NewGuid().ToString(),
                 Email = "User2@abv.bg",
                 PasswordHash = "User2@abv.bg",
                 UserName = "User2@abv.bg"
             },
             
             new User
             {
                 Id = Guid.NewGuid().ToString(),
                 Email = "User3@abv.bg",
                 PasswordHash = "User3@abv.bg",
                 UserName = "User3@abv.bg"
             },
             
             new User
             {
                 Id = Guid.NewGuid().ToString(),
                 Email = "User4@abv.bg",
                 PasswordHash = "User4@abv.bg",
                 UserName = "User4@abv.bg"
             },
             
             new User
             {
                 Id = Guid.NewGuid().ToString(),
                 Email = "User5@abv.bg",
                 PasswordHash = "User5@abv.bg",
                 UserName = "User5@abv.bg"
             },
             
             new User
             {
                 Id = Guid.NewGuid().ToString(),
                 Email = "User6@abv.bg",
                 PasswordHash = "User6@abv.bg",
                 UserName = "User6@abv.bg"
             },
             
             new User
             {
                 Id = Guid.NewGuid().ToString(),
                  Email = "User7@abv.bg",
                 PasswordHash = "User7@abv.bg",
                 UserName = "User7@abv.bg"
             },
             
             new User
             {
                 Id = Guid.NewGuid().ToString(),
                 Email = "User8@abv.bg",
                 PasswordHash = "User8@abv.bg",
                 UserName = "User8@abv.bg"
             },
             
             new User
             {
                 Id = Guid.NewGuid().ToString(),
                 Email = "User9@abv.bg",
                 PasswordHash = "User9@abv.bg",
                 UserName = "User9@abv.bg"
             },
             
             new User
             {
                 Id = Guid.NewGuid().ToString(),
                 Email = "User10@abv.bg",
                 PasswordHash = "User10@abv.bg",
                 UserName = "User10@abv.bg"
             },
        };

              builder.HasData(users);
        }
    }
}
