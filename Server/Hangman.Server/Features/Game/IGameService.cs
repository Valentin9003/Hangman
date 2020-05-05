using Hangman.Server.Data.Models;
using Hangman.Server.Features.Game.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Game
{
    public interface IGameService
    {
        Task<bool> GameStatus();

        Task<WordResponseModel> GetWord();

        Task<LifesResponseModel> GetLifes();

        Task<LifesResponseModel> ChangeLifes(); 

        Task<JokersResponseModel> GetJokers();

        Task<JokersResponseModel> ChangeJokers();

        Task<ScoresResponseModel> GetScores();

        Task<ScoresResponseModel> ChangeScores();

        Task<bool> Win();

        Task<bool> Lose();

        Task<bool> NewGame();
        Task<WordResponseModel> GetNextWord();
    }
}
