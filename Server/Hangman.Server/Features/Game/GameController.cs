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
        public async Task<ActionResult<string>> GetWord()
        {
            return  await gameService.getWord();
        }
    }
}
