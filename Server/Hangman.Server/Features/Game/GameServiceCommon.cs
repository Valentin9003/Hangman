using Hangman.Server.Data;
using Hangman.Server.Features.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Game
{
    public class GameServiceCommon : IGameServiceCommon
    {
        private readonly IIdentityServiceCommon identityServiceHelper;
        private readonly HangmanDbContext context;

        public GameServiceCommon(IIdentityServiceCommon identityServiceHelper, HangmanDbContext context)
        {
            this.identityServiceHelper = identityServiceHelper;
            this.context = context;
        }

        public async Task<string> GetUserLevel()
            => (await this.identityServiceHelper.GetCurrentUser()).Level;

        public async Task<bool> CheckExistNextLevel(int nextLevel)
            => await context.Words.AnyAsync(l => l.Level == nextLevel);
        

        public int GetNextLevel(string level)
           =>  (int.Parse(level) + 1);
           
        public async Task<int> LevelUp()
        {
            var userId = await identityServiceHelper.GetCurrentUserId();

            var user = await context
                .Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            int.TryParse(user.Level, out int currentLevel);

            var nextLevel = ++currentLevel;

            user.Level = nextLevel.ToString();

            context.SaveChanges();

            return nextLevel;
        }
    }
}
