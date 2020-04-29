using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Hangman.Server.Features.Identity.Models;
using Hangman.Server.Features.Identity;
using Hangman.Server.Data.Models;
using Hangman.Server.Features;

namespace Hangman.Server.Features.Game
{
    public class GameController : ApiController
    {
        private readonly IGameService gameService;
        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpPost()]
        [Route(nameof(GetWord))]
        public async Task<ActionResult<string>> GetWord(string token)
        {
            return  await gameService.GetWord();
        }

        [HttpPost()]
        [Route(nameof(GameStatus))]
        public async Task<ActionResult<string>> GameStatus()
        {
            return await gameService.GameStatus();
        }

        [HttpPost()]
        [Route(nameof(GetLifes))]
        public async Task<ActionResult<string>> GetLifes (string token)
        {
            return await gameService.GetLifes();
        }

        [HttpPost()]
        [Route(nameof(ChangeLifes))]
        public async Task<ActionResult<string>> ChangeLifes(string token)
        {
            return await gameService.ChangeLifes();
        }

        [HttpPost()]
        [Route(nameof(GetJokers))]
        public async Task<ActionResult<string>> GetJokers(string token)
        {
            return await gameService.GetJokers();
        }

        [HttpPost()]
        [Route(nameof(ChangeJokers))]
        public async Task<ActionResult<string>> ChangeJokers(string token)
        {
            return await gameService.ChangeJokers();
        }

        [HttpPost()]
        [Route(nameof(GetScores))]
        public async Task<ActionResult<string>> GetScores(string token)
        {
            return await gameService.GetScores();
        }

        [HttpPost()]
        [Route(nameof(ChangeScores))]
        public async Task<ActionResult<string>> ChangeScores(string token)
        {
            return await gameService.ChangeScores();
        }

        [HttpPost()]
        [Route(nameof(Win))]
        public async Task<ActionResult<string>> Win(string token)
        {
            return await gameService.GetScores();
        }

        [HttpPost()]
        [Route(nameof(Lose))]
        public async Task<ActionResult<string>> Lose(string token)
        {
            return await gameService.ChangeScores();
        }
    }
}
