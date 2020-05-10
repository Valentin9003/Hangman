using Hangman.Server.Features.Identity;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Features.VictimPicture
{
    public class VictimPictureServiceCommon: IVictimPictureServiceCommon
    {
        private readonly IIdentityServiceCommon identityService;
        private readonly IHostEnvironment env;
        public VictimPictureServiceCommon(IHostEnvironment env, IIdentityServiceCommon identityService)
        {
            this.identityService = identityService;
            this.env = env;
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

        public async Task<string> ToBase64String(string PhysicalPath)
        {
            var pictureFileInfo = env.ContentRootFileProvider.GetFileInfo(PhysicalPath);

            if (pictureFileInfo.Exists)
            {
                var pictureByteArray = await File.ReadAllBytesAsync(pictureFileInfo.PhysicalPath);
                var pictureString = Convert.ToBase64String(pictureByteArray);

                return pictureString;
            }

            return null;
        }
    }
}
