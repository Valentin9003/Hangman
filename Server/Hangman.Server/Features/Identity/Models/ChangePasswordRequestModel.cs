using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Identity.Models
{
    public class ChangePasswordRequestModel
    {
        public string Password { get; set; }

        public string NewPassword { get; set; }
    }
}
