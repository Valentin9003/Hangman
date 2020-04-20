using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Data.Models
{
    public class Victim
    {
        [Required]
        public string VictimId { get; set; }

        public bool IsSelected { get; set; } = false;

        public bool IsDefaultVictim { get; set; }

        [Required]
        public List<VictimPicture> VictimPictures { get; set; } = new List<VictimPicture>();

        public List<User> Users { get; set; } = new List<User>(); 
    }
}
