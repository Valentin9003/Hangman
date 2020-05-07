using Hangman.Server.Features.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Features.VictimPicture
{
    public class VictimPictureServiceCommon: IVictimPictureServiceCommon
    {
        private readonly IIdentityServiceCommon identityService;
        public VictimPictureServiceCommon(IIdentityServiceCommon identityService)
        {
            this.identityService = identityService;
        }

        public async Task<string> GetNextLevel()
        {

            var nextLevel = (await GetLevel()) + 1;

            if (nextLevel > 6)
            {
                return 6.ToString();
            }
            else if (nextLevel < 1)
            {
                return 1.ToString();
            }
            else
            {
                return nextLevel.ToString();
            }
        }

        public async Task<int> GetLevel()
        {

            var lifes = await GetUserLifes();

            var level = Math.Abs(lifes - 7);

            return level;
        }

        public async Task<int> GetUserLifes()
        {
            return (await this.identityService.GetCurrentUser()).Lives;
        }

    }
}
