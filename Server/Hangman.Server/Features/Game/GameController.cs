using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Hangman.Server.Features.Game.Models;

namespace Hangman.Server.Features.Game
{
    [Authorize]
    public class GameController : ApiController
    {
        private readonly IGameService gameService;
        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet()]
        [Route(nameof(GetWord))]
        public async Task<ActionResult<WordResponseModel>> GetWord()
        {
            return  await gameService.GetWord();
        }

        [HttpGet()]
        [Route(nameof(GetNextWord))]
        public async Task<ActionResult<WordResponseModel>> GetNextWord()
        {
            return await gameService.GetNextWord();
        }

        [HttpPost()]
        [Route(nameof(GameStatus))]
        public async Task<ActionResult<bool>> GameStatus()
        {
            return await gameService.GameStatus();
        }

        [HttpGet()]
        [Route(nameof(GetLifes))]
        public async Task<ActionResult<LifesResponseModel>> GetLifes ()
        {
            return await gameService.GetLifes();
        }

        [HttpGet()]
        [Route(nameof(ChangeLifes))]
        public async Task<ActionResult<LifesResponseModel>> ChangeLifes()
        {
            return await gameService.ChangeLifes();
        }

        [HttpGet()]
        [Route(nameof(GetJokers))]
        public async Task<ActionResult<JokersResponseModel>> GetJokers()
        {
            return await gameService.GetJokers();
        }

        [HttpGet()]
        [Route(nameof(ChangeJokers))]
        public async Task<ActionResult<JokersResponseModel>> ChangeJokers()
        {
            return await gameService.ChangeJokers();
        }

        [HttpGet()]
        [Route(nameof(GetScores))]
        public async Task<ActionResult<ScoresResponseModel>> GetScores()
        {
            return await gameService.GetScores();
        }

        [HttpGet()]
        [Route(nameof(ChangeScores))]
        public async Task<ActionResult<ScoresResponseModel>> ChangeScores()
        {
            return await gameService.ChangeScores();
        }

        [HttpGet()]
        [Route(nameof(Win))]
        public async Task<ActionResult<bool>> Win()
        {
            return await gameService.NewGame();
        }

        [HttpGet()]
        [Route(nameof(Lose))]
        public async Task<ActionResult<bool>> Lose()
        {
            return await gameService.Lose();
        }

        [HttpPost()]
        [Route(nameof(NewGame))]
        public async Task<ActionResult<bool>> NewGame(string token)
        {
            return await gameService.NewGame();
        }
    }
}
