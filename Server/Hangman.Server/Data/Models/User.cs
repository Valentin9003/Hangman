using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hangman.Server.Data.Models
{
    public class User : IdentityUser
    {
        public int Lives { get; set; } = 3;

        public int Scores { get; set; } = 0;

        public int Jokers { get; set; } = 3;

        [Required]
        public string VictimId { get; set; }

        public Victim Victim { get; set; }

    }
}
