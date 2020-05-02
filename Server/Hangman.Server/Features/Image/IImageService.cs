using System.Threading.Tasks;

namespace Hangman.Server.Features.Image
{
    interface IImageService
    {
        Task<byte[]> GetVictimPicture();
    }
}
