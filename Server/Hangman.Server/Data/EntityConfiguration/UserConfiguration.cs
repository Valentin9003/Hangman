using Hangman.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hangman.Server.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.HasOne(v => v.Victim)
                   .WithMany(u => u.Users)
                   .HasForeignKey(fk => fk.Id);
        }
    }
}
