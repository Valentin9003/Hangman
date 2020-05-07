using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Identity.Models
{
    public class ChangeEmailRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
