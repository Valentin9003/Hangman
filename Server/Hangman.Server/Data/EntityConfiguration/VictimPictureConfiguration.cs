using Hangman.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hangman.Server.Data.EntityConfiguration
{
    public class VictimPictureConfiguration : IEntityTypeConfiguration<VictimPicture>
    {
        public void Configure(EntityTypeBuilder<VictimPicture> builder)
        {
            builder.HasKey(pk => pk.VictimPictureId);

            builder.HasOne(v => v.Victim)
                   .WithMany(vp => vp.VictimPictures)
                   .HasForeignKey(v => v.VictimId);
        }
    }
}
