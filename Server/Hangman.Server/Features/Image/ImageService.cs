using Hangman.Server.Data;
using Hangman.Server.Data.Models;
using Hangman.Server.Features.Identity;
using Hangman.Server.Features.Image.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Image
{
    public class ImageService : IImageService
    {
        private readonly IHttpContextAccessor accessor;
        private readonly UserManager<User> userManager;
        private readonly HangmanDbContext context;
        private readonly IIdentityServiceHelper identityService;

        public ImageService(IHttpContextAccessor accessor, UserManager<User> userManager, HangmanDbContext context, IIdentityServiceHelper identityService)
        {
            this.accessor = accessor;
            this.userManager = userManager;
            this.context = context;
            this.identityService = identityService;
        }

        public async Task<ImageResponseModel> GetVictimPicture()
        {
            var userId = await identityService
                .GetCurrentUserId();

            var userLevel = await context.Users
                .Where(u => u.Id == userId)
                .Select(l =>l.Level)
                .FirstOrDefaultAsync();

            var level = int.Parse(userLevel);

            var picture = await this.context.VictimPicture
                .Where(vp => vp.ProgressLevel == level)
                .Select(p => new ImageResponseModel 
                { 
                    VictimPicture = p.Sufferer
                })
                .FirstOrDefaultAsync();

            return picture;
        }

    }
}
