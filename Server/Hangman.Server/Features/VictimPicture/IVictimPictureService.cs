using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Features.VictimPicture
{
   public interface IVictimPictureService
    {
       Task<string> GetPicture();

        Task<string> GetNextPicture();

    }
}
