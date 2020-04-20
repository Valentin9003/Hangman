using Hangman.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hangman.Data.EntityConfiguration
{
    public class VictimConfiguration : IEntityTypeConfiguration<Victim>
    {
        public void Configure(EntityTypeBuilder<Victim> builder)
        {
            builder.HasKey(pk => pk.VictimId);
        }
    }
}
