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

        public Task<string> ChangeJokers()
        {
            throw new NotImplementedException();
        }

        public Task<string> ChangeLifes()
        {
            throw new NotImplementedException();
        }

        public Task<string> ChangeScores()
        {
            throw new NotImplementedException();
        }

        public Task<string> ChangeWord()
        {
            return Task.FromResult<string>("ChangeWord");
        }

        public Task<string> GameStatus()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetJokers()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetLifes()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetScores()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetWord()
        {
            return Task.FromResult<string>("GetWord");
        }

        public Task<string> Lose()
        {
            throw new NotImplementedException();
        }

        public Task<string> Win()
        {
            throw new NotImplementedException();
        }
    }
}
