using System;
using System.Linq;
using System.Threading.Tasks;
using Hangman.Server.Data;
using Hangman.Server.Data.Models;
using Hangman.Server.Features.Game.Models;
using Hangman.Server.Features.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hangman.Server.Features.Game
{
    public class GameService : IGameService
    {
        private readonly HangmanDbContext context;
        private readonly IHttpContextAccessor accessor;
        private readonly UserManager<User> userManager;
        private readonly IIdentityServiceHelper identityService;
        private readonly IGameServiceHelper gameServiceHelper;

        public GameService(HangmanDbContext context, IHttpContextAccessor accessor, UserManager<User> userManager, IIdentityServiceHelper identityService, IGameServiceHelper gameServiceHelper)
        {
            this.context = context;
            this.accessor = accessor;
            this.userManager = userManager;
            this.identityService = identityService;
            this.gameServiceHelper = gameServiceHelper;
        }

        public async Task<int> ChangeJokers()
        {
            var userId = await this.identityService.GetCurrentUserId();

            var user = await context.User
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            var jokers = user.Jokers;

            if (jokers <= 0)
            {
                return -1;
            }

            jokers--;

            user.Jokers = jokers;

            await context.SaveChangesAsync();

            return jokers;
        }

        public async Task<int> ChangeLifes()
        {
            var userId = await this.identityService.GetCurrentUserId();

            var user = await context.Users
                                    .Where(u => u.Id == userId)
                                    .FirstOrDefaultAsync();
            if (user.Lives == 1)
            {
                await Lose();

                return 0;
            }
            else
            {
                var lives = user.Lives;
                lives--;

                user.Lives = lives;

                context.SaveChanges();

                return lives;
            }
        }

        public async Task<int> ChangeScores(int scores)
        {
            var userId = await this.identityService
                .GetCurrentUserId();

            var user = context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            var newScores = user.Scores + scores;

            user.Scores = newScores;

            return newScores;
        }

        public async Task<string> ChangeWord()
        {
            var userId = await this.identityService.GetCurrentUserId();

            var user = context.Users 
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            var nextLevel = gameServiceHelper
                .GetNextLevel(user.Level);

            var existNextLevel = await gameServiceHelper
                .CheckExistNextLevel(nextLevel);

            if (existNextLevel)
            {
                user.Level = nextLevel.ToString();

                return (await context.Words
                    .Where(w => w.Level == nextLevel)  
                    .Select(c => c.WordContent) 
                    .FirstOrDefaultAsync());
            }
            else
            {
                await Win();
                return "YOU WIN";
            }
        }

        public async Task<bool> GameStatus()
        {
            return (await this.identityService.GetCurrentUser()).Level == "1" ? true : false;
        }

        public async Task<int> GetJokers()
        {
            return (await this.identityService.GetCurrentUser()).Jokers;
        }

        public async Task<int> GetLifes()
        {
            return (await this.identityService.GetCurrentUser()).Scores;
        }

        public async Task<int> GetScores()
        {
            return int.Parse((await this.identityService.GetCurrentUser()).Level);
        }

        public async Task<WordResponseModel> GetWord()
        {
            var userLevel = await this.gameServiceHelper.GetUserLevel();

            if (userLevel == null)
            {
                throw new ArgumentNullException("UserLevel value not found in table 'User'");
            }

            var word = await this.context
                .Words
                .Where(w => w.Level == int.Parse(userLevel))
                .Select(w => new WordResponseModel
                {
                    Word = w.WordContent
                })
                .FirstOrDefaultAsync();

            if (word == null)
            {
                throw new ArgumentNullException("'Word' not found in table 'User'");
            }
            return word;
        }

        public async Task<bool> Lose()
            => await this.NewGame();

        public async Task<bool> NewGame()
        {
            var userId = await this.identityService
                .GetCurrentUserId();

            var user = await context
                .Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return false;
            }

            user.Level = "1";

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Win()
        {
            return await this.NewGame();
        }
    }
}
