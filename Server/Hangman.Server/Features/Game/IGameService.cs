using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Game
{
    public interface IGameService
    {
       Task<string> getWord();

       Task<string> changeWord();

    }
}
