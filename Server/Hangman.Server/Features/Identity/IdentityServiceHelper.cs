using Hangman.Server.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Identity
{
    public class IdentityServiceHelper : IIdentityServiceHelper
    {
        private readonly IHttpContextAccessor accessor;
        private readonly UserManager<User> userManager;

        public IdentityServiceHelper(IHttpContextAccessor accessor, UserManager<User> userManager)
        {
            this.accessor = accessor;
            this.userManager = userManager;
        }
        public async Task<string> GetCurrentUserId()
         => (await GetCurrentUser()).Id;

        public async Task<User> GetCurrentUser()
        {
            var principal = accessor.HttpContext.User;

            var user = await userManager.GetUserAsync(principal);

            if (user == null)
            {
                throw new ArgumentNullException("Current user not found");
            }

            return user;
        }
    }
}
