using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Hangman.Server.Features.Identity.Models;
using Hangman.Server.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Hangman.Server.Features.Identity
{
    public class IdentityController : ApiController
    {
        private readonly AppSettings appSettings;
        private readonly IIdentityService identityService;
        private readonly UserManager<User> userManager;

        public IdentityController(IIdentityService identityService, IOptions<AppSettings> appSettings, UserManager<User> userManager)
        {
            this.appSettings = appSettings.Value;
            this.identityService = identityService;
            this.userManager = userManager;
        }
       
        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel loginModel)
        {
            var user = await userManager
                .FindByNameAsync(loginModel.Username);
           
            if (user == null)
            {
                return Unauthorized();
            }

            var passwordIsValid = await this.userManager
                .CheckPasswordAsync(user, loginModel.Password);

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

          var result =  await this.userManager
                .CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route(nameof(ChangeEmail))]
        public async Task<ActionResult<ChangeEmailResponseModel>> ChangeEmail(ChangeEmailRequestModel changeUsernameModel)
        {
            var user = await userManager
                .GetUserAsync(this.User);
           var passwordConfirm = await userManager
                .CheckPasswordAsync(user, changeUsernameModel.Password);

            if (!passwordConfirm)
            {
                return new ChangeEmailResponseModel
                {
                    Error = new List<IdentityError>() {
                        new IdentityError
                        {
                            Code = "401",
                            Description = "Wrong Password"
                        }
                    },
                    Token = null
                };
            }

            var token = this.identityService
                .GenerateJwtToken(user.Id, user.UserName, appSettings.Secret);

            var result = await this.userManager
                .ChangeEmailAsync(user, changeUsernameModel.Email, token);

            if (result.Succeeded)
            {
                return new ChangeEmailResponseModel
                {
                    Token = token
                };
            }

            return new ChangeEmailResponseModel
            {
                Error = result.Errors
            };
        }

        [HttpPost]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(ChangePasswordRequestModel changePasswordModel)
        {
            var user = await userManager
                .GetUserAsync(this.User);

            var result = await this.userManager
                .ChangePasswordAsync(user, changePasswordModel.Password, changePasswordModel.NewPassword);

            if (result.Succeeded)
            {
                return Ok();
            }
           return BadRequest(result.Errors);
        }

        [HttpGet]
        [Route(nameof(GetEmail))]
        public async Task<ActionResult<GetEmailResponseModel>> GetEmail()
        {
            var email = (await this.userManager.GetUserAsync(this.User)).Email;

            return new GetEmailResponseModel
            {
                Email = email
            };
        }

        [HttpGet]
        [Route(nameof(GetUsername))]
        public ActionResult<UsernameResponseModel> GetUsername()
        {
            var username = this.User.Identity.Name;

            return new UsernameResponseModel
            {
                Username = username
            };
        }

     }
}
