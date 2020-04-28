using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hangman.Server.Data.Models
{
    public class Word
    {
        [Required]
        public string WordId { get; set; }

        [MaxLength(HangmanDataConstants.WordContentMaxLength)]
        public string WordContent { get; set; }

        [Range(HangmanDataConstants.LevelDifficultyMinRangeValue, HangmanDataConstants.LevelDifficultyMaxRangeValue)]

        public int Level { get; set; }
    }
}
