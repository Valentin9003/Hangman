using System.Threading.Tasks;

namespace Hangman.Server.Features.VictimPicture
{
    public interface IVictimPictureServiceCommon
    {
        Task<string> GetNextLevel();

        Task<int> GetLevel();

        Task<int> GetUserLifes();

        Task<string> ToBase64String(string PhysicalPath);
    }
}
