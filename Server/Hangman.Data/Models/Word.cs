using System;
using System.ComponentModel.DataAnnotations;

namespace Hangman.Data.Models
{
    public class Word
    {
        [Required]
        public string WordId { get; set; }

        [MaxLength(HangmanDataConstants.WordContentMaxLength)]
        public string WordContent { get; set; }

        [Range(HangmanDataConstants.LevelDifficultyMinRangeValue, HangmanDataConstants.LevelDifficultyMaxRangeValue)]
        public byte LevelDifficulty { get; set; }

        public User UserId { get; set; }

        public User User { get; set; }
    }
}
