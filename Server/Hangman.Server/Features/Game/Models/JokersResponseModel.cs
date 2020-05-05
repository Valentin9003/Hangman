using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Game.Models
{
    public class JokersResponseModel
    {
        public int Jokers { get; set; }

        public bool HaveJokers { get; set; } = true;
    }
}
