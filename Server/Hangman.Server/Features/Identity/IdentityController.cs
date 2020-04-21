using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Hangman.Server.Features.Identity.Models;
using Hangman.Server.Features.Identity;
using Hangman.Server.Data.Models;
using Hangman.Server.Features;

namespace Hangman.Server.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly AppSettings appSettings;
        private readonly IIdentityService identityService;

        public IdentityController(UserManager<User> usermanager, IIdentityService identityService, IOptions<AppSettings> appSettings)
        {
            this.userManager = usermanager;
            this.appSettings = appSettings.Value;
            this.identityService = identityService;
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

            var token = this.identityService.GenerateJwtToken(
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
