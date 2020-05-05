using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Game.Models
{
    public class LifesResponseModel
    {
        public int Lifes { get; set; }

        public bool Lose { get; set; } = false;
    }
}
