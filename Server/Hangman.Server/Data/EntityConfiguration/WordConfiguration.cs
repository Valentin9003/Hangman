using Hangman.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Hangman.Server.Data.EntityConfiguration
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(pk => pk.WordId);

            builder.Property(p => p.Level)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(seed: 1, increment: 1);

            SeedWord(builder);
        }

        private void SeedWord(EntityTypeBuilder<Word> builder)
        {
            foreach (var word in words)
            {
                builder.HasData(new Word
                {
                    WordId = Guid.NewGuid().ToString(),
                    WordContent = word
                });
            }
        }

        private List<string> words = new List<string>()
        {
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
            "Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello",
            "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye","Hello", "Bye",
        };
    }
}
