using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Game
{
    public interface IGameService
    {
        Task<string> GameStatus();

        Task<string> GetWord();

        Task<string> ChangeWord();

        Task<string> GetLifes();

        Task<string> ChangeLifes(); 

        Task<string> GetJokers();

        Task<string> ChangeJokers();

        Task<string> GetScores();

        Task<string> ChangeScores();

        Task<bool> Win();

        Task<bool> Lose();

        Task<bool> NewGame();
    }
}
