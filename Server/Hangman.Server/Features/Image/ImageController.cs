using Hangman.Server.Features.Image;
using Hangman.Server.Features.Image.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hangman.Server.Features
{
    [Authorize]
    public class ImageController : ApiController
    {
        private readonly ImageService imageService;

        public ImageController(ImageService imageService)
        {
            this.imageService = imageService;
        }
       
        [HttpGet()]
        [Route(nameof(GetVictimPicture))]
        public async Task<ImageResponseModel> GetVictimPicture()
        {
            return await imageService.GetVictimPicture();
        }
    }
}
