using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Features.VictimPicture
{
    public interface IVictimPictureServiceCommon
    {
        Task<string> GetNextLevel();

        Task<int> GetLevel();

        Task<int> GetUserLifes();
    }
}
