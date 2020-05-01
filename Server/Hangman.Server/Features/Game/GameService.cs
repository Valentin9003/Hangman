using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Hangman.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Hangman.Server.Features.Game
{
    public class GameService : IGameService
    {

        private readonly HangmanDbContext context;

        public GameService(HangmanDbContext context)
        {
            this.context = context;
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

        public async Task<string> GetWord()
        {
            var userLevel = await this.GetUserLevel("userId");

            if (userLevel == null)
            {
                throw new ArgumentNullException("UserLevel value not found in table 'User'");
            }

            var word = await this.context.Words.Where(w => w.Level == int.Parse(userLevel)).Select(w => w.WordContent).FirstOrDefaultAsync();

            if (word == null)
            {
                throw new ArgumentNullException("'Word' not found in table 'User'");
            }
            return word;
        }

        public async Task<bool> Lose()
        {
            return await this.NewGame();
        }

        public async Task<bool> NewGame()
        {
            var userId = "UserId";

            var user = await context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (user == null)
            {
                return false;
            }

            user.Level = "1";

            await context.SaveChangesAsync();

            return true;
        }

        public Task<bool> Win()
        {
            throw new NotImplementedException();
        }

        private async Task<string> GetUserLevel(string userId)
        {
            return await context.Users.Where(u => u.Id == userId).Select(l => l.Level).FirstOrDefaultAsync();
        }
    }
}
