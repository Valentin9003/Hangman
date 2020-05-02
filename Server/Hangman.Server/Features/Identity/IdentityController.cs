using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Hangman.Server.Features.Identity.Models;
using Hangman.Server.Data.Models;

namespace Hangman.Server.Features.Identity
{
    public class IdentityController : ApiController
    {
        private readonly AppSettings appSettings;
        private readonly IIdentityService identityService;

        public IdentityController(IIdentityService identityService, IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
            this.identityService = identityService;
        }
       
        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel loginModel)
        {
            var user = await GetCurrentUser();
           
            if (user == null)
            {
                return Unauthorized();
            }

            var passwordIsValid = await CheckPasswordAsync(user, loginModel.Password);

            if (!passwordIsValid)
            {
                return Unauthorized();
            }

            var token = identityService.GenerateJwtToken(
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

          var result =  await CreateUserAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }
    }
}
