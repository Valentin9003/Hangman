using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Hangman.Server.Features.VictimPicture
{
    public class VictimPictureService: IVictimPictureService
    {
        private readonly IHostEnvironment env;
        private readonly IVictimPictureServiceCommon pictureServiceCommon;
        public VictimPictureService(IHostEnvironment env, IVictimPictureServiceCommon pictureServiceCommon)
        {
            this.env = env;
            this.pictureServiceCommon = pictureServiceCommon;
        }

      
        public async Task<string> GetPicture()
        {
            var pictureNumber = await pictureServiceCommon.GetLevel();

                var pictureFileInfo = env.ContentRootFileProvider.GetFileInfo(ProjectConstants.VictimPicturesWebRootFolderNamePathTemplate + $"{pictureNumber}.jpg");

                if (pictureFileInfo.Exists)
                {
                    var pictureByteArray =  await File.ReadAllBytesAsync(pictureFileInfo.PhysicalPath);
                    var pictureString = Convert.ToBase64String(pictureByteArray);
                    return pictureString;
                }

                    return null;   
        }

        public async Task<string> GetNextPicture()
        {
            var nextPictureNumber = await pictureServiceCommon.GetNextLevel();

            var pictureFileInfo = env.ContentRootFileProvider.GetFileInfo(ProjectConstants.VictimPicturesWebRootFolderNamePathTemplate + $"{nextPictureNumber}.jpg");

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
