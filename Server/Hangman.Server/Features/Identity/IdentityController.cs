using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Hangman.Data.Models;
using Microsoft.Extensions.Options;
using Hangman.Server.Features.Identity.Models;
using Hangman.Server.Features.Identity;

namespace Hangman.Server.Controllers
{
    public class IdentityController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly AppSettings appSettings;
        private readonly IdentityService identityService;

        public IdentityController(UserManager<User> usermanager, IdentityService identityService, IOptions<AppSettings> appSettings)
        {
            this.userManager = usermanager;
            this.appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel loginModel)
        {
            var user = await userManager.FindByNameAsync(loginModel.Username);

            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await userManager.CheckPasswordAsync(user, loginModel.Pasword);

            if (!passwordValid)
            {
                return Unauthorized();
            }

            var token = await this.identityService.GenerateJwtToken(
                user.Id,
                user.UserName,
                this.appSettings.Secret);

            return new LoginResponseModel
            {
                Token = token
            };
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegisterRequestModel registerModel)
        {
            var user = new User
            {
                UserName = registerModel.Username,
                Email = registerModel.Email
            };

          var result =  await userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }
    }
}
