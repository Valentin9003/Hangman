using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Hangman.Server.Features.Game
{
    public class GameService : IGameService
    {
        public GameService()
        {

        }

        public Task<string> changeWord()
        {
            return Task.FromResult<string>("ChangeWord");
        }

        public Task<string> getWord()
        {
            return Task.FromResult<string>("GetWord");
        }
    }
}
