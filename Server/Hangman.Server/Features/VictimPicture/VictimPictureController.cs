using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Hangman.Server.Features.Game.Models;
using Hangman.Server.Features.VictimPicture;
using Hangman.Server.Features.VictimPicture.Models;

namespace Hangman.Server.Features.Game
{
    [Authorize]
    public class VictimPictureController : ApiController
    {
        private readonly IVictimPictureService victimPictureService;
        public VictimPictureController(IVictimPictureService victimPictureService)
        {
            this.victimPictureService = victimPictureService;
        }

        [HttpGet]
        [Route(nameof(GetVictimPicture))]
       public async Task<ActionResult<GetVictimPictureResponseModel>> GetVictimPicture()
        {
            var picture = await victimPictureService.GetPicture();

            return new GetVictimPictureResponseModel
            {
                VictimPicture = picture
            };
        }

        [HttpGet]
        [Route(nameof(GetNextVictimPicture))]
        public async Task<ActionResult<GetNextVictimPictureResponseModel>> GetNextVictimPicture()
        {
            var picture = await victimPictureService.GetNextPicture();

            return new GetNextVictimPictureResponseModel
            {
                VictimPicture = picture
            };
        }

        [HttpGet]
        [Route(nameof(GetWinPicture))]
        public async Task<ActionResult<GetWinPictureResponseModel>> GetWinPicture()
        {
            var picture = await victimPictureService.GetWinPicture();

            return new GetWinPictureResponseModel
            {
                WinPicture = picture
            };
        }

        [HttpGet]
        [Route(nameof(GetLosePicture))]
        public async Task<ActionResult<GetLosePictureResponseModel>> GetLosePicture()
        {
            var picture = await victimPictureService.GetLosePicture();

            return new GetLosePictureResponseModel
            {
                LosePicture = picture
            };
        }
    }
}

