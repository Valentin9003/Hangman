using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Hangman.Server.Features.VictimPicture
{
    public class VictimPictureService: IVictimPictureService
    {
        private readonly IVictimPictureServiceCommon pictureServiceCommon;
        public VictimPictureService( IVictimPictureServiceCommon pictureServiceCommon)
        {
            this.pictureServiceCommon = pictureServiceCommon;
        }

      
        public async Task<string> GetPicture()
        {
            var pictureNumber = await pictureServiceCommon.GetLevel();

            var pictureFilePath = ProjectConstants.VictimPicturesWebRootFolderNamePathTemplate + $"{pictureNumber}" + ProjectConstants.JpgFileFormat;

            var result = await pictureServiceCommon.ToBase64String(pictureFilePath);

            return result;
        }

        public async Task<string> GetNextPicture()
        {
            var nextPictureNumber = await pictureServiceCommon.GetNextLevel();

            var pictureFilePath = ProjectConstants.VictimPicturesWebRootFolderNamePathTemplate + $"{nextPictureNumber}" + ProjectConstants.JpgFileFormat;

            var result = await pictureServiceCommon.ToBase64String(pictureFilePath);

            return result;
        }

        public async Task<string> GetWinPicture()
        {
            var pictureFilePath = ProjectConstants.WinPictureWebRootFolderNamePathTemplate + $"{ProjectConstants.JpgFileFormat}";

            var result = await pictureServiceCommon.ToBase64String(pictureFilePath);

            return result;
        }

        public async Task<string> GetLosePicture()
        {
            var pictureFilePath = ProjectConstants.LosePictureWebRootFolderNamePathTemplate + $"{ProjectConstants.JpgFileFormat}";

            var result = await pictureServiceCommon.ToBase64String(pictureFilePath);

            return result;
        }
    }
}
