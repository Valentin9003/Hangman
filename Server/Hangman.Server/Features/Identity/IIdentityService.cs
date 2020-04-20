using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Identity
{
    public interface IIdentityService
    {
       Task<string> GenerateJwtToken(string userId, string userName, string secret);
    }
}
