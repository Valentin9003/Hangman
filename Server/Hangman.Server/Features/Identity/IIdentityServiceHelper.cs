using Hangman.Server.Data.Models;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Identity
{
    public interface IIdentityServiceHelper
    {
        Task<User> GetCurrentUser();
        Task<string> GetCurrentUserId();
    }
}
