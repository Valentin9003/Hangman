using Hangman.Server.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hangman.Server.Features
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected readonly UserManager<User> userManager;
        public ApiController()
        {

        }
        protected ApiController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        protected async Task<User> GetCurrentUser() 
            => await this.userManager.GetUserAsync(this.User);

        protected async Task<string> GetCurrentUserName()
            => (await GetCurrentUser()).UserName;

        protected async Task<string> GetCurrentUserId()
           => (await GetCurrentUser()).Id;

        protected async Task<string> GetCurrentUserEmail()
           => (await GetCurrentUser()).Email;

        protected async Task<bool> CheckPasswordAsync(User user, string password)
            => await userManager.CheckPasswordAsync(user, password);

        protected async Task<IdentityResult> CreateUserAsync(User user, string password)
           => await userManager.CreateAsync(user, password);
    }
}
