using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<ActionResult<string>> GetWord(string token)
        {
            var tt = this.HttpContext;
            return  await gameService.GetWord();
        }

        [HttpPost()]
        [Route(nameof(GameStatus))]
        public async Task<ActionResult<bool>> GameStatus()
        {
            return await gameService.GameStatus();
        }

        [HttpGet()]
        [Route(nameof(GetLifes))]
        public async Task<ActionResult<int>> GetLifes ()
        {
            return await gameService.GetLifes();
        }

        [HttpPost()]
        [Route(nameof(ChangeLifes))]
        public async Task<ActionResult<int>> ChangeLifes()
        {
            return await gameService.ChangeLifes();
        }

        [HttpGet()]
        [Route(nameof(GetJokers))]
        public async Task<ActionResult<int>> GetJokers(int token)
        {
            return await gameService.GetJokers();
        }

        [HttpGet()]
        [Route(nameof(ChangeJokers))]
        public async Task<ActionResult<int>> ChangeJokers(string token)
        {
            return await gameService.ChangeJokers();
        }

        [HttpGet()]
        [Route(nameof(GetScores))]
        public async Task<ActionResult<int>> GetScores(string token)
        {
            return await gameService.GetScores();
        }

        [HttpGet()]
        [Route(nameof(ChangeScores))]
        public async Task<ActionResult<int>> ChangeScores(int scores)
        {
            return await gameService.ChangeScores(scores);
        }

        [HttpGet()]
        [Route(nameof(Win))]
        public async Task<ActionResult<bool>> Win()
        {
            return await gameService.NewGame();
        }

        [HttpGet()]
        [Route(nameof(Lose))]
        public async Task<ActionResult<int>> Lose(int scores)
        {
            return await gameService.ChangeScores(scores);
        }

        [HttpPost()]
        [Route(nameof(NewGame))]
        public async Task<ActionResult<bool>> NewGame(string token)
        {
            return await gameService.NewGame();
        }
    }
}
