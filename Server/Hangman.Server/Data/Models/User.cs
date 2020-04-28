using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hangman.Server.Data.Models
{
    public class User : IdentityUser
    {
        public int Lives { get; set; } = 6;

        public int Scores { get; set; } = 0;

        public int Jokers { get; set; } = 3;

        public string Level { get; set; } = "1";

    }
}
