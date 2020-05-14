using System.Linq;
using System.Threading.Tasks;
using Hangman.Server.Data;
using Hangman.Server.Features.Game.Models;
using Hangman.Server.Features.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hangman.Server.Features.Game
{
    public class GameService : IGameService
    {
        private readonly HangmanDbContext context;
        private readonly IIdentityServiceCommon identityService;
        private readonly IGameServiceCommon gameServiceHelper;

        public GameService(HangmanDbContext context,IIdentityServiceCommon identityService, IGameServiceCommon gameServiceHelper)
        {
            this.context = context;
            this.identityService = identityService;
            this.gameServiceHelper = gameServiceHelper;
        }

        public async Task<JokersResponseModel> ChangeJokers()
        {
            var userId = await this.identityService.GetCurrentUserId();

            var user = await context.User
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            var jokers = user.Jokers;

            if (jokers <= 0)
            {
                return new JokersResponseModel
                {
                    Jokers = 0,
                    HaveJokers = false
                };
            }

            --jokers;

            user.Jokers = jokers;

            await context.SaveChangesAsync();

            return new JokersResponseModel
            {
                Jokers = jokers,
                HaveJokers = true
            };
        }

        public async Task<LifesResponseModel> ChangeLifes()
        {
            var userId = await this.identityService.GetCurrentUserId();

            var user = await context.Users
                                    .Where(u => u.Id == userId)
                                    .FirstOrDefaultAsync();
            if (user.Lives == 1)
            {
                await Lose();

                return new LifesResponseModel
                {
                    Lifes = 0,
                    Lose = true
                };
            }
            else
            {
                var lifes = user.Lives;
                lifes--;

                user.Lives = lifes;

                context.SaveChanges();

                return new LifesResponseModel
                {
                    Lifes = lifes,
                    Lose = false
                };
            }
        }

        public async Task<ScoresResponseModel> ChangeScores()
        {
            var userId = await this.identityService
                .GetCurrentUserId();

            var user = context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            var newScores = user.Scores + 1;

            user.Scores = newScores;

            context.SaveChanges();

            return new ScoresResponseModel
            {
                Scores = newScores
            };
        }


        public async Task<bool> GameStatus()
        {
            return (await this.identityService.GetCurrentUser()).Level == "1" ? true : false;
        }

        public async Task<JokersResponseModel> GetJokers()
        {
            return new JokersResponseModel
            {
                Jokers = (await this.identityService.GetCurrentUser()).Jokers,
                HaveJokers = true
            };    
        }

        public async Task<LifesResponseModel> GetLifes()
        {
            return new LifesResponseModel
            {
                Lifes = (await this.identityService.GetCurrentUser()).Lives,
                Lose = false
            }; 
        }

        public async Task<WordResponseModel> GetNextWord()
        {

            var userLevel = await this.gameServiceHelper.GetUserLevel();
            
            int.TryParse(userLevel, out int parsedUserLevel);

            var nextLevel = this.gameServiceHelper.GetNextLevel(userLevel);

            var existNextLevel = await this.gameServiceHelper.CheckExistNextLevel(nextLevel);


            if (!existNextLevel)
            {
               await this.Win();

                return new WordResponseModel
                {
                    Word = "YOU WIN",
                    Win = true
                };
            }

            var word = await this.context
                .Words
                .Where(w => w.Level == nextLevel)
                .Select(w => new WordResponseModel
                {
                    Word = w.WordContent,
                    Win = false
                     
                })
                .FirstOrDefaultAsync();

            await this.gameServiceHelper.LevelUp();

            return word;
        }

    public async Task<ScoresResponseModel> GetScores()
        {
            return new ScoresResponseModel
            {
                Scores = int.Parse((await this.identityService.GetCurrentUser()).Level)
            };
        }

        public async Task<WordResponseModel> GetWord()
        {
            var userLevel = await this.gameServiceHelper.GetUserLevel();

            var word = await this.context
                .Words
                .Where(w => w.Level == int.Parse(userLevel))
                .Select(w => new WordResponseModel
                {
                    Word = w.WordContent,
                    Win = false
                })
                .FirstOrDefaultAsync();

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
            user.Lives = 6;
            user.Jokers = 3;
            user.Scores = 0;

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Win()
           => await this.NewGame();
    }
}
