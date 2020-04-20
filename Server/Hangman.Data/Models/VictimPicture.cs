using System;
using System.ComponentModel.DataAnnotations;

namespace Hangman.Data.Models
{
    public class VictimPicture
    {
        [Required]
        public string VictimPictureId { get; set; }

        [Required]
        [MaxLength(HangmanDataConstants.SuffererMaxLength)]
        public byte[] Sufferer { get; set; }

        [Range(HangmanDataConstants.ProgressLevelMinRangeValue, HangmanDataConstants.ProgressLevelMaxRangeValue)]
        public int ProgressLevel { get; set; }

        [Required]
        public string VictimId { get; set; }

        public Victim Victim { get; set; }
    }
}
