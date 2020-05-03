using Hangman.Server.Data.Models;
using Hangman.Server.Features.Game.Models;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Game
{
    public interface IGameService
    {
        Task<bool> GameStatus();

        Task<WordResponseModel> GetWord();

        Task<string> ChangeWord();

        Task<int> GetLifes();

        Task<int> ChangeLifes(); 

        Task<int> GetJokers();

        Task<int> ChangeJokers();

        Task<int> GetScores();

        Task<int> ChangeScores(int scores);

        Task<bool> Win();

        Task<bool> Lose();

        Task<bool> NewGame();

    }
}
