using Hangman.Server.Data;
using Hangman.Server.Features.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Game
{
    public class GameServiceHelper : IGameServiceHelper
    {
        private readonly IIdentityServiceHelper identityServiceHelper;
        private readonly HangmanDbContext context;

        public GameServiceHelper(IIdentityServiceHelper identityServiceHelper, HangmanDbContext context)
        {
            this.identityServiceHelper = identityServiceHelper;
            this.context = context;
        }

        public async Task<string> GetUserLevel()
            => (await this.identityServiceHelper.GetCurrentUser()).Level;

        public async Task<bool> CheckExistNextLevel(int nextLevel)
        {
            return await context.Words.AnyAsync(l => l.Level == nextLevel);
        }

        public int GetNextLevel(string level)
        {
            var currentLevel = int.Parse(level);
            return currentLevel + 1;
        }
    }
}
