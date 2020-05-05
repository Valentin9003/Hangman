using Hangman.Server.Features.Image.Models;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Image
{
    interface IImageService
    {
        Task<ImageResponseModel> GetVictimPicture();
    }
}
