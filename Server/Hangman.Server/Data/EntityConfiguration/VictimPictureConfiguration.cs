using Hangman.Server.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hangman.Server.Data.EntityConfiguration
{
    public class VictimPictureConfiguration : IEntityTypeConfiguration<VictimPicture>
    {
        private readonly IHostEnvironment env;
        public VictimPictureConfiguration(IHostEnvironment env)
        {
            this.env = env;
        }
        public void Configure(EntityTypeBuilder<VictimPicture> builder)
        {
            builder.HasKey(pk => pk.VictimPictureId);

            builder.Property(p => p.ProgressLevel)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(seed: 1, increment: 1);

            SeedPicture(builder, env);
        }

       

        private void SeedPicture(EntityTypeBuilder<VictimPicture> builder, IHostEnvironment env)
        {
            var pictures = GetPictures(env);

            foreach (var picture in pictures)
            {
                builder.HasData(new VictimPicture
                {
                    VictimPictureId = Guid.NewGuid().ToString(),
                    ProgressLevel = picture.Key,
                    Sufferer = picture.Value
                });
            }
        }

        private Dictionary<int, byte[]> GetPictures(IHostEnvironment env)
        {
            var pictures = new Dictionary<int, byte[]>();

            for (int i = 1; i <= 6; i++)
            {
                var pictureFileInfo = env.ContentRootFileProvider.GetFileInfo($"{HangmanDataConstants.VictimPicturesWebRootFolderNamePathTemplate}");

                if (pictureFileInfo.Exists && int.TryParse(pictureFileInfo.Name, out int parsedName))
                {
                    var pictureByteArray = File.ReadAllBytes(pictureFileInfo.PhysicalPath);
                    pictures.Add(parsedName, pictureByteArray);
                }

            }

            return pictures;
        }
    }
}
