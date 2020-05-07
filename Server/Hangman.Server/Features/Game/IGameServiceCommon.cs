using System.Threading.Tasks;

namespace Hangman.Server.Features.Game
{
   public interface IGameServiceCommon
    {
        Task<bool> CheckExistNextLevel(int nextLevel);

        int GetNextLevel(string level);

        Task<string> GetUserLevel();

        Task<int> LevelUp();
    }
}
